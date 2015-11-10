using GameServer.Data.DataTransferObjects;
using GameServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Data
{
    class DataController
    {
        //TODO: get entity framework running
        public void StoreMatch(MatchState matchState)
        {
            var dto = ModelConverter.ToDto.GetMatchDtoFromMatchState(matchState);

            //save match to database
        }

        public List<GameInformation> RetrieveGameList() 
        {
            //get GameInformationDto list from database
            var DtoList = new List<GameInformationDto>();

            //convert DTOs to GameInformation
            var infoList = DtoList
                .Select(x => ModelConverter.FromDto.GetGameInformationFromDto(x))
                .ToList();
            //return list of GameInformation
            return infoList;
        } 

        public PlayerProfile RetrievePlayerByUsername(string username)
        {
            //get playerdto by username
            var dto = new PlayerDto();
            //convert playerdto to playerProfile
            var profile = ModelConverter.FromDto.GetPlayerProfileFromDto(dto);
            //return player profile
            return profile;

            //throw exception if player does not exist
        }

        public string RetreivePlayerPasswordById(Guid playerId)
        {
            //get playerDto by id
            var playerDto = new PlayerDto();
            //get password hash from palyerDto; return passwordHash
            return playerDto.password;
        }

        public List<MatchResult> RetrieveAllMatchesByPlayerId(Guid playerId)
        {
            //from matches get list of matchDtos given match ids
            var matchDtoList = new List<MatchDto>();
            //from MatchPlayerList table get matchIds with corresponding player id
            var matchPlayerDtoList = new List<MatchPlayerDto>();
            //convert matchDtos to matchState or MatchResults
            var resultList = ModelConverter.FromDto.GetMatchResultsFromDtos(matchDtoList, matchPlayerDtoList);
            //return match states
            return resultList;
        }
    }
}
