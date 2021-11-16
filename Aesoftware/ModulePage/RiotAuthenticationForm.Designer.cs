namespace Aesoftware.ModulePage
{
    partial class RiotAuthenticationForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.regionComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.authenticationFormLoginButton = new System.Windows.Forms.Button();
            this.authenticationFormLoginNoAccountButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(90, 13);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(169, 20);
            this.usernameTextBox.TabIndex = 2;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(90, 41);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(169, 20);
            this.passwordTextBox.TabIndex = 3;
            // 
            // regionComboBox
            // 
            this.regionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.regionComboBox.FormattingEnabled = true;
            this.regionComboBox.Location = new System.Drawing.Point(90, 67);
            this.regionComboBox.Name = "regionComboBox";
            this.regionComboBox.Size = new System.Drawing.Size(83, 21);
            this.regionComboBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Region";
            // 
            // authenticationFormLoginButton
            // 
            this.authenticationFormLoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authenticationFormLoginButton.Location = new System.Drawing.Point(8, 94);
            this.authenticationFormLoginButton.Name = "authenticationFormLoginButton";
            this.authenticationFormLoginButton.Size = new System.Drawing.Size(129, 45);
            this.authenticationFormLoginButton.TabIndex = 6;
            this.authenticationFormLoginButton.Text = "Login";
            this.authenticationFormLoginButton.UseVisualStyleBackColor = true;
            this.authenticationFormLoginButton.Click += new System.EventHandler(this.authenticationFormLoginButton_Click);
            // 
            // authenticationFormLoginNoAccountButton
            // 
            this.authenticationFormLoginNoAccountButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authenticationFormLoginNoAccountButton.Location = new System.Drawing.Point(143, 94);
            this.authenticationFormLoginNoAccountButton.Name = "authenticationFormLoginNoAccountButton";
            this.authenticationFormLoginNoAccountButton.Size = new System.Drawing.Size(129, 45);
            this.authenticationFormLoginNoAccountButton.TabIndex = 7;
            this.authenticationFormLoginNoAccountButton.Text = "Login without credentials";
            this.authenticationFormLoginNoAccountButton.UseVisualStyleBackColor = true;
            this.authenticationFormLoginNoAccountButton.Click += new System.EventHandler(this.authenticationFormLoginNoAccountButton_Click);
            // 
            // RiotAuthenticationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 147);
            this.Controls.Add(this.authenticationFormLoginNoAccountButton);
            this.Controls.Add(this.authenticationFormLoginButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.regionComboBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RiotAuthenticationForm";
            this.Text = "Riot Authentication";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RiotAuthenticationForm_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.RiotAuthenticationForm_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.ComboBox regionComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button authenticationFormLoginButton;
        private System.Windows.Forms.Button authenticationFormLoginNoAccountButton;
    }
}