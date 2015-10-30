using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Gameserver.Data.Models
{
    [DataContract]
    class TicTacToeResults
    {
        [DataMember]
        public Guid gameId;
        [DataMember]
        public Guid player1Id;
        [DataMember]
        public Guid player2Id;
        [DataMember]
        public Guid winnerId;
        [DataMember]
        public Guid loserId;
        [DataMember]
        public GameType type;
    }
}
