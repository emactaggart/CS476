namespace GameClient.Views
{
    partial class GameMenu
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
            this.LaunchButton = new System.Windows.Forms.Button();
            this.GameListBox = new System.Windows.Forms.GroupBox();
            this.TicTacToeRadio = new System.Windows.Forms.RadioButton();
            this.CheckersRadio = new System.Windows.Forms.RadioButton();
            this.ChessRadio = new System.Windows.Forms.RadioButton();
            this.GameListBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(201, 218);
            this.BackButton.Margin = new System.Windows.Forms.Padding(4);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(134, 55);
            this.BackButton.TabIndex = 1;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // LaunchButton
            // 
            this.LaunchButton.Location = new System.Drawing.Point(201, 151);
            this.LaunchButton.Margin = new System.Windows.Forms.Padding(4);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(134, 59);
            this.LaunchButton.TabIndex = 5;
            this.LaunchButton.Text = "Launch";
            this.LaunchButton.UseVisualStyleBackColor = true;
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // GameListBox
            // 
            this.GameListBox.Controls.Add(this.ChessRadio);
            this.GameListBox.Controls.Add(this.CheckersRadio);
            this.GameListBox.Controls.Add(this.TicTacToeRadio);
            this.GameListBox.Location = new System.Drawing.Point(171, 12);
            this.GameListBox.Name = "GameListBox";
            this.GameListBox.Size = new System.Drawing.Size(200, 132);
            this.GameListBox.TabIndex = 7;
            this.GameListBox.TabStop = false;
            // 
            // TicTacToeRadio
            // 
            this.TicTacToeRadio.AutoSize = true;
            this.TicTacToeRadio.Location = new System.Drawing.Point(48, 31);
            this.TicTacToeRadio.Name = "TicTacToeRadio";
            this.TicTacToeRadio.Size = new System.Drawing.Size(105, 21);
            this.TicTacToeRadio.TabIndex = 8;
            this.TicTacToeRadio.TabStop = true;
            this.TicTacToeRadio.Text = "Tic Tac Toe";
            this.TicTacToeRadio.UseVisualStyleBackColor = true;
            // 
            // CheckersRadio
            // 
            this.CheckersRadio.AutoSize = true;
            this.CheckersRadio.Location = new System.Drawing.Point(48, 58);
            this.CheckersRadio.Name = "CheckersRadio";
            this.CheckersRadio.Size = new System.Drawing.Size(88, 21);
            this.CheckersRadio.TabIndex = 9;
            this.CheckersRadio.TabStop = true;
            this.CheckersRadio.Text = "Checkers";
            this.CheckersRadio.UseVisualStyleBackColor = true;
            // 
            // ChessRadio
            // 
            this.ChessRadio.AutoSize = true;
            this.ChessRadio.Location = new System.Drawing.Point(48, 85);
            this.ChessRadio.Name = "ChessRadio";
            this.ChessRadio.Size = new System.Drawing.Size(68, 21);
            this.ChessRadio.TabIndex = 10;
            this.ChessRadio.TabStop = true;
            this.ChessRadio.Text = "Chess";
            this.ChessRadio.UseVisualStyleBackColor = true;
            // 
            // GameMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 321);
            this.Controls.Add(this.GameListBox);
            this.Controls.Add(this.LaunchButton);
            this.Controls.Add(this.BackButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GameMenu";
            this.Text = "Select a Game";
            this.Load += new System.EventHandler(this.GameMenu_Load);
            this.GameListBox.ResumeLayout(false);
            this.GameListBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button LaunchButton;
        private System.Windows.Forms.GroupBox GameListBox;
        private System.Windows.Forms.RadioButton TicTacToeRadio;
        private System.Windows.Forms.RadioButton ChessRadio;
        private System.Windows.Forms.RadioButton CheckersRadio;
    }
}