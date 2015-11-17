using GameServer.GameLogic;
using GameServer.Models;
using GameServer.Models.TicTacToe;
using GameServer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameServerTests.GameLogic.TicTacToe
{
    public class TicTacToeTests
    {
        [Fact]
        public void IsLineEqual_IsTrue()
        {
            var board = new List<PlayerMark>
            {
                PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                PlayerMark.X, PlayerMark.X, PlayerMark.X,
                PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
            };
            var result = TicTacToeLogic.IsLineAllEqual(board, 
                MovePosition.MiddleLeft, 
                MovePosition.MiddleCenter, 
                MovePosition.MiddleRight);
            Assert.True(result);
        }

        [Fact]
        public void IsLineEqual_WithAllEmpty_IsFalse()
        {
            var board = new List<PlayerMark>
            {
                PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
            };
            var result = TicTacToeLogic.IsLineAllEqual(board, 
                MovePosition.MiddleLeft, 
                MovePosition.MiddleCenter, 
                MovePosition.MiddleRight);
            Assert.False(result);
        }

        [Fact]
        public void IsLineEqual_IsFalse()
        {
            var board = new List<PlayerMark>
            {
                PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                PlayerMark.X, PlayerMark.O, PlayerMark.X,
                PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
            };
            var result = TicTacToeLogic.IsLineAllEqual(board, 
                MovePosition.MiddleLeft, 
                MovePosition.MiddleCenter, 
                MovePosition.MiddleRight);
            Assert.False(result);
        }

        [Fact]
        public void DoesGameHaveWinner_IsTrue()
        {
            var state = new TicTacToeState
            {
                firstPlayer = Guid.Empty,
                secondPlayer = Guid.Empty,
                board = new List<PlayerMark>
                {
                    PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                    PlayerMark.X, PlayerMark.X, PlayerMark.X,
                    PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                }
            };
            var hasWinner = TicTacToeLogic.IsGameOver(state);
            Assert.True(hasWinner);
        }

        [Fact]
        public void DoesGameHaveWinner_IsFalse()
        {
            var state = new TicTacToeState
            {
                firstPlayer = Guid.Empty,
                secondPlayer = Guid.Empty,
                board = new List<PlayerMark>
                {
                    PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                    PlayerMark.X, PlayerMark.O, PlayerMark.X,
                    PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                }
            };
            var hasWinner = TicTacToeLogic.IsGameOver(state);
            Assert.False(hasWinner);
        }

        [Fact]
        public void IsBoardFull_IsTrue()
        {
            var state = new TicTacToeState
            {
                board = new List<PlayerMark>
                {
                    PlayerMark.X, PlayerMark.O, PlayerMark.X,
                    PlayerMark.X, PlayerMark.O, PlayerMark.X,
                    PlayerMark.O, PlayerMark.X, PlayerMark.O,
                }
            };
            var isFull = TicTacToeLogic.IsBoardFull(state);
            Assert.True(isFull);
        }
        
        [Fact]
        public void IsBoardFull_IsFalse()
        {
            var state = new TicTacToeState
            {
                board = new List<PlayerMark>
                {
                    PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                    PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                    PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                }
            };
            var isFull = TicTacToeLogic.IsBoardFull(state);
            Assert.False(isFull);
        }

        [Fact]
        public void AlternateTurn_PlayerOne()
        {
            var one = Guid.NewGuid();
            var two = Guid.NewGuid();
            var match = new MatchState
            {
                playerTurnId = one,
                inGameState = new TicTacToeState
                {
                    firstPlayer = one,
                    secondPlayer = two,
                },
            };
            var result = TicTacToeLogic.AlternateTurn(match);

            Assert.Equal(two, result);
        }

        [Fact]
        public void AlternateTurn_PlayerTwo()
        {
            var one = Guid.NewGuid();
            var two = Guid.NewGuid();
            var match = new MatchState
            {
                playerTurnId = two,
                inGameState = new TicTacToeState
                {
                    firstPlayer = one,
                    secondPlayer = two,
                },
            };
            var result = TicTacToeLogic.AlternateTurn(match);

            Assert.Equal(one, result);
        }

        [Fact]
        public void CalculateNextState_PlayerOneMakesMove_IsSuccessful()
        {
            var matchId = Guid.NewGuid();
            var playerOne = Guid.NewGuid();
            var playerTwo = Guid.NewGuid();
            var move = MovePosition.MiddleCenter;
            var currentState = new MatchState
            {
                id = matchId,
                operationState = GameOperationState.InProgress,
                playerTurnId = playerOne,
                players = new List<Guid> { playerOne, playerTwo },
                inGameState = new TicTacToeState
                {
                    firstPlayer = playerOne,
                    secondPlayer = playerTwo,
                    board = new List<PlayerMark>
                    {
                        PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                        PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                        PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                    }
                },
            };

            var expectedState = new MatchState
            {
                id = matchId,
                operationState = GameOperationState.InProgress,
                playerTurnId = playerTwo,
                players = new List<Guid> { playerOne, playerTwo },
                inGameState = new TicTacToeState
                {
                    firstPlayer = playerOne,
                    secondPlayer = playerTwo,
                    board = new List<PlayerMark>
                    {
                        PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                        PlayerMark.Empty, PlayerMark.X, PlayerMark.Empty,
                        PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                    }
                },
            };

            var nextState = TicTacToeLogic.CalculateNextState(currentState, playerOne, move);
            Assert.Equal(expectedState.playerTurnId, nextState.playerTurnId);
            Assert.Equal(expectedState.inGameState.board, nextState.inGameState.board);
        }

        [Fact]
        public void CalculateNextState_PlayerTwoMakesMove_IsSuccessful()
        {
            var matchId = Guid.NewGuid();
            var playerOne = Guid.NewGuid();
            var playerTwo = Guid.NewGuid();
            var move = MovePosition.MiddleCenter;
            var currentState = new MatchState
            {
                id = matchId,
                operationState = GameOperationState.InProgress,
                playerTurnId = playerTwo,
                players = new List<Guid> { playerOne, playerTwo },
                inGameState = new TicTacToeState
                {
                    firstPlayer = playerOne,
                    secondPlayer = playerTwo,
                    board = new List<PlayerMark>
                    {
                        PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                        PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                        PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                    }
                },
            };

            var expectedState = new MatchState
            {
                id = matchId,
                operationState = GameOperationState.InProgress,
                playerTurnId = playerOne,
                players = new List<Guid> { playerOne, playerTwo },
                inGameState = new TicTacToeState
                {
                    firstPlayer = playerOne,
                    secondPlayer = playerTwo,
                    board = new List<PlayerMark>
                    {
                        PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                        PlayerMark.Empty, PlayerMark.O, PlayerMark.Empty,
                        PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                    }
                },
            };

            var nextState = TicTacToeLogic.CalculateNextState(currentState, playerTwo, move);
            Assert.Equal(expectedState.playerTurnId, nextState.playerTurnId);
            Assert.Equal(expectedState.inGameState.board, nextState.inGameState.board);
        }

        [Fact]
        public void CalculateNextState_GameIsOver_ThrowsException()
        {
            var playerOne = Guid.NewGuid();
            var move = MovePosition.MiddleCenter;
            var currentState = new MatchState
            {
                operationState = GameOperationState.Completed,
            };

            Assert.Throws(typeof(GameIsOverException), () => TicTacToeLogic.CalculateNextState(currentState, playerOne, move));
        }

        [Fact]
        public void CalculateNextState_NotPlayersTurn_ThrowsException()
        {
            var playerOne = Guid.NewGuid();
            var playerTwo = Guid.NewGuid();
            var move = MovePosition.MiddleCenter;
            var currentState = new MatchState
            {
                operationState = GameOperationState.InProgress,
                playerTurnId = playerTwo,
            };

            Assert.Throws(typeof(NotPlayersTurnException), () => TicTacToeLogic.CalculateNextState(currentState, playerOne, move));
        }

        [Fact]
        public void CalculateNextState_InvalidMovePositionIsNotEmpty_ThrowsException()
        {
            var playerOne = Guid.NewGuid();
            var playerTwo = Guid.NewGuid();
            var move = MovePosition.MiddleCenter;
            var currentState = new MatchState
            {
                operationState = GameOperationState.InProgress,
                playerTurnId = playerOne,
                inGameState = new TicTacToeState
                {
                    firstPlayer = playerOne,
                    board = new List<PlayerMark>
                    {
                        PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                        PlayerMark.Empty, PlayerMark.X, PlayerMark.Empty,
                        PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                    }
                },
            };

            Assert.Throws(typeof(InvalidPlayerMoveException), () => TicTacToeLogic.CalculateNextState(currentState, playerOne, move));
        }

        [Fact]
        public void CalculateNextState_PlayerOneWins_ReturnsUpdatedMatch()
        {
            var playerOne = Guid.NewGuid();
            var playerTwo = Guid.NewGuid();
            var move = MovePosition.MiddleCenter;
            var currentState = new MatchState
            {
                operationState = GameOperationState.InProgress,
                playerTurnId = playerOne,
                players = new List<Guid> { playerOne, playerTwo },
                inGameState = new TicTacToeState
                {
                    firstPlayer = playerOne,
                    secondPlayer = playerTwo,
                    board = new List<PlayerMark>
                    {
                        PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                        PlayerMark.X, PlayerMark.Empty, PlayerMark.X,
                        PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                    }
                },
            };

            var expectedState = new MatchState
            {
                operationState = GameOperationState.Completed,
                playerTurnId = Guid.Empty,
                winnerId = playerOne,
                players = new List<Guid> { playerOne, playerTwo },
                inGameState = new TicTacToeState
                {
                    firstPlayer = playerOne,
                    secondPlayer = playerTwo,
                    board = new List<PlayerMark>
                    {
                        PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                        PlayerMark.X, PlayerMark.X, PlayerMark.X,
                        PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                    }
                },
            };

            var nextState = TicTacToeLogic.CalculateNextState(currentState, playerOne, move);
            Assert.Equal(expectedState.operationState, nextState.operationState);
            Assert.Equal(expectedState.playerTurnId, nextState.playerTurnId);
            Assert.Equal(expectedState.winnerId, nextState.winnerId);
            Assert.Equal(expectedState.inGameState.board, nextState.inGameState.board);
        }

        [Fact]
        public void CalculateNextState_GameIsATie_ReturnsUpdatedMatch()
        {
            var playerOne = Guid.NewGuid();
            var playerTwo = Guid.NewGuid();
            var move = MovePosition.MiddleCenter;
            var currentState = new MatchState
            {
                operationState = GameOperationState.InProgress,
                playerTurnId = playerOne,
                players = new List<Guid> { playerOne, playerTwo },
                inGameState = new TicTacToeState
                {
                    firstPlayer = playerOne,
                    secondPlayer = playerTwo,
                    board = new List<PlayerMark>
                    {
                        PlayerMark.X, PlayerMark.O, PlayerMark.O,
                        PlayerMark.O, PlayerMark.Empty, PlayerMark.X,
                        PlayerMark.O, PlayerMark.X, PlayerMark.O,
                    }
                },
            };

            var expectedState = new MatchState
            {
                operationState = GameOperationState.Completed,
                playerTurnId = Guid.Empty,
                winnerId = Guid.Empty,
                players = new List<Guid> { playerOne, playerTwo },
                inGameState = new TicTacToeState
                {
                    firstPlayer = playerOne,
                    secondPlayer = playerTwo,
                    board = new List<PlayerMark>
                    {
                        PlayerMark.X, PlayerMark.O, PlayerMark.O,
                        PlayerMark.O, PlayerMark.X, PlayerMark.X,
                        PlayerMark.O, PlayerMark.X, PlayerMark.O,
                    }
                },
            };

            var nextState = TicTacToeLogic.CalculateNextState(currentState, playerOne, move);
            Assert.Equal(expectedState.operationState, nextState.operationState);
            Assert.Equal(expectedState.playerTurnId, nextState.playerTurnId);
            Assert.Equal(expectedState.winnerId, nextState.winnerId);
            Assert.Equal(expectedState.inGameState.board, nextState.inGameState.board);
        }
    }
}
