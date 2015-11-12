using GameServer.Models.TicTacToe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Models
{
    public static class MatchFactory
    {
        public static MatchState CreateNewMatch(GameType matchType, Guid firstPlayerId)
        {
            return new MatchState
            {
                id = Guid.NewGuid(),
                gameType = matchType,
                operationState = GameOperationState.WaitingForPlayers,
                gameStartTime = DateTime.Now,
                playerTurnId = firstPlayerId,
                players = new List<Guid>
                    {
                        firstPlayerId,
                    },
                inGameState = TicTacToeFactory.CreateNewTicTacToe(firstPlayerId)
            };
        }
    }
}