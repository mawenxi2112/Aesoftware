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

        private Form defaultForm = new Form();
        public LoginForm loginForm = new LoginForm();
        private RegisterForm registerForm = new RegisterForm();
        private MainMenuForm mainMenuForm = new MainMenuForm();
        private LiteValorant liteValorantForm = new LiteValorant();

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

            isInit = true;

            return defaultForm;
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
                newForm.Show();
                CloseAllForm(newForm.Name);
            }
        }

        public void PopulateModuleMenu()
        {
            List<ModuleMenuList> moduleMenuList = DataManager.Instance.GetModuleMenuList(AccountManager.Instance.currentAccount.Id);

            foreach (ModuleMenuList item in moduleMenuList)
            {
                if (item.IsVisible == 0)
                    continue;

                var row = (DataGridViewRow)mainMenuForm.moduleDataGridView.RowTemplate.Clone();
                row.CreateCells(mainMenuForm.moduleDataGridView, item.Id, item.ModuleName, item.Expiry);
                mainMenuForm.moduleDataGridView.Rows.Add(row);
            }

            // To-do: Reset module menu everytime this function is called
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
                ShowMesageBoxButton("Login Success", "User authenticated!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChangeForm("MainMenuForm");
            }
            else
                ShowMesageBoxButton("Login Failed", "Reason: " + flag.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public void Register(string username, string password, string email, string invitationCode)
        {
            Data.Flag flag = AccountManager.Instance.Register(username, password, email, invitationCode);

            if (flag == Data.Flag.REGISTER_SUCCESS)
            {
                ShowMesageBoxButton("Register Success", "User registered!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChangeForm("LoginForm");
            }
            else
                ShowMesageBoxButton("Register Failed", "Reason: " + flag.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool CheckClientDisabled()
        {
            DataManager.Instance.LoadData();

            if (DataManager.Instance.connection.IsClientDisabled == 1)
            {
                ShowMesageBoxButton("Notice", "Client is currently disabled!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            return false;
        }

        public void DatabaseError()
        {
            ShowMesageBoxButton("Server error", "Unable to connect to server, please try again later or notify wenxi#9300 on discord", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Logout()
        {
            ChangeForm("LoginForm");
        }

        public void ResetInputBoxLoginForm()
        {
            loginForm.LoginInputBox.Text = "";
            loginForm.PasswordInputBox.Text = "";
        }
    }
}
