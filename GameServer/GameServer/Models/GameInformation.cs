using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GameServer.Models
{
    [DataContract]
    class GameInformation
    {
        [DataMember]
        public int id;
        [DataMember]
        public string gameType;
        [DataMember]
        public int numberOfPlayers;
        [DataMember]
        public string description;
    }
}
