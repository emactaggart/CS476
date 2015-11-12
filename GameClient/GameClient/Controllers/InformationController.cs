using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClient.Server;
using GameClient.Utilities;

namespace GameClient.Controllers
{
    class InformationController
    {
        private InformationServiceClient _service;
        private BasicObservable<PlayerStats> _stats;
        private PlayerProfile _profile;
        private BasicObservable<List<GameInformation>> _gameList;

        public InformationController(InformationServiceClient service, 
                PlayerProfile profile, 
                BasicObservable<PlayerStats> stats, 
                BasicObservable<List<GameInformation>> gameList)
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
            List<GameInformation> gameList = _service.GetGameList().ToList();
            _gameList.Update(gameList);
        }

        public void CreateAccount(string username, string password)
        {

        }

        public void LogingPlayer(string username, string password)
        {
            _profile = _service.LoginPlayer(username, password);
        }

        public void LogingGuest()
        {
            _profile = _service.LoginGuest();
        }

        public void LogoutPlayer(Guid playerId)
        {
            _service.LogoutPlayer(playerId);
            _profile = new PlayerProfile { id = Guid.Parse("00000000-0000-0000-0000-000000000000"), username = "null" };
        }
    }
}
