using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Utilities
{
    [DataContract]
    public class GameServerFault
    {
        [DataMember]
        public string Message;

        public GameServerFault()
        {
            Message = "";
        }

        public GameServerFault(string m)
        {
            Message = m;
        }
    }

    public class GameIsOverFault : GameServerFault { }
    public class NotPlayersTurnFault : GameServerFault { }
    public class InvalidPlayerMoveFault : GameServerFault { }
    public class UsernameAlreadyExistsFault : GameServerFault { }
    public class InvalidPasswordFault : GameServerFault { }
    public class InvalidUsernameFault : GameServerFault { }
    public class EmptyResultsFault : GameServerFault { }
    public class InvalidGameRequestFault : GameServerFault { }
    public class WaitingForPlayersFault : GameServerFault { }
    public class PlayerNotInSpecifiedGameFault : GameServerFault { }
}
