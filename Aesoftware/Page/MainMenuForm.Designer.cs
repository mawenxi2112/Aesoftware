namespace Aesoftware.Page
{
    partial class MainMenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.moduleDataGridView = new System.Windows.Forms.DataGridView();
            this.ModuleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModuleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Expiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModuleLaunch = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.moduleDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // moduleDataGridView
            // 
            this.moduleDataGridView.AllowUserToResizeColumns = false;
            this.moduleDataGridView.AllowUserToResizeRows = false;
            this.moduleDataGridView.ColumnHeadersHeight = 24;
            this.moduleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.moduleDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ModuleId,
            this.ModuleName,
            this.Expiry,
            this.ModuleLaunch});
            this.moduleDataGridView.Location = new System.Drawing.Point(12, 12);
            this.moduleDataGridView.Name = "moduleDataGridView";
            this.moduleDataGridView.ReadOnly = true;
            this.moduleDataGridView.RowHeadersVisible = false;
            this.moduleDataGridView.RowHeadersWidth = 30;
            this.moduleDataGridView.Size = new System.Drawing.Size(390, 297);
            this.moduleDataGridView.TabIndex = 1;
            // 
            // ModuleId
            // 
            this.ModuleId.HeaderText = "ModuleId";
            this.ModuleId.Name = "ModuleId";
            this.ModuleId.ReadOnly = true;
            this.ModuleId.Width = 60;
            // 
            // ModuleName
            // 
            this.ModuleName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ModuleName.HeaderText = "ModuleName";
            this.ModuleName.Name = "ModuleName";
            this.ModuleName.ReadOnly = true;
            // 
            // Expiry
            // 
            this.Expiry.HeaderText = "Expiring In";
            this.Expiry.Name = "Expiry";
            this.Expiry.ReadOnly = true;
            this.Expiry.Width = 110;
            // 
            // ModuleLaunch
            // 
            this.ModuleLaunch.HeaderText = "Launch";
            this.ModuleLaunch.Name = "ModuleLaunch";
            this.ModuleLaunch.ReadOnly = true;
            this.ModuleLaunch.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ModuleLaunch.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ModuleLaunch.Width = 50;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 321);
            this.Controls.Add(this.moduleDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainMenuForm";
            this.Text = "Select Module";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenuForm_FormClosing);
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.moduleDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView moduleDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModuleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModuleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expiry;
        private System.Windows.Forms.DataGridViewButtonColumn ModuleLaunch;
    }
}