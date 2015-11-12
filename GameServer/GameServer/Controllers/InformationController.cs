using GameServer.Data;
using GameServer.Models;
using GameServer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Controllers
{
    class InformationController : IInformationService
    {
        private DataController _dataController;

        public InformationController(DataController data)
        {
            _dataController = data;
        }

        public PlayerStats GetPlayerStats(Guid playerId)
        {
            var list = _dataController.RetrieveAllMatchesByPlayerId(playerId);
            var totals = list.Count();
            var wins = list.Count(x => x.winnerId == playerId);
            var losses = list.Count() - list.Count(x => x.winnerId == playerId);
            return new PlayerStats
            {
                playerId = playerId,
                gameHistory = list,
                totalGames = totals,
                totalWins = wins,
                totalLosses = losses,
                winLossRation = (float)wins / (float)losses,
            };
        }

        public List<GameInformation> GetGameList()
        {
            var gameList = _dataController.RetrieveGameList();
            return gameList;
        }

        public void CreatePlayerAccount(string username, string password)
        {
            if (_dataController.CheckUsernameExists(username))
            {
                throw new Exception("Username already exists.");
            }
            var userId = Guid.NewGuid();

            _dataController.CreatePlayer(userId, username, password);
        }

        public PlayerProfile LoginPlayer(string username, string password)
        {
            var profile = _dataController.RetrievePlayerByUsername(username);
            var storePassword = _dataController.RetreivePlayerPasswordById(profile.id);

            if (password != storePassword)
            {
                throw new Exception("Invalid password!");
            }

            if (!Program.onlinePlayerList.Contains(profile))
            {
                Program.onlinePlayerList.Add(profile);
            }

            return profile;
        }

        public PlayerProfile LoginGuest()
        {
            var guest = new PlayerProfile
            {
                id = Guid.NewGuid(),
                username = "Guest",
            };
            return guest;
        }

        public void LogoutPlayer(Guid playerId)
        {
            var index = Program.onlinePlayerList.FindIndex(x => x.id == playerId);
            Program.onlinePlayerList.RemoveAt(index);
        }
    }
}
