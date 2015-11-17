using GameClient.Controllers;
using GameClient.Server;
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
    public partial class StartupPage : Form
    {
        public StartupPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                var username = this.UsernameField.Text;
                var password = this.PasswordField.Text;
                Program.infoController.LoginPlayer(username, password);
                this.Hide();
                var mainPage = new MainMenu();
                mainPage.ShowDialog();
            }
            catch (FaultException<InvalidUsernameFault>)
            {
                MessageBox.Show("Invalid username.");
            }
            catch (FaultException<InvalidPasswordFault>)
            { 
                MessageBox.Show("Invalid password.");
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

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var registerPage = new RegistrationPage();
            registerPage.ShowDialog();
        }

        private void GuestButton_Click(object sender, EventArgs e)
        {
            try {
                Program.infoController.LoginGuest();
                this.Hide();
                var mainPage = new MainMenu();
                mainPage.ShowDialog();
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
