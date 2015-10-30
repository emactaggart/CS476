using Gameserver.Data.Models;
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
        TicTacToeState JoinGame(GameType type, Guid playerId);

        [OperationContract]
        void Quit(Guid gameId, Guid playerId);

        [OperationContract]
        TicTacToeState PlayerMove(Guid gameId, Guid playerId, TicTacToeMove move);
    }
}
