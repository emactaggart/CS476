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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var gamePage = new GameMenu();
            gamePage.ShowDialog();
        }

        private void StatsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var statsPage = new StatsPage();
            statsPage.ShowDialog();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            try
            {
                Program.infoController.LogoutPlayer(Program.infoController.profile.id);
                this.Hide();
                var startupPage = new StartupPage();
                startupPage.ShowDialog();
            }
            catch (CommunicationException)
            {
                MessageBox.Show("Unable to connect to server!\nPlease try again Later.");
                this.Hide();
                var startupPage = new StartupPage();
                startupPage.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unforseen error!, " + ex.Message);
                this.Hide();
                var startupPage = new StartupPage();
                startupPage.ShowDialog();
            }
        }
    }
}
