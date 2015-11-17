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
    public interface IGameService
    {
        [OperationContract]
        MatchState JoinGame(GameType type, Guid playerId);

        [OperationContract]
        [FaultContract(typeof(PlayerNotInSpecifiedGameFault))]
        [FaultContract(typeof(EmptyResultsFault))]
        void Quit(Guid matchId, Guid playerId);

        [OperationContract]
        [FaultContract(typeof(WaitingForPlayersFault))]
        [FaultContract(typeof(GameIsOverFault))]
        [FaultContract(typeof(PlayerNotInSpecifiedGameFault))]
        [FaultContract(typeof(NotPlayersTurnFault))]
        [FaultContract(typeof(InvalidPlayerMoveFault))]
        [FaultContract(typeof(EmptyResultsFault))]
        MatchState PlayerMove(Guid matchId, Guid playerId, MovePosition move);

        [OperationContract]
        [FaultContract(typeof(EmptyResultsFault))]
        MatchState GetMatchState(Guid matchId);
    }
}
