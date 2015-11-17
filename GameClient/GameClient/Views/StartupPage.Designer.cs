namespace GameClient.Views 
{
    partial class StartupPage
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
            this.LoginButton = new System.Windows.Forms.Button();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.GuestButton = new System.Windows.Forms.Button();
            this.UsernameField = new System.Windows.Forms.TextBox();
            this.PasswordField = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(116, 138);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(4);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(175, 65);
            this.LoginButton.TabIndex = 0;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(116, 211);
            this.RegisterButton.Margin = new System.Windows.Forms.Padding(4);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(175, 65);
            this.RegisterButton.TabIndex = 1;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // GuestButton
            // 
            this.GuestButton.Location = new System.Drawing.Point(116, 284);
            this.GuestButton.Margin = new System.Windows.Forms.Padding(4);
            this.GuestButton.Name = "GuestButton";
            this.GuestButton.Size = new System.Drawing.Size(175, 69);
            this.GuestButton.TabIndex = 2;
            this.GuestButton.Text = "Play as Guest";
            this.GuestButton.UseVisualStyleBackColor = true;
            this.GuestButton.Click += new System.EventHandler(this.GuestButton_Click);
            // 
            // UsernameField
            // 
            this.UsernameField.Location = new System.Drawing.Point(116, 61);
            this.UsernameField.Margin = new System.Windows.Forms.Padding(4);
            this.UsernameField.Name = "UsernameField";
            this.UsernameField.Size = new System.Drawing.Size(175, 22);
            this.UsernameField.TabIndex = 3;
            this.UsernameField.Text = "UserName";
            // 
            // PasswordField
            // 
            this.PasswordField.Location = new System.Drawing.Point(116, 91);
            this.PasswordField.Margin = new System.Windows.Forms.Padding(4);
            this.PasswordField.Name = "PasswordField";
            this.PasswordField.Size = new System.Drawing.Size(175, 22);
            this.PasswordField.TabIndex = 4;
            this.PasswordField.Text = "Password";
            // 
            // StartupPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 419);
            this.Controls.Add(this.PasswordField);
            this.Controls.Add(this.UsernameField);
            this.Controls.Add(this.GuestButton);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.LoginButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StartupPage";
            this.Text = "Welcome to Multi Mini Games!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Button GuestButton;
        private System.Windows.Forms.TextBox UsernameField;
        private System.Windows.Forms.TextBox PasswordField;
    }
}