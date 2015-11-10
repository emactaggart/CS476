using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using GameServer.Models.TicTacToe;

namespace GameServer.Models
{
    [DataContract]
    class TicTacToeState
    {
        [DataMember]
        public List<PlayerMark> board;
        [DataMember]
        public Guid firstPlayer;
        [DataMember]
        public Guid secondPlayer;
    }
}
