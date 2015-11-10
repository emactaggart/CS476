using GameServer.Models;
using GameServer.Models.TicTacToe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Services
{
    [ServiceContract]
    interface IGameService
    {
        [OperationContract]
        MatchState JoinGame(GameType type, Guid playerId);

        [OperationContract]
        void Quit(Guid matchId, Guid playerId);

        [OperationContract]
        MatchState PlayerMove(Guid matchId, Guid playerId, MovePosition move);

        [OperationContract]
        MatchState GetMatchState(Guid matchId);
    }
}
