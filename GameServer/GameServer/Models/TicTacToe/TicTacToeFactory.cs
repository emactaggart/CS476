using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Models.TicTacToe
{
    public static class TicTacToeFactory
    {
        public static TicTacToeState CreateNewTicTacToe(Guid firstPlayerId)
        {
            return new TicTacToeState
                {
                    firstPlayer = firstPlayerId,
                    secondPlayer = Guid.Empty,
                    board = new List<PlayerMark>
                    {
                            PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                            PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                            PlayerMark.Empty, PlayerMark.Empty, PlayerMark.Empty,
                    },
                };
        }
    }
}
