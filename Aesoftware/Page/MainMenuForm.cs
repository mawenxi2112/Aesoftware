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
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                FormManager.Instance.Logout();
                e.Cancel = true;
                Hide();
            }
        }
        private void MainMenuForm_Load(object sender, EventArgs e)
        {
        }

        private void moduleDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                FormManager.Instance.LaunchModule(senderGrid.Rows[e.RowIndex].Cells["ModuleName"].Value.ToString());
            }
        }

        private void MainMenuForm_Shown(object sender, EventArgs e)
        {
            FormManager.Instance.PopulateModuleMenu();
        }
    }
}