using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameServer.Models;
using System.Runtime.Serialization;
using System.ServiceModel;
using GameServer.Models.TicTacToe;
using GameServer.Utilities;

namespace GameServer.Services
{
    class BaseService : IInformationService, IGameService
    {
        public void CreatePlayerAccount(string username, string password)
        {
            try
            {
                Program.infoController.CreatePlayerAccount(username, password);
            }
            catch (Exception e)
            {
                var fault = new GameServerFault(e.Message);
                throw new FaultException<GameServerFault>(fault);
            }
        }

        public List<GameInformation> GetGameList()
        {
            try
            {
                return Program.infoController.GetGameList();
            }
            catch (Exception e)
            {
                var fault = new GameServerFault(e.Message);
                throw new FaultException<GameServerFault>(fault);
            }
        }

        public MatchState GetMatchState(Guid matchId)
        {
            try
            {
                return Program.gameController.GetMatchState(matchId);
            }
            catch (Exception e)
            {
                var fault = new GameServerFault(e.Message);
                throw new FaultException<GameServerFault>(fault);
            }
        }

        public PlayerStats GetPlayerStats(Guid playerId)
        {
            try
            {
                return Program.infoController.GetPlayerStats(playerId);
            }
            catch (Exception e)
            {
                var fault = new GameServerFault(e.Message);
                throw new FaultException<GameServerFault>(fault);
            }
        }

        public MatchState JoinGame(GameType type, Guid playerId)
        {
            try
            {
                return Program.gameController.JoinGame(type, playerId);
            }
            catch (Exception e)
            {
                var fault = new GameServerFault(e.Message);
                throw new FaultException<GameServerFault>(fault);
            }
        }

        public PlayerProfile LoginGuest()
        {
            try
            {
                return Program.infoController.LoginGuest();
            }
            catch (Exception e)
            {
                var fault = new GameServerFault(e.Message);
                throw new FaultException<GameServerFault>(fault);
            }
        }

        public PlayerProfile LoginPlayer(string username, string password)
        {
            try
            {
                return Program.infoController.LoginPlayer(username, password);
            }
            catch (Exception e)
            {
                var fault = new GameServerFault(e.Message);
                throw new FaultException<GameServerFault>(fault);
            }
        }

        public void LogoutPlayer(Guid playerId)
        {
            try
            {
                Program.infoController.LogoutPlayer(playerId);
            }
            catch (Exception e)
            {
                var fault = new GameServerFault(e.Message);
                throw new FaultException<GameServerFault>(fault);
            }
        }

        public MatchState PlayerMove(Guid matchId, Guid playerId, MovePosition move)
        {
            try
            {
                return Program.gameController.PlayerMove(matchId, playerId, move);
            }
            catch (Exception e)
            {
                var fault = new GameServerFault(e.Message);
                throw new FaultException<GameServerFault>(fault);
            }
        }

        public void Quit(Guid matchId, Guid playerId)
        {
            try
            {
                Program.gameController.Quit(matchId, playerId);
            }
            catch (Exception e)
            {
                var fault = new GameServerFault(e.Message);
                throw new FaultException<GameServerFault>(fault);
            }
        }
    }
}
