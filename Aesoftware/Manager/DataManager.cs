using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
        private const string hostName = "aesoftware.cylyvbffiptc.ap-southeast-1.rds.amazonaws.com";
        private const string port = "3306";
        private const string database = "main";
        private const string username = "admin";
        private const string password = "Wenxima2002";

        public List<Account> accountList = new List<Account>();
        public List<Invite> inviteList = new List<Invite>();
        public List<ModuleItem> moduleList = new List<ModuleItem>();
        public List<ModulePermission> modulePermissionList = new List<ModulePermission>();
        public List<Role> roleList = new List<Role>();

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
            accountList = Utility.DataTableToList<Account>(DataManager.Instance.Query(DataString.QuerySelectAccount));
            inviteList = Utility.DataTableToList<Invite>(DataManager.Instance.Query(DataString.QuerySelectInvite));
            moduleList = Utility.DataTableToList<ModuleItem>(DataManager.Instance.Query(DataString.QuerySelectModule));
            modulePermissionList = Utility.DataTableToList<ModulePermission>(DataManager.Instance.Query(DataString.QuerySelectModulePermission));
            roleList = Utility.DataTableToList<Role>(DataManager.Instance.Query(DataString.QuerySelectRole));
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

                string[] attributes = new string[properties.Count];
                string[] values = new string[properties.Count];

                for (int i = 0; i < properties.Count; i++)
                {
                    attributes[i] = properties[i].Name;
                    values[i] = properties[i].GetValue(newObject).ToString();
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

    }
}
