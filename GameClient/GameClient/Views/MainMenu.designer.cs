namespace GameClient.Views
{
    partial class MainMenu
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
            this.LogoutButton = new System.Windows.Forms.Button();
            this.StatsButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogoutButton
            // 
            this.LogoutButton.Location = new System.Drawing.Point(179, 167);
            this.LogoutButton.Margin = new System.Windows.Forms.Padding(4);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(168, 49);
            this.LogoutButton.TabIndex = 1;
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.UseVisualStyleBackColor = true;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // StatsButton
            // 
            this.StatsButton.Location = new System.Drawing.Point(179, 111);
            this.StatsButton.Name = "StatsButton";
            this.StatsButton.Size = new System.Drawing.Size(168, 49);
            this.StatsButton.TabIndex = 2;
            this.StatsButton.Text = "Check Stats";
            this.StatsButton.UseVisualStyleBackColor = true;
            this.StatsButton.Click += new System.EventHandler(this.StatsButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(179, 55);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(168, 50);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "Start Game";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 321);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.StatsButton);
            this.Controls.Add(this.LogoutButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.Button StatsButton;
        private System.Windows.Forms.Button StartButton;
    }
}