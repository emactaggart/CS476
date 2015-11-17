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
    public interface IInformationService
    {
        [OperationContract]
        [FaultContract(typeof(EmptyResultsFault))]
        PlayerStats GetPlayerStats(Guid playerId);

        [OperationContract]
        [FaultContract(typeof(EmptyResultsFault))]
        List<GameInformation> GetGameList();

        [OperationContract]
        [FaultContract(typeof(UsernameAlreadyExistsFault))]
        void CreatePlayerAccount(string username, string password);

        [OperationContract]
        [FaultContract(typeof(InvalidUsernameFault))]
        [FaultContract(typeof(InvalidPasswordFault))]
        PlayerProfile LoginPlayer(string username, string password);

        [OperationContract]
        PlayerProfile LoginGuest();

        [OperationContract]
        void LogoutPlayer(Guid playerId);
    }
}
