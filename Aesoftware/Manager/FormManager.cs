using Aesoftware.Data;
using Aesoftware.ModulePage;
using Aesoftware.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aesoftware.Manager
{
    public class FormManager
    {
        private static FormManager instance = null;
        private static readonly object padlock = new object();
        private bool isInit = false;

        public List<Form> formList = new List<Form>();
        public List<ModuleMenuList> moduleMenuItemList = new List<ModuleMenuList>();

        private Form defaultForm = new Form();
        public LoginForm loginForm = new LoginForm();
        private RegisterForm registerForm = new RegisterForm();
        private MainMenuForm mainMenuForm = new MainMenuForm();
        private LiteValorant liteValorantForm = new LiteValorant();
        private RiotAuthenticationForm riotAuthenticationForm = new RiotAuthenticationForm();

        FormManager()
        {
        }
        public static FormManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                            instance = new FormManager();
                    }
                }

                return instance;
            }
        }

        public Form Init()
        {
            if (isInit)
                return null;

            defaultForm = loginForm;

            formList.Clear();
            formList.Add(loginForm);
            formList.Add(registerForm);
            formList.Add(mainMenuForm);
            formList.Add(liteValorantForm);
            formList.Add(riotAuthenticationForm);

            isInit = true;

            return defaultForm;
        }

        public bool DoesFormExist(string formName)
        {
            foreach (Form form in formList)
            {
                if (form.Name == formName)
                    return true;
            }

            return false;
        }
        
        public bool IsFormActive(string formName)
        {
            foreach (Form form in formList)
            {
                if (form.Name == formName && form.Visible)
                    return true;
            }

            return false;
        }

        public void ShowForm(string formName)
        {
            Form newForm = formList.Where(form => form.Name == formName).FirstOrDefault();

            if (newForm != null)
                newForm.Show();
        }

        public void CloseForm(string formName)
        {
            Form newForm = formList.Where(form => form.Name == formName).FirstOrDefault();

            if (newForm != null)
                newForm.Hide();
        }

        public void CloseAllForm(string exceptionForm = "")
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name != exceptionForm)
                    form.Hide();
                else
                    form.Show();
            }
        }

        public void ChangeForm(string formName)
        {
            Form newForm = formList.Where(form => form.Name == formName).FirstOrDefault();

            if (newForm != null)
            {
                ShowForm(formName);
                CloseAllForm(newForm.Name);
            }
        }

        public Form GetForm(string formName)
        {
            return formList.Where(form => form.Name == formName).FirstOrDefault();
        }

        public void ShowAnnouncementForm()
        {
            if (DataManager.Instance.connection.ForceAnnouncement == 0)
                return;

            ShowMessageBox(DataManager.Instance.connection.AnnouncementTitle, DataManager.Instance.connection.AnnouncementMessage);
        }
        
        public void PopulateModuleMenu()
        {
            mainMenuForm.moduleDataGridView.Rows.Clear();
            mainMenuForm.moduleDataGridView.Refresh();

            moduleMenuItemList = DataManager.Instance.GetModuleMenuList(AccountManager.Instance.currentAccount.Id);

            foreach (ModuleMenuList item in moduleMenuItemList)
            {
                if (item.IsVisible == 0)
                    continue;

                var row = (DataGridViewRow)mainMenuForm.moduleDataGridView.RowTemplate.Clone();
                
                if (item.Status == ExpiryStatus.CURRENT)
                    row.CreateCells(mainMenuForm.moduleDataGridView, item.Id, item.ModuleName, item.Expiry);
                else
                    row.CreateCells(mainMenuForm.moduleDataGridView, item.Id, item.ModuleName, item.Status.ToString());

                mainMenuForm.moduleDataGridView.Rows.Add(row);
            }
        }

        public void LaunchModule(string moduleName)
        {
            Flag flag = TryLaunchModule(moduleName);

            if (flag != Flag.MODULE_LAUNCH_SUCCESS)
            {
                SecurityManager.Instance.AddAuditLog("MainMenuForm", AuditAction.LAUNCH_MODULE_FAILED, AccountManager.Instance.currentAccount.Id, flag.ToString());
                ShowMesageBoxButton("ModuleAction Failed", "Reason: " + flag.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                SecurityManager.Instance.AddAuditLog("MainMenuForm", AuditAction.LAUNCH_MODULE_SUCCESS, AccountManager.Instance.currentAccount.Id, flag.ToString());
                ShowForm(moduleName);
            }
        }

        public Flag TryLaunchModule(string moduleName)
        {
            if (String.IsNullOrEmpty(moduleName))
                return Flag.MODULE_NULL;

            if (!DoesFormExist(moduleName))
                return Flag.MODULE_NOT_FOUND;

            if (!CheckForModulePermission(moduleName))
                return Flag.MODULE_NO_ACCESS;

            if (CheckForModuleExpiry(moduleName))
                return Flag.MODULE_EXPIRED;

            if (IsFormActive(moduleName))
                return Flag.MODULE_INSTANCE_RUNNING;

            return Flag.MODULE_LAUNCH_SUCCESS;
        }

        public void ShowMessageBox(string title, string message)
        {
            MessageBox.Show(message, title);
        }

        public DialogResult ShowMesageBoxButton(string title, string message, MessageBoxButtons buttons, MessageBoxIcon icon = 0)
        {
            return MessageBox.Show(message, title, buttons, icon);
        }

        public void Login(string username, string password)
        {
            Data.Flag flag = AccountManager.Instance.Login(username, password);

            if (flag == Data.Flag.LOGIN_SUCCESS)
            {
                SecurityManager.Instance.AddAuditLog("LoginForm", AuditAction.LOGIN_SUCCESS, DataManager.Instance.GetAccountByUsername(username).Id, flag.ToString(), username + ":" + password);
                ShowMesageBoxButton("Login Success", "User authenticated!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChangeForm("MainMenuForm");
            }
            else
            {
                SecurityManager.Instance.AddAuditLog("LoginForm", AuditAction.LOGIN_FAILED, 0, flag.ToString(), username + ":" + password);
                ShowMesageBoxButton("Login Failed", "Reason: " + flag.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Register(string username, string password, string email, string invitationCode)
        {
            Data.Flag flag = AccountManager.Instance.Register(username, password, email, invitationCode);

            if (flag == Data.Flag.REGISTER_SUCCESS)
            {
                SecurityManager.Instance.AddAuditLog("RegisterForm", AuditAction.REGISTER_SUCCESS, 0, flag.ToString(), username + ":" + password + ":" + email + ":" + invitationCode);
                ShowMesageBoxButton("Register Success", "User registered!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChangeForm("LoginForm");
            }
            else
            {
                SecurityManager.Instance.AddAuditLog("RegisterForm", AuditAction.REGISTER_FAILED, 0, flag.ToString(), username + ":" + password + ":" + email + ":" + invitationCode);
                ShowMesageBoxButton("Register Failed", "Reason: " + flag.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool CheckClientDisabled()
        {
            DataManager.Instance.LoadData();
            Connection connection = DataManager.Instance.connection;

            if (connection.DisableClientIfVersionMismatch == 1 && 
                (DataManager.Instance.buildVersion < connection.AllowedVersion &&
                DataManager.Instance.buildVersion != connection.LatestVersion))
            {
                Logout();
                ShowMesageBoxButton("Version mismatch", "A newer client version is available!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            if (DataManager.Instance.connection.IsClientDisabled == 1)
            {
                Logout();
                ShowMesageBoxButton("Notice", "Client is currently disabled!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            return false;
        }

        

        public bool CheckForModuleExpiry(string moduleName)
        {
            ModuleMenuList moduleMenuList = moduleMenuItemList.Where(module => module.ModuleName == moduleName).FirstOrDefault();

            return moduleMenuList.Status == ExpiryStatus.EXPIRED;
        }

        public bool CheckForModulePermission(string moduleName)
        {
            ModuleMenuList moduleMenuList = moduleMenuItemList.Where(module => module.ModuleName == moduleName).FirstOrDefault();

            return Convert.ToBoolean(moduleMenuList.CanUse);
        }

        public void DatabaseError()
        {
            ShowMesageBoxButton("Server error", "Unable to connect to server, please try again later or notify wenxi#9300 on discord", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Logout()
        {
            AccountManager.Instance.currentAccount = null;
            ChangeForm("LoginForm");
        }

        public void ResetInputBoxLoginForm()
        {
            loginForm.LoginInputBox.Text = "";
            loginForm.PasswordInputBox.Text = "";
        }
    }
}
