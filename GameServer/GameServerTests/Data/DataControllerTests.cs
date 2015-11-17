using GameServer.Data;
using GameServer.Models;
using GameServer.Models.TicTacToe;
using GameServer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameServerTests.Data
{
    public class DataControllerTests
    {
        private DataController _controller;
        private Guid _firstPlayer;
        private Guid _secondPlayer;

        public DataControllerTests()
        {
            _controller = new DataController();
            _firstPlayer = Guid.Parse("12514A18-9A18-443A-9805-79BC51D38B6F");
            _secondPlayer = Guid.Parse("8701DD3B-00BB-4517-9BAB-453965DB1E81");
        }

        [Fact]
        public void RetrieveGameList_ReturnsNonEmptyList()
        {
            var list = _controller.RetrieveGameList();
            Assert.NotEmpty(list);
        }

        [Fact]
        public void RetrievePlayerByUsername_AndPlayerExists_ReturnsPlayer()
        {
            var username = "bobtest";
            var player = _controller.RetrievePlayerByUsername(username);
            Assert.NotNull(player);
        }

        [Fact]
        public void RetrievePlayerByUsername_AndPlayerDoesNotExists_ReturnsNothing()
        {
            var username = "bobtest0";
            Assert.Throws(typeof(InvalidUsernameException), () => _controller.RetrievePlayerByUsername(username));
        }

        [Fact]
        public void RetrievePlayerPassword_AndPlayerExists_ReturnsPassword()
        {
            var id = Guid.Parse("8701DD3B-00BB-4517-9BAB-453965DB1E81");
            var storedPassword = _controller.RetrievePlayerPasswordById(id);
            Assert.Equal("password123", storedPassword);
        }

        [Fact]
        public void RetrieveAllMatchesByPlayerId_ReturnsList()
        {
            var id = Guid.Parse("8701DD3B-00BB-4517-9BAB-453965DB1E81");
            var list = _controller.RetrieveAllMatchesByPlayerId(id);
            Assert.NotEmpty(list);
        }

        [Fact]
        public void RetrieveAllMatchesByPlayerId_AndPlayerHasNoRecords_ReturnsEmptyList()
        {
            var id = Guid.NewGuid();
            var list = _controller.RetrieveAllMatchesByPlayerId(id);
            Assert.Empty(list);
        }

        [Fact]
        public void CreatePlayer_DoesNotThrowException()
        {
            var playerId = Guid.NewGuid();
            var username = playerId.ToString();
            var password = "password123";
            _controller.CreatePlayer(playerId, username, password);

            using (var context = new GameServerEntities())
            {
                var players = context.Players.Select(x => x.username);
                Assert.Contains(username, players);
            }
        }

        [Fact]
        public void CheckUsernameExists()
        {
            var username = "bobtest";
            var doesExist = _controller.CheckUsernameExists(username);
            Assert.True(doesExist);
        }

        [Fact]
        public void StoreMatch_DoesNotThrowException()
        {
            var match = new MatchState
            {
                id = Guid.NewGuid(),
                gameStartTime = DateTime.Now,
                gameEndTime = DateTime.Now.AddHours(1),
                gameType = GameType.TicTacToe,
                operationState = GameOperationState.Completed,
                winnerId = _firstPlayer,
                playerTurnId = _firstPlayer,
                players = new List<Guid> { _firstPlayer, _secondPlayer },
                inGameState = new TicTacToeState
                {
                    firstPlayer = _firstPlayer,
                    secondPlayer = _secondPlayer,
                    board = new List<PlayerMark>(),
                }
            };
            _controller.StoreMatch(match);

            using (var context = new GameServerEntities())
            {
                var storedMatches = context.Matches.ToList();
                Assert.Contains(match.id, storedMatches.Select(x => x.id));
            }
        }
    }
}
