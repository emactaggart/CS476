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
        public BasicObservable<MatchState> gameState { get; private set; }

        public GameController(GameServiceClient service, BasicObservable<MatchState> state)
        {
            _service = service;
            gameState = state;
        }

        public void JoinGame(GameType gameType, Guid playerId)
        {
            var newMatch = _service.JoinGame(gameType, playerId);
            gameState.Update(newMatch);
        }

        public void QuitGame(Guid gameId, Guid playerId)
        {
            _service.Quit(gameId, playerId);
            gameState.Destroy();
        }

        public void PlayerMove(Guid matchId, Guid playerId, MovePosition move)
        {
            var matchState = _service.PlayerMove(matchId, playerId, move);
            gameState.Update(matchState);
        }

        public void UpdateMatchState(Guid matchId)
        {
            var matchState = _service.GetMatchState(matchId);
            gameState.Update(matchState);
        }
    }
}
