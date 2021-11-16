using Aesoftware.ModuleManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aesoftware.ModulePage
{
    public partial class RiotAuthenticationForm : Form
    {
        public RiotAuthenticationForm()
        {
            InitializeComponent();
        }


        private void authenticationFormLoginButton_Click(object sender, EventArgs e)
        {
            ValorantManager.Instance.LoadAuthWithCredentials(usernameTextBox.Text, passwordTextBox.Text, (ValAPINet.Region)regionComboBox.SelectedValue);
        }
        
        private void authenticationFormLoginNoAccountButton_Click(object sender, EventArgs e)
        {
            ValorantManager.Instance.LoadAuthWithNoCredentials((ValAPINet.Region)regionComboBox.SelectedValue);
        }
        private void RiotAuthenticationForm_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible) 
            {
                ValorantManager.Instance.RefreshDataOnLiteValorant();
                ValorantManager.Instance.RefreshDataOnPremiumValorant();
            }
            else
            {
                usernameTextBox.Text = "";
                passwordTextBox.Text = "";
                regionComboBox.DataSource = Enum.GetValues(typeof(ValAPINet.Region));
            }
        }

        private void RiotAuthenticationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
