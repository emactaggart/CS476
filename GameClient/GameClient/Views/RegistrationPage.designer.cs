namespace GameClient.Views
{
    partial class RegistrationPage
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
            this.UsernameField = new System.Windows.Forms.TextBox();
            this.PasswordField = new System.Windows.Forms.TextBox();
            this.PasswordConfirmationField = new System.Windows.Forms.TextBox();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UsernameField
            // 
            this.UsernameField.Location = new System.Drawing.Point(99, 58);
            this.UsernameField.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UsernameField.Name = "UsernameField";
            this.UsernameField.Size = new System.Drawing.Size(132, 22);
            this.UsernameField.TabIndex = 0;
            this.UsernameField.Text = "Username";
            // 
            // PasswordField
            // 
            this.PasswordField.Location = new System.Drawing.Point(99, 90);
            this.PasswordField.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PasswordField.Name = "PasswordField";
            this.PasswordField.Size = new System.Drawing.Size(132, 22);
            this.PasswordField.TabIndex = 1;
            this.PasswordField.Text = "Password";
            // 
            // PasswordConfirmationField
            // 
            this.PasswordConfirmationField.Location = new System.Drawing.Point(99, 122);
            this.PasswordConfirmationField.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PasswordConfirmationField.Name = "PasswordConfirmationField";
            this.PasswordConfirmationField.Size = new System.Drawing.Size(132, 22);
            this.PasswordConfirmationField.TabIndex = 2;
            this.PasswordConfirmationField.Text = "Confirm Password";
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(99, 171);
            this.RegisterButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(132, 52);
            this.RegisterButton.TabIndex = 3;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(99, 231);
            this.BackButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(132, 52);
            this.BackButton.TabIndex = 4;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // RegistrationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 321);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.PasswordConfirmationField);
            this.Controls.Add(this.PasswordField);
            this.Controls.Add(this.UsernameField);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RegistrationPage";
            this.Text = "Register an Account!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UsernameField;
        private System.Windows.Forms.TextBox PasswordField;
        private System.Windows.Forms.TextBox PasswordConfirmationField;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Button BackButton;
    }
}