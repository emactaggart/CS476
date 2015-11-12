using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GameServer.Models
{
    [DataContract]
    public class GameInformation
    {
        [DataMember]
        public GameType gameType;
        [DataMember]
        public int numberOfPlayers;
        [DataMember]
        public string description;
    }
}
