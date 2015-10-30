using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Gameserver.Data.Models
{
    [DataContract]
    class PlayerStats
    {
        [DataMember]
        public Guid playerId;
        [DataMember]
        public float winLossRation;
        [DataMember]
        public int totalGames;
        [DataMember]
        public int totalWins;
        [DataMember]
        public int totalLosses;
        [DataMember]
        public List<TicTacToeResults> gameHistory;
    } 
}
