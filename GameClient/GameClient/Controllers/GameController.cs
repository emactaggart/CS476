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
    class GameController
    {
        private GameServiceClient _service;
        private BasicObservable<MatchState> _gameState;

        public GameController(GameServiceClient service, BasicObservable<MatchState> state)
        {
            _service = service;
            _gameState = state;
        }

        public void StartGame(GameType gameType, Guid playerId)
        {
            try
            {
                var newMatch = _service.JoinGame(gameType, playerId);
                _gameState.Update(newMatch);
            }
            catch (FaultException<GameServerFault> fe) { }
            catch (CommunicationException ce) { }
            catch (TimeoutException te) { }
        }

        public void QuitGame(Guid gameId, Guid playerId)
        {
            try
            {
                _service.Quit(gameId, playerId);
                _gameState.Destroy();
            }
            catch (FaultException<GameServerFault> fe) { }
            catch (CommunicationException ce) { }
            catch (TimeoutException te) { }
        }

        public void PlayerMove(Guid matchId, Guid playerId, MovePosition move)
        {
            try
            {
                var matchState = _service.PlayerMove(matchId, playerId, move);
                UpdateGame(matchState);
            }
            catch (FaultException<GameServerFault> fe) { }
            catch (CommunicationException ce) { }
            catch (TimeoutException te) { }
        }

        public void GetMatchState(Guid matchId)
        {
            try
            {
                var matchState = _service.GetMatchState(matchId);
                UpdateGame(matchState);
            }
            catch (FaultException<GameServerFault> fe) { }
            catch (CommunicationException ce) { }
            catch (TimeoutException te) { }
        }

        public void UpdateGame(MatchState updatedMatchState)
        {
            _gameState.Update(updatedMatchState);
        }
    }
}
