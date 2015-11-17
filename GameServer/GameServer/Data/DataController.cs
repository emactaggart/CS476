using GameServer.Models;
using GameServer.Utilities;
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
                var players = context.Players.Where(x => matchState.players.Contains(x.id)).ToList();
                var matchRow = ModelConverter.ToRow.GetMatchFromMatchState(matchState);
                if (players.Count == 0)
                {
                    throw new EmptyResultsException();
                }
                matchRow.Players = players;
                context.Matches.Add(matchRow);
                context.SaveChanges();
            }
        }

        public List<GameInformation> RetrieveGameList() 
        {
            using (var context = new GameServerEntities())
            {
                var dataList = context.Games.ToList();
                if (dataList.Count == 0)
                {
                    throw new EmptyResultsException();
                }
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
                var playerRow = context.Players.FirstOrDefault(x => x.username == username);
                if (playerRow == null)
                {
                    throw new InvalidUsernameException();
                }
                var profile = ModelConverter.FromRow.GetPlayerProfileFromPlayer(playerRow);
                return profile;
            }
        }

        public string RetrievePlayerPasswordById(Guid playerId)
        {
            using (var context = new GameServerEntities())
            {
                var playerRow = context.Players.Single(x => x.id == playerId);
                if (playerRow.Equals(null))
                {
                    throw new EmptyResultsException();
                }
                return playerRow.password;
            }
        }

        public List<MatchResult> RetrieveAllMatchesByPlayerId(Guid playerId)
        {
            using (var context = new GameServerEntities())
            {
                var matches = context.Matches.Where(x => x.Players.Select(y => y.id).Contains(playerId)).ToList();
                var resultList = new List<MatchResult>();
                if (matches.Count() != 0)
                {
                    resultList = ModelConverter.FromRow.GetMatchResultsFromMatches(matches);
                } 
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
                if (usernames.Count == 0)
                {
                    throw new EmptyResultsException();
                }
                if (usernames.Contains(username))
                {
                    return true;
                }
                return false;
            }
        }
    }
}
