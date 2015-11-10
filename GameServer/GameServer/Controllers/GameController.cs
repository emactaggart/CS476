using GameServer.Models;
using GameServer.Models.TicTacToe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Controllers
{
    class GameController        //TODO: add exceptions for failures
    {
        public MatchState JoinGame(GameType matchType, Guid playerId)
        {
            var gameList = Program.onlineMatchList
                .FindAll(x => x.gameType == matchType)
                .FindAll(x => x.operationState == GameOperationState.WaitingForPlayers);
            MatchState matchState = null;

            if (!gameList.Any())
            {
                matchState = new MatchState         //TODO: encapslate into factory
                {
                    id = Guid.NewGuid(),
                    gameType = matchType,
                    operationState = GameOperationState.WaitingForPlayers,
                    gameStartTime = DateTime.Now,
                    players = new List<Guid>
                    {
                        playerId,
                    },
                    inGameState = new TicTacToeState        //TODO: encapsulate into factory
                    {
                        firstPlayer = playerId,
                        secondPlayer = Guid.Empty,
                        board = new List<PlayerMark>(),     //TODO: encapsulate into factory
                    },

                };
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

            //set winner to player who didn't leave
            match.winnerId = match.players.Find(x => x != playerId);
            //set gamestate to completed 
            match.operationState = GameOperationState.Completed;
            //set match game length
            match.gameEndTime = DateTime.Now;

            //store match information in the database
            
            //eventually remove from game list
        }

        public MatchState PlayerMove(Guid matchId, Guid playerId, MovePosition move)
        {
            var match = Program.onlineMatchList.Find(x => x.id == matchId);
            MatchState matchState = null;
            if (match.players.Contains(playerId))
            {
                //verify player is playing in game
                //calculate new gamestate by sending move and state to game logic
            } else
            {
                //otherwise throw error that player is not in game or incorrect match Id
            }
            //return new game state
            return matchState;
        }

        public MatchState GetMatchState(Guid matchId)
        {
            return Program.onlineMatchList.Find(x => x.id == matchId);
        }
    }
}
