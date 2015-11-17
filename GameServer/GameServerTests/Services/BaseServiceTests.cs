using GameServer.Controllers;
using GameServer.Data;
using GameServer.Models;
using GameServer.Models.TicTacToe;
using GameServer.Services;
using GameServer.Utilities;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameServerTests.Services
{
    public class BaseServiceTests
    {
        private BaseService _service;
        private List<MatchState> _onlineMatchList;
        private List<PlayerProfile> _onlinePlayerList;
        private IGameService _gameController;
        private IInformationService _infoController;
        private DataController _dataController;
        

        public BaseServiceTests()
        {
            _onlineMatchList = new List<MatchState>();
            _onlinePlayerList = new List<PlayerProfile>();
            _dataController = new DataController();
            _gameController = new GameController(_dataController, _onlineMatchList);
            _infoController = new InformationController(_dataController, _onlinePlayerList);
            _service = new BaseService(_gameController, _infoController);
        }

        [Fact]
        public void CreateAccount_IsSuccessful()
        {
            var username = Guid.NewGuid().ToString();
            var password = "password123";
            _service.CreatePlayerAccount(username, password);

            var result = _service.LoginPlayer(username, password);
            Assert.Equal(username, result.username);
        }

        [Fact]
        public void CreateAccount_AndUsernameAlreadyExists_ThrowsException()
        {
            var username = "bobtest";
            var password = "password123";

            Assert.Throws(typeof(FaultException<UsernameAlreadyExistsFault>), () => _service.CreatePlayerAccount(username, password));
        }

        [Fact]
        public void GetGameList_ReturnsList()
        {
            var list = _service.GetGameList();
            Assert.NotEmpty(list);
        }

        [Fact]
        public void GetMatchState_IsSuccessful()
        {
            var match = new MatchState { id = Guid.NewGuid() };
            _onlineMatchList.Add(match);

            var result = _service.GetMatchState(match.id);
            Assert.Equal(match, result);
        }

        [Fact]
        public void GetMatchState_AndMatchDoesNotExist_ThrowsException()
        {
            var id = Guid.NewGuid();
            Assert.Throws(typeof(FaultException<EmptyResultsFault>), () => _service.GetMatchState(id));
        }

        [Fact]
        public void GetPlayerStats_AndHasResults_ReturnsPlayerStats()
        {
            var id = Guid.Parse("12514A18-9A18-443A-9805-79BC51D38B6F");
            var result = _service.GetPlayerStats(id);
            Assert.Equal(id, result.playerId);
            Assert.NotEmpty(result.gameHistory);
        }

        [Fact]
        public void GetPlayerStats_AndListIsEmpty_ReturnsEmptyStats()
        {
            var id = Guid.NewGuid();
            var result = _service.GetPlayerStats(id);
            var expected = new PlayerStats
            {
                playerId = id,
                gameHistory = new List<MatchResult>(),
                totalGames = 0,
                totalWins = 0,
                totalLosses = 0,
                winLossRatio = 0,
            };
            Assert.Equal(expected.playerId, result.playerId);
            Assert.Empty(result.gameHistory);
            Assert.Equal(expected.totalGames, result.totalGames);
            Assert.Equal(expected.totalWins, result.totalWins);
            Assert.Equal(expected.totalLosses, result.totalLosses);
            Assert.Equal(expected.winLossRatio, result.winLossRatio);
        }

        [Fact]
        public void JoinGame_MatchListIsEmpty_CreatesNewMatch()
        {
            var playerId = Guid.NewGuid();
            var type = GameType.TicTacToe;
            var expected = MatchFactory.CreateNewMatch(type, playerId);
            var result = _service.JoinGame(type, playerId);

            Assert.Equal(expected.gameType, result.gameType);
            Assert.Equal(expected.operationState, result.operationState);
            Assert.Equal(expected.players, result.players);
        }

        [Fact]
        public void JoinGame_MatchListIsNotEmpty_PlayerJoinsMatch()
        {
            var playerOne = Guid.NewGuid();
            var playerTwo = Guid.NewGuid();
            var type = GameType.TicTacToe;
            var newMatch = MatchFactory.CreateNewMatch(type, playerOne);
            var expectedMatch = new MatchState
            {
                id = newMatch.id,
                gameStartTime = newMatch.gameStartTime,
                gameType = type,
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
                    },
                },
                operationState = GameOperationState.InProgress,
            };
            _onlineMatchList.Add(newMatch);
            var result = _service.JoinGame(type, playerTwo);

            Assert.Equal(expectedMatch.id, result.id);
            Assert.Equal(expectedMatch.gameStartTime, result.gameStartTime);
            Assert.Equal(expectedMatch.gameType, result.gameType);
            Assert.Equal(expectedMatch.players, result.players);
            Assert.Equal(expectedMatch.inGameState.firstPlayer, result.inGameState.firstPlayer);
            Assert.Equal(expectedMatch.inGameState.secondPlayer, result.inGameState.secondPlayer);
            Assert.Equal(expectedMatch.inGameState.board, result.inGameState.board);
            Assert.Equal(expectedMatch.operationState, result.operationState);
        }

        [Fact]
        public void LoginGuest_IsSuccessful()
        {
            var account = _service.LoginGuest();
            Assert.Equal("Guest", account.username);
        }

        [Fact]
        public void LoginPlayer_IsSuccessful()
        {
            var account = _service.LoginPlayer("bobtest", "password123");
            Assert.Equal("bobtest", account.username);
            Assert.Equal(Guid.Parse("12514A18-9A18-443A-9805-79BC51D38B6F"), account.id);
        }

        [Fact]
        public void LogoutPlayer_IsSuccessful()
        {
            var player = new PlayerProfile
            {
                id = Guid.NewGuid(),
                username = "bobtest",
            };
            _onlinePlayerList.Add(player);
            _service.LogoutPlayer(player.id);
            Assert.DoesNotContain(player, _onlinePlayerList);
        }

        [Fact]
        public void PlayerMove_WaitingForPlayers_ThrowsException()
        {
            var matchId = Guid.NewGuid();
            var playerId = Guid.Parse("12514A18-9A18-443A-9805-79BC51D38B6F");
            var move = MovePosition.MiddleCenter;
            var match = new MatchState
            {
                id = matchId,
                operationState = GameOperationState.WaitingForPlayers,
            };
            _onlineMatchList.Add(match);

            Assert.Throws(typeof(FaultException<WaitingForPlayersFault>), () => _service.PlayerMove(matchId, playerId, move));
        }

        [Fact]
        public void PlayerMove_GameIsCompleted_ThrowsException()
        {
            var matchId = Guid.NewGuid();
            var playerId = Guid.Parse("12514A18-9A18-443A-9805-79BC51D38B6F");
            var move = MovePosition.MiddleCenter;
            var match = new MatchState
            {
                id = matchId,
                operationState = GameOperationState.Completed,
            };
            _onlineMatchList.Add(match);

            Assert.Throws(typeof(FaultException<GameIsOverFault>), () => _service.PlayerMove(matchId, playerId, move));
        }

        [Fact]
        public void Quit_IsSuccessful()
        {
            var matchId = Guid.NewGuid();
            var playerOne = Guid.Parse("12514A18-9A18-443A-9805-79BC51D38B6F");
            var playerTwo = Guid.Parse("8701DD3B-00BB-4517-9BAB-453965DB1E81");
            var existingMatch = new MatchState
            {
                id = matchId,
                players = new List<Guid> { playerOne, playerTwo },
                gameStartTime = DateTime.Now,
                gameType = GameType.TicTacToe,
                inGameState = new TicTacToeState
                {
                    firstPlayer = playerOne,
                    secondPlayer = playerTwo,
                    board = new List<PlayerMark>
                    {
                            PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                            PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                            PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                    },
                },
                operationState = GameOperationState.InProgress,
            };
            var expected = new MatchState
            {
                id = matchId,
                players = new List<Guid> { playerOne, playerTwo },
                winnerId = playerTwo,
                inGameState = new TicTacToeState
                {
                    firstPlayer = playerOne,
                    secondPlayer = playerTwo,
                    board = new List<PlayerMark>
                    {
                            PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                            PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                            PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                    },
                },
                operationState = GameOperationState.Completed,
            };
            _onlineMatchList.Add(existingMatch);

            _service.Quit(matchId, playerOne);
            var result = _service.GetMatchState(matchId);

            Assert.Equal(expected.id, result.id);
            Assert.Equal(expected.winnerId, result.winnerId);
            Assert.Equal(expected.operationState, result.operationState);
        }

        [Fact]
        public void Quit_WithInvalidPlayerId_ThrowsException()
        {
            var matchId = Guid.NewGuid();
            var playerOne = Guid.Parse("12514A18-9A18-443A-9805-79BC51D38B6F");
            var playerTwo = Guid.Parse("8701DD3B-00BB-4517-9BAB-453965DB1E81");
            var wrongPlayer = Guid.NewGuid();
            var expected = new MatchState
            {
                id = matchId,
                players = new List<Guid> { playerOne, playerTwo },
            };
            _onlineMatchList.Add(expected);

            Assert.Throws(typeof(FaultException<PlayerNotInSpecifiedGameFault>), () => _service.Quit(matchId, wrongPlayer));
        }
    }
}
