using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aesoftware.Data;
using Aesoftware.Other;
using MySql.Data.MySqlClient;

namespace Aesoftware.Manager
{
    // To-do: Remove in the future, shift all of these to a server side API
    // as it is dangerous to connect directly to database from client!
    public class DatabaseManager
    {
        private static DatabaseManager instance = null;
        private static readonly object padlock = new object();
        private bool isInit = false;

        private MySqlConnection sqlConnection = new MySqlConnection();

        // Connection String
        private const string hostName = "aeshi-software.cylyvbffiptc.ap-southeast-1.rds.amazonaws.com";
        private const string port = "3306";
        private const string database = "main";
        private const string username = "admin";
        private const string password = "Wenxima2002";

        DatabaseManager()
        {
        }
        public static DatabaseManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                            instance = new DatabaseManager();
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

        public DataTable Query(string query)
        {
            if (sqlConnection.State == ConnectionState.Closed)
                Connect();

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

    }
}
