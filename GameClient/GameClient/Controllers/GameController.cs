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
    class GameController
    {
        private GameServiceClient _service;
        private BasicObservable<TicTacToeState> _gameState;

        public GameController(GameServiceClient service, BasicObservable<TicTacToeState> state)
        {
            _service = service;
            _gameState = state;
        }

        public void StartGame(GameType gameType, Guid playerId)
        {
            var newGame = _service.JoinGame(gameType, playerId);
            _gameState.Update(newGame);
        }

        public void QuitGame(Guid gameId, Guid playerId)
        {
            _service.Quit(gameId, playerId);
            _gameState.Destroy();
        }

        public void PlayerMove(Guid gameId, Guid playerId, TicTacToeMove move)
        {
            var gameState = _service.PlayerMove(gameId, playerId, move);
            UpdateGame(gameState);
        }

        public void UpdateGame(TicTacToeState updatedGameState)
        {
            //TODO: check validity of game state
            _gameState.Update(updatedGameState);
        }
    }
}
