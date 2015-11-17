using GameServer.Data;
using GameServer.Models;
using GameServer.Services;
using GameServer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Controllers
{
    public class InformationController : IInformationService
    {
        private DataController _dataController;
        private List<PlayerProfile> _onlinePlayers;

        public InformationController(DataController data, List<PlayerProfile> players)
        {
            _dataController = data;
            _onlinePlayers = players;
        }

        public PlayerStats GetPlayerStats(Guid playerId)
        {
            var list = _dataController.RetrieveAllMatchesByPlayerId(playerId);
            if (list.Count == 0)
            {
                return new PlayerStats
                {
                    playerId = playerId,
                    gameHistory = list,
                    totalGames = 0,
                    totalWins = 0,
                    totalLosses = 0,
                    winLossRatio = 0,
                };
            }
            else 
            {
                var totals = list.Count();
                var wins = list.Count(x => x.winnerId == playerId);
                var losses = list.Count() - list.Count(x => x.winnerId == playerId);
                float ratio;
                if (losses == 0)
                {
                    ratio = 1;
                }
                else
                {
                    ratio = (float)wins / (float)totals;
                }

                return new PlayerStats
                {
                    playerId = playerId,
                    gameHistory = list,
                    totalGames = totals,
                    totalWins = wins,
                    totalLosses = losses,
                    winLossRatio = ratio,
                };
            }
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
                throw new UsernameAlreadyExistsException();
            }
            var userId = Guid.NewGuid();

            _dataController.CreatePlayer(userId, username, password);
        }

        public PlayerProfile LoginPlayer(string username, string password)
        {
            var profile = _dataController.RetrievePlayerByUsername(username);
            var storePassword = _dataController.RetrievePlayerPasswordById(profile.id);

            if (password != storePassword)
            {
                throw new InvalidPasswordException();
            }

            if (!_onlinePlayers.Contains(profile))
            {
                _onlinePlayers.Add(profile);
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

            if (!_onlinePlayers.Contains(guest))
            {
                _onlinePlayers.Add(guest);
            }

            _dataController.CreatePlayer(guest.id, guest.username, "");

            return guest;
        }

        public void LogoutPlayer(Guid playerId)
        {
            var index = _onlinePlayers.FindIndex(x => x.id == playerId);
            _onlinePlayers.RemoveAt(index);
        }
    }
}
