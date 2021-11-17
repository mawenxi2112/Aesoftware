using Aesoftware.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aesoftware.Page
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (FormManager.Instance.CheckClientDisabled())
                return;
            FormManager.Instance.Login(LoginInputBox.Text, PasswordInputBox.Text);
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (FormManager.Instance.CheckClientDisabled())
                return;
            FormManager.Instance.ShowForm("RegisterForm");
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            SecurityManager.Instance.AddAuditLog("LoginForm", AuditAction.LAUNCH_CLIENT);
            DataManager.Instance.LoadData();
            FormManager.Instance.ShowAnnouncementForm();
        }

    }
}
