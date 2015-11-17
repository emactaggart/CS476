using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClient.Server;
using GameClient.Utilities;
using System.ServiceModel;

namespace GameClient.Controllers
{
    class InformationController
    {
        private InformationServiceClient _service;
        public PlayerStats stats { get; private set; }
        public PlayerProfile profile { get; private set; }
        public List<GameInformation> gameList { get; private set; }

        public InformationController(InformationServiceClient service, 
                PlayerProfile profile, 
                PlayerStats stats, 
                List<GameInformation> gameList)
        {
            _service = service;
            this.stats = stats;
            this.profile = profile;
            this.gameList = gameList;
        }

        public void GetPlayerStats()
        {
            this.stats = _service.GetPlayerStats(this.profile.id);
        }

        public void GetGameList()
        {
            this.gameList = _service.GetGameList().ToList();
        }

        public void CreateAccount(string username, string password)
        {
            _service.CreatePlayerAccount(username, password);
        }

        public void LoginPlayer(string username, string password)
        {
            profile = _service.LoginPlayer(username, password);
        }

        public void LoginGuest()
        {
            profile = _service.LoginGuest();
        }

        public void LogoutPlayer(Guid playerId)
        {
            _service.LogoutPlayer(playerId);
            profile = new PlayerProfile { id = Guid.Empty, username = "null" };
        }
    }
}
