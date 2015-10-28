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
    class GameController
    {
        private GameServerClient _gameServer;
        private BasicObservable<GameState> _gameState;

        public GameController(GameServerClient server, BasicObservable<GameState> state)
        {
            _gameServer = server;
            _gameState = state;
        }

        public void StartGame(GameType gameType)
        {
            //var newGame = _gameServer.NewGame(gameType);
            //_gameState.Update(newGame);
        }

        public void QuitGame(Guid gameId)
        {
            //_gameServer.Quit(Guid playerId, Guid gameId);
            //_gameState.Destroy();
        }

        public void PlayerMove(Guid gameId, Guid playerId, TicTacToeMove move)
        {
            //var gameState = _gameServer.PlayerMove(Guid gameId, Guid playerId, GameMove move);
            //UpdateGame(gameState);
        }

        public void UpdateGame(GameState updatedGameState)
        {
            //TODO: check validity of game state
            _gameState.Update(updatedGameState);
        }
    }
}
