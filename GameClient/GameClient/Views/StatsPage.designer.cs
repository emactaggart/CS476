namespace GameClient.Views
{
    partial class StatsPage
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
            this.BackButton = new System.Windows.Forms.Button();
            this.TotalGamesLabel = new System.Windows.Forms.Label();
            this.WinsLabel = new System.Windows.Forms.Label();
            this.LossesLabel = new System.Windows.Forms.Label();
            this.WinLossRatioLabel = new System.Windows.Forms.Label();
            this.PlayerIdLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(152, 227);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(183, 56);
            this.BackButton.TabIndex = 0;
            this.BackButton.Text = "Back to Main Menu";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // TotalGamesLabel
            // 
            this.TotalGamesLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TotalGamesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TotalGamesLabel.Location = new System.Drawing.Point(141, 39);
            this.TotalGamesLabel.Name = "TotalGamesLabel";
            this.TotalGamesLabel.Size = new System.Drawing.Size(213, 27);
            this.TotalGamesLabel.TabIndex = 2;
            this.TotalGamesLabel.Text = "TotalGames";
            // 
            // WinsLabel
            // 
            this.WinsLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.WinsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WinsLabel.Location = new System.Drawing.Point(141, 66);
            this.WinsLabel.Name = "WinsLabel";
            this.WinsLabel.Size = new System.Drawing.Size(213, 27);
            this.WinsLabel.TabIndex = 3;
            this.WinsLabel.Text = "Wins";
            // 
            // LossesLabel
            // 
            this.LossesLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.LossesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LossesLabel.Location = new System.Drawing.Point(141, 93);
            this.LossesLabel.Name = "LossesLabel";
            this.LossesLabel.Size = new System.Drawing.Size(213, 27);
            this.LossesLabel.TabIndex = 4;
            this.LossesLabel.Text = "Losses";
            // 
            // WinLossRatioLabel
            // 
            this.WinLossRatioLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.WinLossRatioLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WinLossRatioLabel.Location = new System.Drawing.Point(141, 120);
            this.WinLossRatioLabel.Name = "WinLossRatioLabel";
            this.WinLossRatioLabel.Size = new System.Drawing.Size(213, 27);
            this.WinLossRatioLabel.TabIndex = 5;
            this.WinLossRatioLabel.Text = "Win Loss Ratio";
            // 
            // PlayerIdLabel
            // 
            this.PlayerIdLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PlayerIdLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlayerIdLabel.Location = new System.Drawing.Point(141, 12);
            this.PlayerIdLabel.Name = "PlayerIdLabel";
            this.PlayerIdLabel.Size = new System.Drawing.Size(213, 27);
            this.PlayerIdLabel.TabIndex = 6;
            this.PlayerIdLabel.Text = "PlayerId";
            // 
            // StatsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 321);
            this.Controls.Add(this.PlayerIdLabel);
            this.Controls.Add(this.WinLossRatioLabel);
            this.Controls.Add(this.LossesLabel);
            this.Controls.Add(this.WinsLabel);
            this.Controls.Add(this.TotalGamesLabel);
            this.Controls.Add(this.BackButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StatsPage";
            this.Text = "Your Game Stats";
            this.Load += new System.EventHandler(this.StatsPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label TotalGamesLabel;
        private System.Windows.Forms.Label WinsLabel;
        private System.Windows.Forms.Label LossesLabel;
        private System.Windows.Forms.Label WinLossRatioLabel;
        private System.Windows.Forms.Label PlayerIdLabel;
    }
}