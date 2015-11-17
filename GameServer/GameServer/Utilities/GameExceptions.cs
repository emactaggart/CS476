using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Utilities
{
    public class GameIsOverException : Exception
    {
        public GameIsOverException() : base() { }
        public GameIsOverException(string message) : base(message) { }
    }

    public class NotPlayersTurnException : Exception
    {
        public NotPlayersTurnException() : base() { }
        public NotPlayersTurnException(string message) : base(message) { }
    }

    public class InvalidPlayerMoveException : Exception
    {
        public InvalidPlayerMoveException() : base() { }
        public InvalidPlayerMoveException(string message) : base(message) { }
    }

    public class UsernameAlreadyExistsException : Exception
    {
        public UsernameAlreadyExistsException() : base() { }
        public UsernameAlreadyExistsException(string message) : base(message) { }
    }

    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException() : base() { }
        public InvalidPasswordException(string message) : base(message) { }
    }

    public class InvalidUsernameException : Exception
    {
        public InvalidUsernameException() : base() { }
        public InvalidUsernameException(string message) : base(message) { }
    }

    public class EmptyResultsException : Exception
    {
        public EmptyResultsException() : base() { }
        public EmptyResultsException(string message) : base(message) { }
    }

    public class InvalidGameRequestException : Exception
    {
        public InvalidGameRequestException() : base() { }
        public InvalidGameRequestException(string message) : base(message) { }
    }

    public class WaitingForPlayersException : Exception
    {
        public WaitingForPlayersException() : base() { }
        public WaitingForPlayersException(string message) : base(message) { }
    }

    public class PlayerNotInSpecifiedGameException : Exception
    {
        public PlayerNotInSpecifiedGameException() : base() { }
        public PlayerNotInSpecifiedGameException(string message) : base(message) { }
    }

}
