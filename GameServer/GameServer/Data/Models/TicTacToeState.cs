using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameServer.Data.Models.TicTacToe;
using System.Runtime.Serialization;

namespace Gameserver.Data.Models
{
    [DataContract]
    class TicTacToeState
    {
        [DataMember]
        public List<PlayerMark> board;
    }
}
