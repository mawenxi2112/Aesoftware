using Aesoftware.Data;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aesoftware.Manager
{
    public enum AuditAction
    {
        LAUNCH_CLIENT,
        LOGIN_SUCCESS,
        LOGIN_FAILED,
        REGISTER_SUCCESS,
        REGISTER_FAILED,
        LAUNCH_MODULE_SUCCESS,
        LAUNCH_MODULE_FAILED,
        LITEVALORANT_AUTH_SUCCESS,
        LITEVALORANT_AUTH_FAILED,
    }

    public class SecurityManager
    {
        private static SecurityManager instance = null;
        private static readonly object padlock = new object();
        private bool isInit = false;
        SecurityManager()
        {
        }
        public static SecurityManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                            instance = new SecurityManager();
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

        public void AddAuditLog(string module, AuditAction action, int accountId = 0, string actionResult = " ", string data = " ")
        {
            if (DataManager.Instance.connection == null)
                return;

            String auditFilter = DataManager.Instance.connection.AuditFilter;

            if (auditFilter.Contains("all") || auditFilter.Contains(action.ToString().ToLower()))
            {
                Audit audit = new Audit();
                audit.AccountId = accountId;
                audit.Module = module;
                audit.Action = action.ToString();
                audit.ActionResult = actionResult;
                audit.Data = data;
                audit.CreatedDate = DateTime.Now;
                audit.CreatedIP = GetPublicIP();
                audit.MachineGuid = GetMachineGuid();

                DataManager.Instance.InsertRecord("Audit", audit);
            }
        }

        public string GetMachineGuid()
        {
            string location = @"SOFTWARE\Microsoft\Cryptography";
            string name = "MachineGuid";

            using (RegistryKey localMachineX64View =
                RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                using (RegistryKey rk = localMachineX64View.OpenSubKey(location))
                {
                    if (rk == null)
                        throw new KeyNotFoundException(
                            string.Format("Key Not Found: {0}", location));

                    object machineGuid = rk.GetValue(name);
                    if (machineGuid == null)
                        throw new IndexOutOfRangeException(
                            string.Format("Index Not Found: {0}", name));

                    return machineGuid.ToString();
                }
            }
        }

        public string GetPublicIP()
        {
            return new System.Net.WebClient().DownloadString("https://api.ipify.org");
        }
    }
}
