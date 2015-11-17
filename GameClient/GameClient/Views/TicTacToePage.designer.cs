namespace GameClient.Views
{
    partial class TicTacToePage
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
            this.components = new System.ComponentModel.Container();
            this.QuitButton = new System.Windows.Forms.Button();
            this.BottomRightButton = new System.Windows.Forms.Button();
            this.BottomCenterButton = new System.Windows.Forms.Button();
            this.BottomLeftButton = new System.Windows.Forms.Button();
            this.MiddleRightButton = new System.Windows.Forms.Button();
            this.MiddleCenterButton = new System.Windows.Forms.Button();
            this.MiddleLeftButton = new System.Windows.Forms.Button();
            this.TopRightButton = new System.Windows.Forms.Button();
            this.TopCenterButton = new System.Windows.Forms.Button();
            this.TopLeftButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.GameStatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(194, 253);
            this.QuitButton.Margin = new System.Windows.Forms.Padding(4);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(134, 55);
            this.QuitButton.TabIndex = 1;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // BottomRightButton
            // 
            this.BottomRightButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BottomRightButton.Location = new System.Drawing.Point(288, 127);
            this.BottomRightButton.Name = "BottomRightButton";
            this.BottomRightButton.Size = new System.Drawing.Size(60, 58);
            this.BottomRightButton.TabIndex = 17;
            this.BottomRightButton.Click += new System.EventHandler(this.BottomRightButton_Click);
            // 
            // BottomCenterButton
            // 
            this.BottomCenterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BottomCenterButton.Location = new System.Drawing.Point(230, 127);
            this.BottomCenterButton.Name = "BottomCenterButton";
            this.BottomCenterButton.Size = new System.Drawing.Size(60, 58);
            this.BottomCenterButton.TabIndex = 16;
            this.BottomCenterButton.Click += new System.EventHandler(this.BottomCenterButton_Click);
            // 
            // BottomLeftButton
            // 
            this.BottomLeftButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BottomLeftButton.Location = new System.Drawing.Point(173, 127);
            this.BottomLeftButton.Name = "BottomLeftButton";
            this.BottomLeftButton.Size = new System.Drawing.Size(60, 58);
            this.BottomLeftButton.TabIndex = 15;
            this.BottomLeftButton.Click += new System.EventHandler(this.BottomLeftButton_Click);
            // 
            // MiddleRightButton
            // 
            this.MiddleRightButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MiddleRightButton.Location = new System.Drawing.Point(288, 72);
            this.MiddleRightButton.Name = "MiddleRightButton";
            this.MiddleRightButton.Size = new System.Drawing.Size(60, 58);
            this.MiddleRightButton.TabIndex = 14;
            this.MiddleRightButton.Click += new System.EventHandler(this.MiddleRightButton_Click);
            // 
            // MiddleCenterButton
            // 
            this.MiddleCenterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MiddleCenterButton.Location = new System.Drawing.Point(230, 72);
            this.MiddleCenterButton.Name = "MiddleCenterButton";
            this.MiddleCenterButton.Size = new System.Drawing.Size(60, 58);
            this.MiddleCenterButton.TabIndex = 13;
            this.MiddleCenterButton.Click += new System.EventHandler(this.MiddleCenterButton_Click);
            // 
            // MiddleLeftButton
            // 
            this.MiddleLeftButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MiddleLeftButton.Location = new System.Drawing.Point(173, 72);
            this.MiddleLeftButton.Name = "MiddleLeftButton";
            this.MiddleLeftButton.Size = new System.Drawing.Size(60, 58);
            this.MiddleLeftButton.TabIndex = 12;
            this.MiddleLeftButton.Click += new System.EventHandler(this.MiddleLeftButton_Click);
            // 
            // TopRightButton
            // 
            this.TopRightButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopRightButton.Location = new System.Drawing.Point(288, 16);
            this.TopRightButton.Name = "TopRightButton";
            this.TopRightButton.Size = new System.Drawing.Size(60, 58);
            this.TopRightButton.TabIndex = 11;
            this.TopRightButton.Click += new System.EventHandler(this.TopRightButton_Click);
            // 
            // TopCenterButton
            // 
            this.TopCenterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopCenterButton.Location = new System.Drawing.Point(230, 16);
            this.TopCenterButton.Name = "TopCenterButton";
            this.TopCenterButton.Size = new System.Drawing.Size(60, 58);
            this.TopCenterButton.TabIndex = 10;
            this.TopCenterButton.Click += new System.EventHandler(this.TopCenterButton_Click);
            // 
            // TopLeftButton
            // 
            this.TopLeftButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopLeftButton.Location = new System.Drawing.Point(173, 16);
            this.TopLeftButton.Name = "TopLeftButton";
            this.TopLeftButton.Size = new System.Drawing.Size(60, 58);
            this.TopLeftButton.TabIndex = 9;
            this.TopLeftButton.Click += new System.EventHandler(this.TopLeftButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(194, 192);
            this.BackButton.Margin = new System.Windows.Forms.Padding(4);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(134, 55);
            this.BackButton.TabIndex = 18;
            this.BackButton.Text = "Back to Main Menu";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Enabled = true;
            this.UpdateTimer.Interval = 500;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTime_Tick);
            // 
            // GameStatusLabel
            // 
            this.GameStatusLabel.AutoSize = true;
            this.GameStatusLabel.Location = new System.Drawing.Point(12, 16);
            this.GameStatusLabel.Name = "GameStatusLabel";
            this.GameStatusLabel.Size = new System.Drawing.Size(90, 17);
            this.GameStatusLabel.TabIndex = 19;
            this.GameStatusLabel.Text = "Game Status";
            // 
            // TicTacToePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 321);
            this.Controls.Add(this.GameStatusLabel);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.BottomRightButton);
            this.Controls.Add(this.BottomCenterButton);
            this.Controls.Add(this.BottomLeftButton);
            this.Controls.Add(this.MiddleRightButton);
            this.Controls.Add(this.MiddleCenterButton);
            this.Controls.Add(this.MiddleLeftButton);
            this.Controls.Add(this.TopRightButton);
            this.Controls.Add(this.TopCenterButton);
            this.Controls.Add(this.TopLeftButton);
            this.Controls.Add(this.QuitButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TicTacToePage";
            this.ShowIcon = false;
            this.Text = "Tic Tac Toe!";
            this.Load += new System.EventHandler(this.TicTacToePage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Button BottomRightButton;
        private System.Windows.Forms.Button BottomCenterButton;
        private System.Windows.Forms.Button BottomLeftButton;
        private System.Windows.Forms.Button MiddleRightButton;
        private System.Windows.Forms.Button MiddleCenterButton;
        private System.Windows.Forms.Button MiddleLeftButton;
        private System.Windows.Forms.Button TopRightButton;
        private System.Windows.Forms.Button TopCenterButton;
        private System.Windows.Forms.Button TopLeftButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.Label GameStatusLabel;
    }
}