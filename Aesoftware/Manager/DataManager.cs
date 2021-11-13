using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Aesoftware.Data;
using Aesoftware.Other;
using MySql.Data.MySqlClient;

namespace Aesoftware.Manager
{
    // To-do: Remove in the future, shift all of these to a server side API
    // as it is dangerous to connect directly to database from client!
    public class DataManager
    {
        private static DataManager instance = null;
        private static readonly object padlock = new object();
        private bool isInit = false;

        private MySqlConnection sqlConnection = new MySqlConnection();

        // Connection String
        private const string hostName = "remotemysql.com";
        private const string port = "3306";
        private const string database = "50L1stRsGD";
        private const string username = "50L1stRsGD";
        private const string password = "3KTyCInq3R";

        public List<Account> accountList = new List<Account>();
        public List<Invite> inviteList = new List<Invite>();
        public List<ModuleItem> moduleList = new List<ModuleItem>();
        public List<ModulePermission> modulePermissionList = new List<ModulePermission>();
        public List<Role> roleList = new List<Role>();
        public Connection connection = null;
        public Timer timer = null;

        DataManager()
        {
        }
        public static DataManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                            instance = new DataManager();
                    }
                }

                return instance;
            }
        }

        public void Init()
        {
            if (isInit)
                return;

            Connect();

            isInit = true;
        }

        private void Connect()
        {
            try
            {
                sqlConnection.ConnectionString = $"server ={ hostName }; port ={ port }; database ={ database }; user ={ username }; password ={ password }";
                sqlConnection.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException exception)
            {
                //To-do: Throw error when can't connect to sql
                // MessageBox.Show(exception.Message);
            }
        }

        public void Disconnect()
        {
            if (sqlConnection.State == ConnectionState.Open)
                sqlConnection.Close();
        }



        public void LoadData()
        {
            accountList = Utility.DataTableToList<Account>(Query(DataString.QuerySelectAccount));
            inviteList = Utility.DataTableToList<Invite>(Query(DataString.QuerySelectInvite));
            moduleList = Utility.DataTableToList<ModuleItem>(Query(DataString.QuerySelectModule));
            modulePermissionList = Utility.DataTableToList<ModulePermission>(Query(DataString.QuerySelectModulePermission));
            roleList = Utility.DataTableToList<Role>(Query(DataString.QuerySelectRole));
            connection = Utility.DataTableToList<Connection>(Query(DataString.QuerySelectConnection))[0];

            if (timer == null)
            {
                timer = new Timer();
                timer.Interval = connection.PollingRate;
                timer.Elapsed += PollEvent;
                timer.Enabled = true;
            }
        }

        public void PollEvent(object sender, ElapsedEventArgs e)
        {
            if (!FormManager.Instance.IsFormActive("MainMenuForm"))
                return;

            Debug.WriteLine("Polling!");
            LoadData();

            // Do account verification
            // Update modules
        }

        public DataTable Query(string query)
        {
            if (sqlConnection.State == ConnectionState.Closed)
            {
                Connect();
                return null;
            }

            DataTable queryResult = new DataTable();

            try
            {
                MySqlCommand command = new MySqlCommand(query, sqlConnection);
                queryResult.Load(command.ExecuteReader());
            }
            catch (MySql.Data.MySqlClient.MySqlException exception)
            {
                //To-do: Throw error if can't receive query
                // MessageBox.Show(exception.Message);
            }

            return queryResult;
        }

        public void InsertRecord(string tableName, Object newObject)
        {
            if (newObject == null)
                return;

            try
            {
                Type type = newObject.GetType();
                IList<PropertyInfo> properties = new List<PropertyInfo>(type.GetProperties());

                List<string> attributes = new List<string>();
                List<string> values = new List<string>();

                for (int i = 0; i < properties.Count; i++)
                {
                    // So when we enter the record into database, it will not override or use an existing Id.
                    if (properties[i].Name == "Id")
                        continue;

                    // Hardcode to reformat date string due to SQL format error
                    // To-do: Find a workaround for this
                    if (properties[i].Name == "CreatedDate" || properties[i].Name == "LastModified")
                    {
                        attributes.Add(properties[i].Name);
                        values.Add(((DateTime)properties[i].GetValue(newObject)).ToString("yyyy-MM-dd HH:mm:ss.fff"));
                        continue;
                    }

                    attributes.Add(properties[i].Name);
                    values.Add(properties[i].GetValue(newObject).ToString());
                }

                Debug.WriteLine("Inserting record(s) of " + string.Join(" ", attributes) + " into " + tableName);
                string sqlCommandString = $"INSERT INTO {tableName} ({string.Join(",", attributes)}) values (\"{string.Join("\",\"", values)}\")";

                Debug.WriteLine(sqlCommandString);

                MySqlCommand command = new MySqlCommand(sqlCommandString, sqlConnection);
                int inserted = command.ExecuteNonQuery();

                Debug.WriteLine(string.Format("{0} record(s) successfully added", inserted));

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        public void UpdateRecord(MySqlCommand sqlCommand)
        {
            try
            {
                sqlCommand.Connection = sqlConnection;
                int inserted = sqlCommand.ExecuteNonQuery();

                Debug.WriteLine(string.Format("{0} record(s) successfully updated.", inserted));

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        public void UpdateInviteCode(Invite inviteCode)
        {
            string query = "Update Invite Set Count=@Count WHERE Id=@Id";
            MySqlCommand command = new MySqlCommand();
            command.CommandText = query;
            command.Parameters.AddWithValue("@Count", inviteCode.Count);
            command.Parameters.AddWithValue("@Id", inviteCode.Id);

            UpdateRecord(command);
        }

        public Invite ValidateInviteCode(string code)
        {
            return inviteList.Where(invite => invite.Code == code && invite.Count > 0).FirstOrDefault();

        }

        public void InsertAccount(Account account)
        {
            InsertRecord("Account", account);
        }

        public Account GetAccountById(int id)
        {
            return accountList.Where(account => account.Id == id && account.IsDeleted == 0).FirstOrDefault();
        }

        public Account GetAccountByUsername(string username)
        {
            return accountList.Where(account => account.Username == username && account.IsDeleted == 0).FirstOrDefault();
        }

        public int GetInviterIdFromInviteCode(string code)
        {
            Invite getInvite = inviteList.Where(invite => invite.Code == code).FirstOrDefault();

            if (getInvite != null)
                return getInvite.Id;
            else
                return 0;
        }
        
        public bool DoesMachineExist(string machineGuid)
        {
            Account checkAccount = accountList.Where(account => account.MachineGuid == machineGuid && account.IsDeleted == 0).FirstOrDefault();

            if (checkAccount == null)
                return false;
            else
                return true;
        }
    }
}
