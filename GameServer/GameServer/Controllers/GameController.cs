using GameServer.Data;
using GameServer.GameLogic;
using GameServer.Models;
using GameServer.Models.TicTacToe;
using GameServer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Controllers
{
    public class GameController : IGameService
    {
        private DataController _dataController;

        public GameController(DataController dataController)
        {
            _dataController = dataController;
        }

        public MatchState JoinGame(GameType matchType, Guid playerId)
        {
            var gameList = Program.onlineMatchList
                .FindAll(x => x.gameType == matchType)
                .FindAll(x => x.operationState == GameOperationState.WaitingForPlayers);
            MatchState matchState = null;

            if (!gameList.Any())
            {
                matchState = MatchFactory.CreateNewMatch(matchType, playerId);
                Program.onlineMatchList.Add(matchState);
            }
            else
            {
                matchState = gameList.First();
                matchState.players.Add(playerId);
                matchState.inGameState.secondPlayer = playerId;
                matchState.operationState = GameOperationState.InProgress;
            }

            return matchState;
        }

        public void Quit(Guid matchId, Guid playerId)
        {
            var match = Program.onlineMatchList.Find(x => x.id == matchId);
            if (!match.players.Any(x => x == playerId))
            {
                throw new Exception("Invalid request, player is not in specified game.");
            }
            match.winnerId = match.players.Find(x => x != playerId);
            match.operationState = GameOperationState.Completed;
            match.gameEndTime = DateTime.Now;
            _dataController.StoreMatch(match);
        }

        public MatchState PlayerMove(Guid matchId, Guid playerId, MovePosition move)
        {
            var match = Program.onlineMatchList.Find(x => x.id == matchId);
            MatchState matchState = null;

            if (match.operationState == GameOperationState.WaitingForPlayers)
            {
                throw new Exception("Invalid request, waiting for another player.");
            }
            if (match.operationState == GameOperationState.Completed)
            {
                throw new Exception("Invalid request, game is finished.");
            }

            if (!match.players.Contains(playerId))
            {
                throw new Exception("Invalid request, player is not in specified game.");
            } 
            matchState = TicTacToeLogic.CalculateNextState(match, playerId, move);

            return matchState;
        }

        public MatchState GetMatchState(Guid matchId)
        {
            return Program.onlineMatchList.Find(x => x.id == matchId);
        }
    }
}
