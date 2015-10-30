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
    interface IInformationService
    {
        [OperationContract]
        PlayerStats GetPlayerStats(Guid playerId);

        [OperationContract]
        List<GameDetails> GetGameList();

        [OperationContract]
        PlayerProfile LoginPlayer(string username, string password);

        [OperationContract]
        bool LoginGuest();

        [OperationContract]
        void LogoutPlayer(Guid playerId);
    }
}
