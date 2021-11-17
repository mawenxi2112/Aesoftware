namespace Aesoftware.ModulePage
{
    partial class LiteValorant
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LiteValorant));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.authenticationStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.AccountTab = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.competitiveListView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.infoListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StoreTab = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.storeListView = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.AccountTab.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.StoreTab.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.authenticationStripMenuItem,
            this.refreshStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(332, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // authenticationStripMenuItem
            // 
            this.authenticationStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("authenticationStripMenuItem.Image")));
            this.authenticationStripMenuItem.Name = "authenticationStripMenuItem";
            this.authenticationStripMenuItem.Size = new System.Drawing.Size(114, 20);
            this.authenticationStripMenuItem.Text = "Authentication";
            this.authenticationStripMenuItem.Click += new System.EventHandler(this.authenticationStripMenuItem_Click);
            // 
            // refreshStripMenuItem
            // 
            this.refreshStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("refreshStripMenuItem.Image")));
            this.refreshStripMenuItem.Name = "refreshStripMenuItem";
            this.refreshStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.refreshStripMenuItem.Text = "Refresh";
            this.refreshStripMenuItem.Click += new System.EventHandler(this.refreshStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.AccountTab);
            this.tabControl1.Controls.Add(this.StoreTab);
            this.tabControl1.Location = new System.Drawing.Point(13, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(307, 297);
            this.tabControl1.TabIndex = 1;
            // 
            // AccountTab
            // 
            this.AccountTab.Controls.Add(this.groupBox2);
            this.AccountTab.Controls.Add(this.groupBox1);
            this.AccountTab.Location = new System.Drawing.Point(4, 22);
            this.AccountTab.Name = "AccountTab";
            this.AccountTab.Padding = new System.Windows.Forms.Padding(3);
            this.AccountTab.Size = new System.Drawing.Size(299, 271);
            this.AccountTab.TabIndex = 0;
            this.AccountTab.Text = "Account";
            this.AccountTab.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.competitiveListView);
            this.groupBox2.Location = new System.Drawing.Point(6, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 117);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Competitive";
            // 
            // competitiveListView
            // 
            this.competitiveListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.competitiveListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.competitiveListView.HideSelection = false;
            this.competitiveListView.Location = new System.Drawing.Point(6, 19);
            this.competitiveListView.Name = "competitiveListView";
            this.competitiveListView.Size = new System.Drawing.Size(275, 98);
            this.competitiveListView.TabIndex = 1;
            this.competitiveListView.UseCompatibleStateImageBehavior = false;
            this.competitiveListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Field";
            this.columnHeader3.Width = 109;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Data";
            this.columnHeader4.Width = 162;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.infoListView);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 136);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // infoListView
            // 
            this.infoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.infoListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.infoListView.HideSelection = false;
            this.infoListView.Location = new System.Drawing.Point(6, 19);
            this.infoListView.Name = "infoListView";
            this.infoListView.Size = new System.Drawing.Size(275, 111);
            this.infoListView.TabIndex = 0;
            this.infoListView.UseCompatibleStateImageBehavior = false;
            this.infoListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Field";
            this.columnHeader1.Width = 109;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Data";
            this.columnHeader2.Width = 162;
            // 
            // StoreTab
            // 
            this.StoreTab.Controls.Add(this.groupBox3);
            this.StoreTab.Location = new System.Drawing.Point(4, 22);
            this.StoreTab.Name = "StoreTab";
            this.StoreTab.Padding = new System.Windows.Forms.Padding(3);
            this.StoreTab.Size = new System.Drawing.Size(299, 271);
            this.StoreTab.TabIndex = 1;
            this.StoreTab.Text = "Store";
            this.StoreTab.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.storeListView);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(287, 259);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Offer";
            // 
            // storeListView
            // 
            this.storeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id});
            this.storeListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.storeListView.HideSelection = false;
            this.storeListView.Location = new System.Drawing.Point(6, 19);
            this.storeListView.Name = "storeListView";
            this.storeListView.Size = new System.Drawing.Size(275, 234);
            this.storeListView.TabIndex = 0;
            this.storeListView.UseCompatibleStateImageBehavior = false;
            this.storeListView.View = System.Windows.Forms.View.Details;
            // 
            // Id
            // 
            this.Id.Text = "Skin Name";
            this.Id.Width = 262;
            // 
            // LiteValorant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 337);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LiteValorant";
            this.ShowIcon = false;
            this.Text = "LiteValorant";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LiteValorant_FormClosing);
            this.Load += new System.EventHandler(this.LiteValorant_Load);
            this.Shown += new System.EventHandler(this.LiteValorant_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.AccountTab.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.StoreTab.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem authenticationStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage AccountTab;
        private System.Windows.Forms.TabPage StoreTab;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ListView infoListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        public System.Windows.Forms.ListView competitiveListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.ListView storeListView;
        private System.Windows.Forms.ColumnHeader Id;
    }
}