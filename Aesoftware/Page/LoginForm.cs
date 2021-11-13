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
            FormManager.Instance.Login(LoginInputBox.Text, PasswordInputBox.Text);
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            FormManager.Instance.ShowForm("RegisterForm");
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            DataManager.Instance.LoadData();
        }

    }
}
