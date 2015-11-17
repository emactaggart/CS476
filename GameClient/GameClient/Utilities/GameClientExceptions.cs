using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient.Utilities
{
    public class InvalidPasswordException : Exception { }
    public class NoGameSelectedException : Exception { }
    public class GameNotImplementedException : Exception { }
}
