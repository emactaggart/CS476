using GameServer.Data;
using GameServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Controllers
{
    class InformationController
    {
        private DataController _dataController;

        public InformationController(DataController data)
        {
            _dataController = data;
        }

        public PlayerStats GetPlayerStats(Guid playerId)
        {
            //get game history/MatchResults from data
            //count how many games won vs total player
            //return newly created stats 
            return new PlayerStats();
        }

        public List<GameInformation> GetGameList()
        {
            //get game details list from Data
            var gameList = _dataController.RetrieveGameList();
            //organize and return
            return gameList;
        }

        //TODO: create player account

        public PlayerProfile LoginPlayer(string username, string password)
        {
            //check player username and find player guid
            var profile = _dataController.RetrievePlayerByUsername(username);
            //compare password to that in database
            var storePassword = _dataController.RetreivePlayerPasswordById(profile.id);

            if (password != storePassword)
            {
                throw new Exception("Invalid password!");
            }

            //add player uid to online players
            Program.onlinePlayerList.Add(profile);

            //return player profile or player guid
            return profile;
        }

        public PlayerProfile LoginGuest()
        {
            //create guid for guest as each player must have a unique guid
            //(maybe) load guid into players currently online
            //(maybe) return guid
            var guest = new PlayerProfile
            {
                id = Guid.NewGuid(),
                username = "Guest",
            };
            return guest;
        }

        public void LogoutPlayer(Guid playerId)
        {
            //remove PlayerId from players currently online
            var index = Program.onlinePlayerList.FindIndex(x => x.id == playerId);
            Program.onlinePlayerList.RemoveAt(index);
        }
    }
}
