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
    public partial class TicTacToePage : Form
    {
        private BasicObserver<MatchState> _state;
        private bool _gameOver;

        public TicTacToePage()
        {
            InitializeComponent();
            _state = new BasicObserver<MatchState>();
            BackButton.Hide();
            _gameOver = false;
        }

        private void TicTacToePage_Load(object sender, EventArgs e)
        {
            try
            {
                Program.gameController.JoinGame(GameType.TicTacToe, Program.infoController.profile.id);
                _state.Subscribe(Program.gameController.gameState);
            }
            catch (CommunicationException)
            {
                UpdateTimer.Enabled = false;
                MessageBox.Show("Unable to connect to server!\nPlease try again Later.");
                BackButton.Show();
            }
            catch (Exception ex)
            {
                UpdateTimer.Enabled = false;
                MessageBox.Show("Unforseen error!, " + ex.Message);
                BackButton.Show();
            }
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            try
            {
                Program.gameController.QuitGame(_state.GetValue().id, Program.infoController.profile.id);
                ExitGame();
            }
            catch (FaultException<PlayerNotInSpecifiedGameFault>)
            {
                UpdateTimer.Enabled = false;
                MessageBox.Show("Player not in specified game!");
                ExitGame();
            }
            catch (FaultException<EmptyResultsFault>)
            {
                UpdateTimer.Enabled = false;
                MessageBox.Show("Game is not available!");
                ExitGame();
            }
            catch (CommunicationException)
            {
                UpdateTimer.Enabled = false;
                MessageBox.Show("Unable to connect to server!\nPlease try again Later.");
                BackButton.Show();
            }
            catch (Exception ex)
            {
                UpdateTimer.Enabled = false;
                MessageBox.Show("Unforseen error!, " + ex.Message);
                BackButton.Show();
            }
        }

        private void PlayerMove(MovePosition move)
        {
            try
            {
                Program.gameController.PlayerMove(
                    _state.GetValue().id,
                    Program.infoController.profile.id,
                    move);
            }
            catch (FaultException<WaitingForPlayersFault>)
            {
                MessageBox.Show("Waiting for an opponent!");
            }
            catch (FaultException<GameIsOverFault>)
            {
                UpdateTimer.Enabled = false;
                MessageBox.Show("Game is over!");
                BackButton.Show();
            }
            catch (FaultException<PlayerNotInSpecifiedGameFault>)
            {
                UpdateTimer.Enabled = false;
                MessageBox.Show("Not in game!");
                ExitGame();
            }
            catch (FaultException<NotPlayersTurnFault>)
            {
                MessageBox.Show("Not Your Turn!");
            }
            catch (FaultException<InvalidPlayerMoveFault>)
            {
                MessageBox.Show("Bad Move!");
            }
            catch (FaultException<EmptyResultsFault>)
            {
                UpdateTimer.Enabled = false;
                MessageBox.Show("Game not found!");
                ExitGame();
            }
            catch (CommunicationException)
            {
                UpdateTimer.Enabled = false;
                MessageBox.Show("Unable to connect to server!\nPlease try again Later.");
                BackButton.Show();
            }
            catch (Exception ex)
            {
                UpdateTimer.Enabled = false;
                MessageBox.Show("Unforseen error!, " + ex.Message);
                BackButton.Show();
            }
        }

        private void TopLeftButton_Click(object sender, EventArgs e)
        {
            PlayerMove(MovePosition.TopLeft);
        }

        private void TopCenterButton_Click(object sender, EventArgs e)
        {
            PlayerMove(MovePosition.TopCenter);
        }

        private void TopRightButton_Click(object sender, EventArgs e)
        {
            PlayerMove(MovePosition.TopRight);
        }

        private void MiddleLeftButton_Click(object sender, EventArgs e)
        {
            PlayerMove(MovePosition.MiddleLeft);
        }

        private void MiddleCenterButton_Click(object sender, EventArgs e)
        {
            PlayerMove(MovePosition.MiddleCenter);
        }

        private void MiddleRightButton_Click(object sender, EventArgs e)
        {
            PlayerMove(MovePosition.MiddleRight);
        }

        private void BottomLeftButton_Click(object sender, EventArgs e)
        {
            PlayerMove(MovePosition.BottomLeft);
        }

        private void BottomCenterButton_Click(object sender, EventArgs e)
        {
            PlayerMove(MovePosition.BottomCenter);
        }

        private void BottomRightButton_Click(object sender, EventArgs e)
        {
            PlayerMove(MovePosition.BottomRight);
        }

        private void UpdateState()
        {
            try
            {
                Program.gameController.UpdateMatchState(_state.GetValue().id);
            }
            catch (FaultException<EmptyResultsFault>)
            {
                MessageBox.Show("Empty Results!");
                ExitGame();
            }
            catch (CommunicationException)
            {
                UpdateTimer.Enabled = false;
                MessageBox.Show("Unable to connect to server!\nPlease try again Later.");
                BackButton.Show();
            }
            catch (Exception ex)
            {
                UpdateTimer.Enabled = false;
                MessageBox.Show("Unforseen error!, " + ex.Message);
                BackButton.Show();
            }
        }

        private void UpdateView()
        {
            if (_gameOver)
            {
                return;
            }

            UpdateState();
            var match = _state.GetValue();

            if (match.operationState == GameOperationState.WaitingForPlayers)
            {
                GameStatusLabel.Text = "Waiting for an opponent.";
            }
            else if (match.playerTurnId == Program.infoController.profile.id)
            {
                GameStatusLabel.Text = "Your Turn.";
            }
            else
            {
                GameStatusLabel.Text = "Opponents Turn.";
            }

            var board = new List<Button> 
            {
                TopLeftButton, TopCenterButton, TopRightButton,
                MiddleLeftButton, MiddleCenterButton, MiddleRightButton,
                BottomLeftButton, BottomCenterButton, BottomRightButton,
            };

            for (int i = 0; i < 9; i++)
            {
                var mark = match.inGameState.board[i];
                if (mark == PlayerMark.X)
                {
                    board[i].Text = "X";
                } 
                else if (mark == PlayerMark.O)
                {
                    board[i].Text = "O";
                }
            }

            if (match.operationState == GameOperationState.Completed)
            {
                _gameOver = true;
                UpdateTimer.Enabled = false;
                QuitButton.Hide();
                if (match.winnerId == Program.infoController.profile.id)
                {
                    MessageBox.Show("Congratulations you won!");
                    GameStatusLabel.Text = "You Won!";
                }
                else
                {
                    MessageBox.Show("Congratulations you lost!");
                    GameStatusLabel.Text = "You Lost!";
                }
                BackButton.Show();
                _state.Dispose();
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            ExitGame();
        }

        private void UpdateTime_Tick(object sender, EventArgs e)
        {
            UpdateView();
        }

        private void ExitGame()
        {
            Dispose();
            UpdateTimer.Enabled = false;
            _state = new BasicObserver<MatchState>();
            _gameOver = false;
            var mainMenu = new MainMenu();
            mainMenu.ShowDialog();
        }
   }
}
