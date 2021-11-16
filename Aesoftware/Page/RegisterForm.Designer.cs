namespace Aesoftware.Page
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.RegisterUsernameTextBox = new System.Windows.Forms.TextBox();
            this.RegisterUsernameLabel = new System.Windows.Forms.Label();
            this.RegisterPasswordTextBox = new System.Windows.Forms.TextBox();
            this.RegisterPasswordLabel = new System.Windows.Forms.Label();
            this.RegisterEmailLabel = new System.Windows.Forms.Label();
            this.RegisterEmailTextBox = new System.Windows.Forms.TextBox();
            this.RegisterInvitationCodeLabel = new System.Windows.Forms.Label();
            this.RegisterInvitationCodeTextbox = new System.Windows.Forms.TextBox();
            this.RegisterRegisterButton = new System.Windows.Forms.Button();
            this.RegisterCloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RegisterUsernameTextBox
            // 
            this.RegisterUsernameTextBox.Location = new System.Drawing.Point(25, 25);
            this.RegisterUsernameTextBox.Name = "RegisterUsernameTextBox";
            this.RegisterUsernameTextBox.Size = new System.Drawing.Size(161, 20);
            this.RegisterUsernameTextBox.TabIndex = 0;
            // 
            // RegisterUsernameLabel
            // 
            this.RegisterUsernameLabel.AutoSize = true;
            this.RegisterUsernameLabel.Location = new System.Drawing.Point(22, 9);
            this.RegisterUsernameLabel.Name = "RegisterUsernameLabel";
            this.RegisterUsernameLabel.Size = new System.Drawing.Size(55, 13);
            this.RegisterUsernameLabel.TabIndex = 1;
            this.RegisterUsernameLabel.Text = "Username";
            // 
            // RegisterPasswordTextBox
            // 
            this.RegisterPasswordTextBox.Location = new System.Drawing.Point(25, 64);
            this.RegisterPasswordTextBox.Name = "RegisterPasswordTextBox";
            this.RegisterPasswordTextBox.Size = new System.Drawing.Size(161, 20);
            this.RegisterPasswordTextBox.TabIndex = 2;
            // 
            // RegisterPasswordLabel
            // 
            this.RegisterPasswordLabel.AutoSize = true;
            this.RegisterPasswordLabel.Location = new System.Drawing.Point(22, 48);
            this.RegisterPasswordLabel.Name = "RegisterPasswordLabel";
            this.RegisterPasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.RegisterPasswordLabel.TabIndex = 3;
            this.RegisterPasswordLabel.Text = "Password";
            // 
            // RegisterEmailLabel
            // 
            this.RegisterEmailLabel.AutoSize = true;
            this.RegisterEmailLabel.Location = new System.Drawing.Point(24, 87);
            this.RegisterEmailLabel.Name = "RegisterEmailLabel";
            this.RegisterEmailLabel.Size = new System.Drawing.Size(32, 13);
            this.RegisterEmailLabel.TabIndex = 4;
            this.RegisterEmailLabel.Text = "Email";
            // 
            // RegisterEmailTextBox
            // 
            this.RegisterEmailTextBox.Location = new System.Drawing.Point(25, 103);
            this.RegisterEmailTextBox.Name = "RegisterEmailTextBox";
            this.RegisterEmailTextBox.Size = new System.Drawing.Size(161, 20);
            this.RegisterEmailTextBox.TabIndex = 5;
            // 
            // RegisterInvitationCodeLabel
            // 
            this.RegisterInvitationCodeLabel.AutoSize = true;
            this.RegisterInvitationCodeLabel.Location = new System.Drawing.Point(24, 126);
            this.RegisterInvitationCodeLabel.Name = "RegisterInvitationCodeLabel";
            this.RegisterInvitationCodeLabel.Size = new System.Drawing.Size(78, 13);
            this.RegisterInvitationCodeLabel.TabIndex = 6;
            this.RegisterInvitationCodeLabel.Text = "Invitation Code";
            // 
            // RegisterInvitationCodeTextbox
            // 
            this.RegisterInvitationCodeTextbox.Location = new System.Drawing.Point(27, 142);
            this.RegisterInvitationCodeTextbox.Name = "RegisterInvitationCodeTextbox";
            this.RegisterInvitationCodeTextbox.Size = new System.Drawing.Size(161, 20);
            this.RegisterInvitationCodeTextbox.TabIndex = 7;
            // 
            // RegisterRegisterButton
            // 
            this.RegisterRegisterButton.Location = new System.Drawing.Point(27, 181);
            this.RegisterRegisterButton.Name = "RegisterRegisterButton";
            this.RegisterRegisterButton.Size = new System.Drawing.Size(75, 29);
            this.RegisterRegisterButton.TabIndex = 8;
            this.RegisterRegisterButton.Text = "Register";
            this.RegisterRegisterButton.UseVisualStyleBackColor = true;
            this.RegisterRegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // RegisterCloseButton
            // 
            this.RegisterCloseButton.Location = new System.Drawing.Point(113, 181);
            this.RegisterCloseButton.Name = "RegisterCloseButton";
            this.RegisterCloseButton.Size = new System.Drawing.Size(75, 29);
            this.RegisterCloseButton.TabIndex = 9;
            this.RegisterCloseButton.Text = "Close";
            this.RegisterCloseButton.UseVisualStyleBackColor = true;
            this.RegisterCloseButton.Click += new System.EventHandler(this.RegisterCloseButton_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 222);
            this.ControlBox = false;
            this.Controls.Add(this.RegisterCloseButton);
            this.Controls.Add(this.RegisterRegisterButton);
            this.Controls.Add(this.RegisterInvitationCodeTextbox);
            this.Controls.Add(this.RegisterInvitationCodeLabel);
            this.Controls.Add(this.RegisterEmailTextBox);
            this.Controls.Add(this.RegisterEmailLabel);
            this.Controls.Add(this.RegisterPasswordLabel);
            this.Controls.Add(this.RegisterPasswordTextBox);
            this.Controls.Add(this.RegisterUsernameLabel);
            this.Controls.Add(this.RegisterUsernameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterForm";
            this.Text = "Register";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegisterForm_FormClosing);
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox RegisterUsernameTextBox;
        private System.Windows.Forms.Label RegisterUsernameLabel;
        private System.Windows.Forms.TextBox RegisterPasswordTextBox;
        private System.Windows.Forms.Label RegisterPasswordLabel;
        private System.Windows.Forms.Label RegisterEmailLabel;
        private System.Windows.Forms.TextBox RegisterEmailTextBox;
        private System.Windows.Forms.Label RegisterInvitationCodeLabel;
        private System.Windows.Forms.TextBox RegisterInvitationCodeTextbox;
        private System.Windows.Forms.Button RegisterRegisterButton;
        private System.Windows.Forms.Button RegisterCloseButton;
    }
}