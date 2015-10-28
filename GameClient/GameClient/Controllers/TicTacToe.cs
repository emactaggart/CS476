using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient.Controllers
{

    public enum PlayerMark
    {
        Empty, X, O
    }

    public enum MovePosition
    {
        TopLeft, TopCenter, TopRight,
        MiddleLeft, MiddleCenter, MiddleRight,
        BottomLeft, BottomCenter, BottomRight
    }

    public enum PlayerTurn
    {
        First, Second
    }

    class Player
    {
        public string name;
        public PlayerMark mark;

        public Player(string name, PlayerMark mark)
        {
            this.name = name;
            this.mark = mark;
        }
    }

    class TicTacToe
    {
        private Player player1;
        private Player player2;
        private List<PlayerMark> board;
        public PlayerTurn turn { private set; get; }

        public TicTacToe(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            turn = PlayerTurn.First;
            board = new List<PlayerMark> {
                Controllers.PlayerMark.Empty, Controllers.PlayerMark.Empty, Controllers.PlayerMark.Empty,
                Controllers.PlayerMark.Empty, Controllers.PlayerMark.Empty, Controllers.PlayerMark.Empty,
                Controllers.PlayerMark.Empty, Controllers.PlayerMark.Empty, Controllers.PlayerMark.Empty,
            };
        }

        public bool PlayerExecuteMove(Player player, MovePosition move)
        {
            int position = (int)move;
            if (board[position] == Controllers.PlayerMark.Empty)
            {
                board[position] = player.mark;
                AlternatePlayerTurn();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PlayerMove(Player player, MovePosition move)
        {
            bool isSuccessfulMove = false;
            if (turn == PlayerTurn.First && player == player1)
            {
                isSuccessfulMove = PlayerExecuteMove(player, move);
            }
            else if (turn == PlayerTurn.Second && player == player2)
            {
                isSuccessfulMove = PlayerExecuteMove(player, move);
            }
            else
            {
                //invalid player
            }

            return isSuccessfulMove;
        }

        public void AlternatePlayerTurn()
        {
            if (turn == PlayerTurn.First)
            {
                turn = PlayerTurn.Second;
            }
            if (turn == PlayerTurn.Second)
            {
                turn = PlayerTurn.First;
            }
        }

        public bool IsGameOver()
        {
            var winningLines = new List<List<MovePosition>>
            {
                new List<MovePosition> { MovePosition.TopLeft, MovePosition.TopCenter, MovePosition.TopRight },
                new List<MovePosition> { MovePosition.MiddleLeft, MovePosition.MiddleCenter, MovePosition.MiddleRight },
                new List<MovePosition> { MovePosition.BottomLeft, MovePosition.BottomCenter, MovePosition.BottomRight },
                new List<MovePosition> { MovePosition.TopLeft, MovePosition.MiddleLeft, MovePosition.BottomLeft },
                new List<MovePosition> { MovePosition.TopCenter, MovePosition.MiddleCenter, MovePosition.BottomCenter },
                new List<MovePosition> { MovePosition.TopRight, MovePosition.MiddleRight, MovePosition.BottomRight },
                new List<MovePosition> { MovePosition.TopLeft, MovePosition.MiddleCenter, MovePosition.BottomRight },
                new List<MovePosition> { MovePosition.BottomLeft, MovePosition.MiddleCenter, MovePosition.TopRight },
            };

            bool gameOver = winningLines.Any( x => IsLineAllEqual(x[0], x[1], x[2]));
            return gameOver;
        }

        public bool IsLineAllEqual(MovePosition first, MovePosition second, MovePosition third)
        {
            if (board.ElementAt((int)first) == PlayerMark.Empty)
            {
                return false;
            }
            var line = new List<MovePosition> { first, second, third };
            if (line.All(x => board.ElementAt((int)first) == board.ElementAt((int)x)))
            {
                return true;
            }
            return false;
        }
    }

    public class Match
    {
        public Match()
        {
            var player1 = new Player("Player 1", PlayerMark.X);
            var player2 = new Player("Player 2", PlayerMark.O);
            var game = new TicTacToe(player1, player2);
            var player1Move = MovePosition.BottomCenter;
            var player2Move = MovePosition.BottomCenter;

            while (!game.IsGameOver())
            {
                if (game.turn == PlayerTurn.First)
                {
                    while (game.turn == PlayerTurn.First)
                    {
                        player1Move = GetRandomPlayerMove();
                        game.PlayerMove(player1, player1Move);
                    }
                }
                else
                {
                    while (game.turn == PlayerTurn.Second)
                    {
                        player2Move = GetRandomPlayerMove();
                        game.PlayerMove(player2, player2Move);
                    }
                }
            }
        }

        public MovePosition GetRandomPlayerMove()
        {
            var possibleMoves = new List<MovePosition> { MovePosition.TopLeft, MovePosition.TopCenter, MovePosition.TopRight,
                MovePosition.MiddleLeft, MovePosition.MiddleCenter, MovePosition.MiddleRight,
                MovePosition.BottomLeft, MovePosition.BottomCenter, MovePosition.BottomRight };
            var random = new Random(possibleMoves.Count());
            var move = possibleMoves.ElementAt(random.Next());
            return move;
        }
    }
}
