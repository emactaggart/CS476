using GameServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Data
{
    public static class ModelConverter
    {
        public static class FromRow
        {
            public static List<MatchResult> GetMatchResultsFromMatches(List<Match> matches)
            {
                var matchResults = matches.Select(x => new MatchResult
                {
                    id = x.id,
                    gameType = (GameType)x.game_type,
                    winnerId = x.winner_id,
                    gameStartTime = x.game_start_time,
                    gameEndTime = x.game_end_time,
                    players = x.Players.Select(y => y.id).ToList(),
                }).ToList();

                return matchResults;
            }

            public static PlayerProfile GetPlayerProfileFromPlayer(Player player)
            {
                return new PlayerProfile
                {
                    id = player.id,
                    username = player.username,
                };
            }

            public static GameInformation GetGameInformationFromGame(Game game)
            {
                return new GameInformation
                {
                    gameType = (GameType)game.id,
                    numberOfPlayers = game.number_of_players,
                    description = game.description
                };
            }
        }

        public static class ToRow
        {
            public static Match GetMatchFromMatchState(MatchState matchState)
            {
                return new Match 
                {
                    id = matchState.id,
                    game_type = (int)matchState.gameType,
                    winner_id = matchState.winnerId,
                    game_start_time = matchState.gameStartTime,
                    game_end_time = matchState.gameEndTime,
                };
            }

            public static Player GetPlayerFromPlayerProfile(PlayerProfile profile, string password)
            {
                return new Player 
                {
                    id = profile.id,
                    username = profile.username,
                    password = password,
                };
            }
        }
    }
}
