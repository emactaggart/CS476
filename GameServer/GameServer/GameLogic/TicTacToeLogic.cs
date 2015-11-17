using GameServer.Models;
using GameServer.Models.TicTacToe;
using GameServer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.GameLogic
{
    public static class TicTacToeLogic
    {
        public static MatchState CalculateNextState(MatchState currentState, Guid playerId, MovePosition move)
        {
            var nextState = currentState;
            if (nextState.operationState == GameOperationState.Completed)
            {
                throw new GameIsOverException();
            }

            if (nextState.playerTurnId != playerId)
            {
                throw new NotPlayersTurnException();
            } 
        
            if (nextState.inGameState.board[(int)move] != PlayerMark.Empty)
            {
                throw new InvalidPlayerMoveException();
            }

            if (playerId == nextState.inGameState.firstPlayer)
            {
                nextState.inGameState.board[(int)move] = PlayerMark.X;
            }
            else
            {
                nextState.inGameState.board[(int)move] = PlayerMark.O;
            }

            if (DoesGameHaveWinner(nextState.inGameState))
            {
                nextState.playerTurnId = Guid.Empty;
                nextState.winnerId = playerId;
                nextState.gameEndTime = DateTime.Now;
                nextState.operationState = GameOperationState.Completed;
            }
            else if (IsGameTie(nextState.inGameState))
            {
                nextState.playerTurnId = Guid.Empty;
                nextState.winnerId = Guid.Empty;
                nextState.gameEndTime = DateTime.Now;
                nextState.operationState = GameOperationState.Completed;
            }
            else
            {
                nextState.playerTurnId = AlternateTurn(nextState);
            }

            return nextState;
        }

        public static Guid AlternateTurn(MatchState currentState)
        {
            var turn = Guid.Empty;
            if (currentState.playerTurnId == currentState.inGameState.firstPlayer)
            {
                turn = currentState.inGameState.secondPlayer;
            }
            else
            {
                turn = currentState.inGameState.firstPlayer;
            }
            return turn;
        }

        public static bool IsLineAllEqual(List<PlayerMark> board, MovePosition first, MovePosition second, MovePosition third)
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

        public static bool IsGameOver(TicTacToeState state)
        {
            bool gameOver = DoesGameHaveWinner(state) || IsBoardFull(state);
            return gameOver;
        }

        public static bool IsGameTie(TicTacToeState state)
        {
            var isTie = IsBoardFull(state) && !DoesGameHaveWinner(state);
            return isTie;
        }

        public static bool DoesGameHaveWinner(TicTacToeState state)
        {
            var board = state.board;
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

            bool hasWinner = winningLines.Any( x => IsLineAllEqual(board, x[0], x[1], x[2]));
            return hasWinner;
        }

        public static bool IsBoardFull(TicTacToeState state)
        {
            var isFull = state.board.All(x => x != PlayerMark.Empty);
            return isFull;
        }

        public static MovePosition GetRandomPlayerMove()
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
