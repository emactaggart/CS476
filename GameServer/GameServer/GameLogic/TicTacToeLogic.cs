using GameServer.Models;
using GameServer.Models.TicTacToe;
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

            if (currentState.operationState == GameOperationState.Completed)
            {
                //game is over
                throw new Exception();
            }

            if (currentState.playerTurnId != playerId)
            {
                //not your turn
                throw new Exception();
            } 
        
            if (currentState.inGameState.board[(int)move] != PlayerMark.Empty)
            {
                //board position not empty, invalid move
                throw new Exception();
            }

            //place move in location
            if (playerId == currentState.inGameState.firstPlayer)
            {
                currentState.inGameState.board[(int)move] = PlayerMark.X;       //fix this
            }
            else
            {
                currentState.inGameState.board[(int)move] = PlayerMark.O;       //fix this
            }


            if (IsGameTie(currentState.inGameState))
            {
                currentState.winnerId = Guid.Empty;
                //set gameendtime
                currentState.gameEndTime = DateTime.Now;
                //set operationstate to completed
                currentState.operationState = GameOperationState.Completed;
            } 
            else if (IsGameOver(currentState.inGameState))
            {
                currentState.winnerId = playerId;
                //set gameendtime
                currentState.gameEndTime = DateTime.Now;
                //set operationstate to completed
                currentState.operationState = GameOperationState.Completed;
            }
            else
            {
                //else change player turn
                if (currentState.playerTurnId == currentState.inGameState.firstPlayer)
                {
                    currentState.playerTurnId = currentState.inGameState.secondPlayer;
                }
                else
                {
                    currentState.playerTurnId = currentState.inGameState.firstPlayer;
                }
            }
            return currentState;
        }

        public static bool IsGameOver(TicTacToeState state)
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

            bool gameOver = winningLines.Any( x => IsLineAllEqual(board, x[0], x[1], x[2]));
            return gameOver;
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

        public static bool IsGameTie(TicTacToeState state)
        {
            var board = state.board;
            // the board is filled but there is no winner
            return IsGameOver(state) && board.All(x => x != PlayerMark.Empty);
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
