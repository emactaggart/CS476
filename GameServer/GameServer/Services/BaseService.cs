using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameServer.Models;
using System.Runtime.Serialization;
using System.ServiceModel;
using GameServer.Models.TicTacToe;

namespace GameServer.Services
{
    class BaseService : IInformationService, IGameService
    {
        public List<GameInformation> GetGameList()
        {
            return Program.infoController.GetGameList();
        }

        public MatchState GetMatchState(Guid matchId)
        {
            return Program.gameController.GetMatchState(matchId);
        }

        public PlayerStats GetPlayerStats(Guid playerId)
        {
            return Program.infoController.GetPlayerStats(playerId);
        }

        public MatchState JoinGame(GameType type, Guid playerId)
        {
            return Program.gameController.JoinGame(type, playerId);
        }

        public PlayerProfile LoginGuest()
        {
            return Program.infoController.LoginGuest();
        }

        public PlayerProfile LoginPlayer(string username, string password)
        {
            return Program.infoController.LoginPlayer(username, password);
        }

        public void LogoutPlayer(Guid playerId)
        {
            Program.infoController.LogoutPlayer(playerId);
        }

        public MatchState PlayerMove(Guid matchId, Guid playerId, MovePosition move)
        {
            return Program.gameController.PlayerMove(matchId, playerId, move);
        }

        public void Quit(Guid matchId, Guid playerId)
        {
            Program.gameController.Quit(matchId, playerId);
        }
    }
}
