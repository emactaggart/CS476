using GameServer.Models;
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
    interface IInformationService
    {
        [OperationContract]
        [FaultContract(typeof(GameServerFault))]
        PlayerStats GetPlayerStats(Guid playerId);

        [OperationContract]
        [FaultContract(typeof(GameServerFault))]
        List<GameInformation> GetGameList();

        [OperationContract]
        [FaultContract(typeof(GameServerFault))]
        void CreatePlayerAccount(string username, string password);

        [OperationContract]
        [FaultContract(typeof(GameServerFault))]
        PlayerProfile LoginPlayer(string username, string password);

        [OperationContract]
        [FaultContract(typeof(GameServerFault))]
        PlayerProfile LoginGuest();

        [OperationContract]
        [FaultContract(typeof(GameServerFault))]
        void LogoutPlayer(Guid playerId);
    }
}
