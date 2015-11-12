using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GameServer.Models
{
    [DataContract]
    public class PlayerProfile
    {
        [DataMember]
        public Guid id;
        [DataMember]
        public string username;
    }
}
