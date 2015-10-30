using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClient.Server;
using GameClient.Models;
using GameClient.Utilities;

namespace GameClient.Controllers
{
    class InformationController
    {
        private InformationServiceClient _service;
        private BasicObservable<PlayerStats> _stats;
        private PlayerProfile _profile;
        private BasicObservable<List<GameDetails>> _gameList;

        public InformationController(InformationServiceClient service, PlayerProfile profile, BasicObservable<PlayerStats> stats, BasicObservable<List<GameDetails>> gameList)
        {
            _service = service;
            _stats = stats;
            _profile = profile;
            _gameList = gameList;
        }

        public void GetPlayerStats(Guid playerId)
        {
            PlayerStats stats = _service.GetPlayerStats(playerId);
            _stats.Update(stats);
        }

        public void GetGameList()
        {
            List<GameDetails> gameList = _service.GetGameList().ToList();
            _gameList.Update(gameList);
        }

        public void LogingPlayer(string username, string password)
        {
            _profile = _service.LoginPlayer(username, password);
        }

        public void LogingGuest()
        {
            _service.LoginGuest();
            _profile = new PlayerProfile { id = Guid.Parse("11111111-1111-1111-1111-111111111111"), username = "Guest" };
        }

        public void LogoutPlayer(Guid playerId)
        {
            _service.LogoutPlayer(playerId);
            _profile = new PlayerProfile { id = Guid.Parse("00000000-0000-0000-0000-000000000000"), username = "null" };
        }
    }
}
