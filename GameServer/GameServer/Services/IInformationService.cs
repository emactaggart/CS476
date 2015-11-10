using GameServer.Models;
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
        List<GameInformation> GetGameList();

        [OperationContract]
        PlayerProfile LoginPlayer(string username, string password);

        [OperationContract]
        PlayerProfile LoginGuest();

        [OperationContract]
        void LogoutPlayer(Guid playerId);
    }
}
