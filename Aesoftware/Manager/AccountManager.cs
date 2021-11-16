using Aesoftware.Data;
using Aesoftware.Other;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            isInit = true;
        }

        public Flag Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return Flag.LOGIN_EMPTY_FIELD;

            currentAccount = DataManager.Instance.accountList.Where(account => account.Username == username && account.IsDeleted == 0).FirstOrDefault();

            // Account does not exist
            if (currentAccount == null)
                return Flag.LOGIN_USER_DOES_NOT_EXIST;
            else
            {
                if (currentAccount.Password == password)
                {
                    if (DataManager.Instance.connection.IsHWIDLocked == 1 && currentAccount.MachineGuid != SecurityManager.Instance.GetMachineGuid())
                        return Flag.LOGIN_WRONG_MACHINE;
                    else
                    {
                        currentAccount.LastIP = SecurityManager.Instance.GetPublicIP();
                        DataManager.Instance.UpdateAccount(currentAccount);
                        return Flag.LOGIN_SUCCESS;
                    }
                }
                else
                    return Flag.LOGIN_INVALID_PASSWORD;
            }
        }

        public Flag Register(string username, string password, string email, string invitationCode)
        {
            Account newAccount = new Account();

            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(email) || string.IsNullOrEmpty(invitationCode))
                return Flag.REGISTER_EMPTY_FIELD;

            if (DataManager.Instance.GetAccountByUsername(username) != null)
                return Flag.REGISTER_USER_ALREADY_EXIST;

            if (DataManager.Instance.DoesMachineExist(SecurityManager.Instance.GetMachineGuid()) && DataManager.Instance.connection.IsHWIDLocked == 1)
                return Flag.REGISTER_ACCOUNT_WITH_MACHINE_EXIST;

            if (!ActivateInviteCode(invitationCode))
                return Flag.REGISTER_INVALID_INVITE;

            newAccount.Username = username;
            newAccount.Password = password;
            newAccount.AccessRole = 0;
            newAccount.IsDeleted = 0;
            newAccount.CreatedDate = DateTime.Now;
            newAccount.LastModified = DateTime.Now;
            newAccount.CreatedIP = SecurityManager.Instance.GetPublicIP();
            newAccount.LastIP = SecurityManager.Instance.GetPublicIP();
            newAccount.MachineGuid = SecurityManager.Instance.GetMachineGuid();
            newAccount.InvitedById = DataManager.Instance.GetInviterIdFromInviteCode(invitationCode);
            newAccount.InviteCount = DataManager.Instance.connection.DefaultInviteCount;

            DataManager.Instance.InsertAccount(newAccount);
            return Flag.REGISTER_SUCCESS;
        }

        public bool ActivateInviteCode(string code)
        {
            Invite invite = DataManager.Instance.ValidateInviteCode(code);

            if (invite == null)
                return false;

            invite.Count--;
            DataManager.Instance.UpdateInviteCode(invite);

            return true;
        }
    }
}
