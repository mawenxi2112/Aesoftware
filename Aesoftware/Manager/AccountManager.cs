using Aesoftware.Data;
using Aesoftware.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aesoftware.Manager
{
    public class AccountManager
    {
        private static AccountManager instance = null;
        private static readonly object padlock = new object();
        private bool isInit = false;

        public List<Account> accountList = new List<Account>();
        public Account currentAccount = null;

        AccountManager()
        {
        }
        public static AccountManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                            instance = new AccountManager();
                    }
                }

                return instance;
            }
        }

        public void Init()
        {
            if (isInit)
                return;

            LoadAccountList();

            isInit = true;
        }

        public void LoadAccountList()
        {
            accountList = Utility.DataTableToList<Account>(DatabaseManager.Instance.Query(DataString.QuerySelectAccount));
        }

        public bool Login(string username, string password)
        {
            LoadAccountList();

            currentAccount = accountList.Where(account =>
            account.Username == username &&
            account.Password == password &&
            account.isDeleted == 0).FirstOrDefault();

            // To-do: Add different flags for more customizability
            if (currentAccount != null)
                return true;

            return false;
        }

        public bool Register(string username, string password)
        {
            LoadAccountList();

            // To-do: Add different flags for more customizability
            return false;
        }
    }
}
