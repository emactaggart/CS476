using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Data.DataTransferObjects
{
    class MatchDto
    {
        public Guid id;
        public Guid winnerId;
        public DateTime gameStartTime;
        public DateTime gameEndTime;
        public int gameType;
    }
}
