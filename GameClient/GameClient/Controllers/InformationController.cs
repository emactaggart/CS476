using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClient.GameServerService;
using GameClient.Models;
using GameClient.Utilities;

namespace GameClient.Controllers
{
    class InformationController
    {
        private GameServerClient _gameServer;
        private BasicObservable<PlayerStats> _stats;
        private PlayerProfile _profile;
        private BasicObservable<List<GameDetails>> _gameList;

        public InformationController(GameServerClient server, PlayerProfile profile, BasicObservable<PlayerStats> stats, BasicObservable<List<GameDetails>> gameList)
        {
            _gameServer = server;
            _stats = stats;
            _profile = profile;
            _gameList = gameList;
        }

        public void GetStats(Guid playerId)
        {
            PlayerStats stats = _gameServer.GetPlayerStats(playerId);
            _stats.Update(stats);
        }

        public void GetGameList()
        {
            List<GameDetails> gameList = _gameServer.GetGameList();
            _gameList.Update(gameList);
        }

        public void PlayerLogin()
        {
            _profile = _gameServer.Login(string username, string password);
        }

        public void GuestLogin()
        {
            _gameServer.LoginGuest();
            _profile = new PlayerProfile { id = Guid.Parse("11111111-1111-1111-1111-111111111111"), username = "Guest" };
        }

        public void PlayerLogout()
        {
            _gameServer.Logout();
            _profile = new PlayerProfile { id = Guid.Parse("00000000-0000-0000-0000-000000000000"), username = "null" };
        }
    }
}
