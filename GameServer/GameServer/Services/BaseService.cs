using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gameserver.Data.Models;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace GameServer.Services
{
    class BaseService : IInformationService, IGameService
    {
        public List<GameDetails> GetGameList()
        {
            throw new NotImplementedException();
        }

        public PlayerStats GetPlayerStats(Guid playerId)
        {
            throw new NotImplementedException();
        }

        public TicTacToeState JoinGame(GameType type, Guid playerId)
        {
            throw new NotImplementedException();
        }

        public bool LoginGuest()
        {
            throw new NotImplementedException();
        }

        public PlayerProfile LoginPlayer(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void LogoutPlayer(Guid playerId)
        {
            throw new NotImplementedException();
        }

        public TicTacToeState PlayerMove(Guid gameId, Guid playerId, TicTacToeMove move)
        {
            throw new NotImplementedException();
        }

        public void Quit(Guid gameId, Guid playerId)
        {
            throw new NotImplementedException();
        }
    }
}
