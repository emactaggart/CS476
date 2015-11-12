using GameServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Data
{
    public class DataController
    {
        public void StoreMatch(MatchState matchState)
        {
            using (var context = new GameServerEntities())
            {
                var matchRow = ModelConverter.ToRow.GetMatchFromMatchState(matchState);
                context.Matches.Add(matchRow);
                context.SaveChanges();
            }
        }

        public List<GameInformation> RetrieveGameList() 
        {
            using (var context = new GameServerEntities())
            {
                var dataList = context.Games.ToList();

                var infoList = dataList
                    .Select(x => ModelConverter.FromRow.GetGameInformationFromGame(x))
                    .ToList();
                return infoList;
            }
        } 

        public PlayerProfile RetrievePlayerByUsername(string username)
        {
            using (var context = new GameServerEntities())
            {
                var playerRow = context.Players.Single(x => x.username == username);
                var profile = ModelConverter.FromRow.GetPlayerProfileFromPlayer(playerRow);
                return profile;
            }
        }

        public string RetreivePlayerPasswordById(Guid playerId)
        {
            using (var context = new GameServerEntities())
            {
                var playerRow = context.Players.Single(x => x.id == playerId);
                return playerRow.password;
            }
        }

        public List<MatchResult> RetrieveAllMatchesByPlayerId(Guid playerId)
        {
            using (var context = new GameServerEntities())
            {
                var matches = context.Matches.ToList();
                var matchPlayers = context.MatchPlayers.ToList();
                var resultList = ModelConverter.FromRow.GetMatchResultsFromMatches(matches, matchPlayers);
                return resultList;
            }
        }

        public void CreatePlayer(Guid userId, string username, string password)
        {
            using (var context = new GameServerEntities())
            {
                var player = new Player
                {
                    id = userId,
                    username = username,
                    password = password,
                };

                context.Players.Add(player);
                context.SaveChanges();
            }
        }

        public bool CheckUsernameExists(string username)
        {
            using (var context = new GameServerEntities())
            {
                var usernames = context.Players.ToList().Select(x => x.username).ToList();
                if (usernames.Contains(username))
                {
                    return true;
                }
                return false;
            }
        }
    }
}
