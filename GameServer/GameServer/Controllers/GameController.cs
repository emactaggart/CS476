using GameServer.Data;
using GameServer.GameLogic;
using GameServer.Models;
using GameServer.Models.TicTacToe;
using GameServer.Services;
using GameServer.Utilities;
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
        private List<MatchState> _onlineMatches;

        public GameController(DataController dataController, List<MatchState> matches)
        {
            _dataController = dataController;
            _onlineMatches = matches;
        }

        public MatchState JoinGame(GameType matchType, Guid playerId)
        {
            var gameList = _onlineMatches
                .FindAll(x => x.gameType == matchType)
                .FindAll(x => x.operationState == GameOperationState.WaitingForPlayers);
            MatchState matchState = null;

            if (gameList.Count == 0)
            {
                matchState = MatchFactory.CreateNewMatch(matchType, playerId);
                _onlineMatches.Add(matchState);
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
            var match = _onlineMatches.Find(x => x.id == matchId);
            if (!match.players.Any(x => x == playerId))
            {
                throw new PlayerNotInSpecifiedGameException();
            }
            match.winnerId = match.players.Find(x => x != playerId);
            match.operationState = GameOperationState.Completed;
            match.gameEndTime = DateTime.Now;
            _dataController.StoreMatch(match);
        }

        public MatchState PlayerMove(Guid matchId, Guid playerId, MovePosition move)
        {
            var match = _onlineMatches.FirstOrDefault(x => x.id == matchId);
            MatchState nextState = null;

            if (match == null)
            {
                throw new EmptyResultsException();
            }

            if (match.operationState == GameOperationState.WaitingForPlayers)
            {
                throw new WaitingForPlayersException();
            }
            if (match.operationState == GameOperationState.Completed)
            {
                throw new GameIsOverException();
            }

            if (!match.players.Contains(playerId))
            {
                throw new PlayerNotInSpecifiedGameException();
            } 

            nextState = TicTacToeLogic.CalculateNextState(match, playerId, move);

            if (nextState.operationState == GameOperationState.Completed)
            {
                _dataController.StoreMatch(nextState);
            }

            return nextState;
        }

        public MatchState GetMatchState(Guid matchId)
        {
            var m = _onlineMatches.Find(x => x.id == matchId);
            if (m == null)
            {
                throw new EmptyResultsException();
            }
            return m;
        }
    }
}
