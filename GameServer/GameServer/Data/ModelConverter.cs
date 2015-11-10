using GameServer.Data.DataTransferObjects;
using GameServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Data
{
    class ModelConverter
    {
        public static class FromDto
        {
            public static List<MatchResult> GetMatchResultsFromDtos(List<MatchDto> matchDtos, List<MatchPlayerDto> playerDtos)
            {
                var matchList = matchDtos.Select(x => new MatchResult
                {
                    id = x.id,
                    gameType = (GameType)x.gameType,
                    winnerId = x.winnerId,
                    gameStartTime = x.gameStartTime,
                    gameEndTime = x.gameEndTime,
                    players = new List<Guid>(),
                }).ToList();

                matchList.ForEach(
                    match => match.players = playerDtos
                        .FindAll(y => y.matchId == match.id)
                        .Select(y => y.playerId).ToList());

                return matchList;
            }

            public static PlayerProfile GetPlayerProfileFromDto(PlayerDto playerDto)
            {
                return new PlayerProfile
                {
                    id = playerDto.id,
                    username = playerDto.username,
                };
            }

            public static GameInformation GetGameInformationFromDto(GameInformationDto dto)
            {
                return new GameInformation
                {
                    id = dto.id,
                    gameType = dto.gameType,
                    numberOfPlayers = dto.numberOfPlayers,
                    description = dto.description
                };
            }
        }

        public static class ToDto
        {
            public static MatchDto GetMatchDtoFromMatchState(MatchState matchState)
            {
                return new MatchDto
                {
                    id = matchState.id,
                    gameType = (int)matchState.gameType,
                    winnerId = matchState.winnerId,
                    gameStartTime = matchState.gameStartTime,
                    gameEndTime = matchState.gameEndTime,
                };
            }

            public static List<MatchPlayerDto> GetMatchPlayerListDtoFromMatchState(MatchState state)
            {
                var list = state.players
                    .Select(x => new MatchPlayerDto { matchId = state.id, playerId = x })
                    .ToList();
                return list;
            }

            public static PlayerDto GetPlayerDtoFromPlayerProfile(PlayerProfile profile, string password)
            {
                return new PlayerDto
                {
                    id = profile.id,
                    username = profile.username,
                    password = password,
                };
            }
        }
    }
}
