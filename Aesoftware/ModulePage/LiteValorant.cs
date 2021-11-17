using Aesoftware.Manager;
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
    public partial class LiteValorant : Form
    {
        public LiteValorant()
        {
            InitializeComponent();
        }

        private void LiteValorant_Shown(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                ValorantManager.Instance.RefreshDataOnLiteValorant();
            }
        }

        private void authenticationStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.Instance.ShowForm("RiotAuthenticationForm");
        }

        private void refreshStripMenuItem_Click(object sender, EventArgs e)
        {
            ValorantManager.Instance.RefreshDataOnLiteValorant();
        }

        private void LiteValorant_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void LiteValorant_Load(object sender, EventArgs e)
        {

        }
    }
}
