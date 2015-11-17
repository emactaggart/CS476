using GameClient.Server;
using GameClient.Utilities;
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
    public partial class RegistrationPage : Form
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            try
            {
                var username = this.UsernameField.Text;
                var password = this.PasswordField.Text;
                var confirm = this.PasswordConfirmationField.Text;
                if (password != confirm)
                {
                    throw new InvalidPasswordException();
                }

                Program.infoController.CreateAccount(username, password);
                MessageBox.Show("Successfully register! Now just sign in.");
                this.Hide();
                var startupPage = new StartupPage();
                startupPage.ShowDialog();
            }
            catch (InvalidPasswordException)
            {
                MessageBox.Show("Your passwords do not match!");
            }
            catch (FaultException<UsernameAlreadyExistsFault>)
            {
                MessageBox.Show("That username already exists! Try a different one.");
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

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var startupPage = new StartupPage();
            startupPage.ShowDialog();
        }
    }
}
