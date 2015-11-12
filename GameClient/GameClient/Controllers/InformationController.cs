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
            try
            {
                PlayerStats stats = _service.GetPlayerStats(playerId);
                _stats.Update(stats);
            }
            catch (FaultException<GameServerFault> fe) { }
            catch (CommunicationException ce) { }
            catch (TimeoutException te) { }
        }

        public void GetGameList()
        {
            try
            {
                List<GameInformation> gameList = _service.GetGameList().ToList();
                _gameList.Update(gameList);
            }
            catch (FaultException<GameServerFault> fe) { }
            catch (CommunicationException ce) { }
            catch (TimeoutException te) { }
        }

        public void CreateAccount(string username, string password)
        {
            try
            {
                _service.CreatePlayerAccount(username, password);
            }
            catch (FaultException<GameServerFault> fe) { }
            catch (CommunicationException ce) { }
            catch (TimeoutException te) { }
        }

        public void LogingPlayer(string username, string password)
        {
            try
            {
                _profile = _service.LoginPlayer(username, password);
            }
            catch (FaultException<GameServerFault> fe) { }
            catch (CommunicationException ce) { }
            catch (TimeoutException te) { }
        }

        public void LogingGuest()
        {
            try
            {
                _profile = _service.LoginGuest();
            }
            catch (FaultException<GameServerFault> fe) { }
            catch (CommunicationException ce) { }
            catch (TimeoutException te) { }
        }

        public void LogoutPlayer(Guid playerId)
        {
            try
            {
                _service.LogoutPlayer(playerId);
                _profile = new PlayerProfile { id = Guid.Parse("00000000-0000-0000-0000-000000000000"), username = "null" };
            }
            catch (FaultException<GameServerFault> fe) { }
            catch (CommunicationException ce) { }
            catch (TimeoutException te) { }
        }
    }
}
