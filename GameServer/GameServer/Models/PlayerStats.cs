using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Models
{
    [DataContract]
    public class PlayerStats
    {
        [DataMember]
        public Guid playerId;
        [DataMember]
        public float winLossRatio;
        [DataMember]
        public int totalGames;
        [DataMember]
        public int totalWins;
        [DataMember]
        public int totalLosses;
        [DataMember]
        public List<MatchResult> gameHistory;
    } 
}
