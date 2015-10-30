using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Gameserver.Data.Models
{
    [DataContract]
    class GameDetails
    {
        [DataMember]
        public Guid id;
        [DataMember]
        public string type;
        [DataMember]
        public int playerMin;
        [DataMember]
        public int playerMax;
        [DataMember]
        public string description;
    }
}
