using Aesoftware.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aesoftware.Page
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            FormManager.Instance.Register(RegisterUsernameTextBox.Text, RegisterPasswordTextBox.Text, RegisterEmailTextBox.Text, RegisterInvitationCodeTextbox.Text);
        }

        private void RegisterCloseButton_Click(object sender, EventArgs e)
        {
            FormManager.Instance.ChangeForm("LoginForm");
        }

    }
}
