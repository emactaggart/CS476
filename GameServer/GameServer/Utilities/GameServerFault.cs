using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Utilities
{
    public class GameServerFault
    {
        string message { get; set; }

        public GameServerFault()
        {
            message = "";
        }

        public GameServerFault(string m)
        {
            message = m;
        }
    }
}
