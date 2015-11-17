using GameClient.Server;
using GameClient.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClient.Views 
{
    public partial class StatsPage : Form
    {
        public StatsPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mainMenu = new MainMenu();
            mainMenu.ShowDialog();
        }

        private void StatsPage_Load(object sender, EventArgs e)
        {
            try
            {
                Program.infoController.GetPlayerStats();
                var stats = Program.infoController.stats;
                Text = Program.infoController.profile.username + "'s Game Stats";
                PlayerIdLabel.Text = stats.playerId.ToString();
                TotalGamesLabel.Text = "Total Games: " + stats.totalGames.ToString();
                WinsLabel.Text = "Total Wins: " + stats.totalWins.ToString();
                LossesLabel.Text = "Total Losses: " + stats.totalLosses.ToString();
                WinLossRatioLabel.Text = "Win Loss Ratio: " + stats.winLossRatio.ToString();
            }
            catch (FaultException<EmptyResultsFault>)
            {
                MessageBox.Show("No stats available at this time.");
            }
            catch (CommunicationException)
            {
                MessageBox.Show("Unable to connect to server!\nPlease try again Later.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unforseen error!, " + ex.Message);
            }
        }
    }
}
