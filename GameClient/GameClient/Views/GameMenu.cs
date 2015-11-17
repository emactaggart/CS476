using GameClient.Server;
using GameClient.Utilities;
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
    public partial class GameMenu : Form
    {
        public GameMenu()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mainMenu = new MainMenu();
            mainMenu.ShowDialog();
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            try
            {
                GameType gameType;
                if (TicTacToeRadio.Checked)
                {
                    gameType = GameType.TicTacToe;
                }
                else if (CheckersRadio.Checked)
                {
                    //gameType = GameType.Checkers;
                    throw new GameNotImplementedException();
                }
                else if (ChessRadio.Checked)
                {
                    //gameType = GameType.Chess;
                    throw new GameNotImplementedException();
                }
                else
                {
                    throw new NoGameSelectedException();
                }

                this.Hide();
                //TODO: use factory when implementing other game types
                //var gamePage = gameFactory.create(gameType);
                var gamePage = new TicTacToePage();
                gamePage.ShowDialog();

            }
            catch (GameNotImplementedException)
            {
                MessageBox.Show("This game is not implemented yet!\nPlease select another game to play.");
            }
            catch (NoGameSelectedException)
            {
                MessageBox.Show("No game selected!\nPlease select a game to play.");
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

        private void GameMenu_Load(object sender, EventArgs e)
        {
            try
            {
                //Program.infoController.GetGameList();

                //foreach(var info in Program.infoController.gameList)
                //{
                //    var r = new RadioButton();
                //    r.Text = info.gameType.ToString();
                //    GameListBox.Controls.Add(r);
                //}
            }
            catch (FaultException<EmptyResultsFault>)
            {
                MessageBox.Show("No games available at this time.");
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
