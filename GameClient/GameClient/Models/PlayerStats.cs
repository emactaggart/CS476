using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient.Models
{
    class PlayerStats
    {
        public Guid playerId { private set; get; }
        public float winLossRation { private set; get; }
        public int totalGames { private set; get; }
        public int totalWins { private set; get; }
        public int totalLosses { private set; get; }
        public List<TicTacToeResults> gameHistory { private set; get; }
    } 
}
