using GameServer.Models;
using GameServer.Models.TicTacToe;
using GameServer.Utilities;
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
        [FaultContract(typeof(GameServerFault))]
        MatchState JoinGame(GameType type, Guid playerId);

        [OperationContract]
        [FaultContract(typeof(GameServerFault))]
        void Quit(Guid matchId, Guid playerId);

        [OperationContract]
        [FaultContract(typeof(GameServerFault))]
        MatchState PlayerMove(Guid matchId, Guid playerId, MovePosition move);

        [OperationContract]
        [FaultContract(typeof(GameServerFault))]
        MatchState GetMatchState(Guid matchId);
    }
}
