using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient.Models
{
    class TicTacToeMove
    {
        Guid gameId;
        Guid playerId;
        PlayerMark mark;
        BoardSquare location;
    }
}
