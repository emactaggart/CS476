using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameServer.Models;
using System.Runtime.Serialization;
using System.ServiceModel;
using GameServer.Models.TicTacToe;
using GameServer.Utilities;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace GameServer.Services
{
    public class BaseService : IInformationService, IGameService
    {
        private IInformationService _infoController;
        private IGameService _gameController;

        public BaseService()
        {
            _gameController = Program.gameController;
            _infoController = Program.infoController;
        }

        public BaseService(IGameService gameController, IInformationService infoController) 
        {
            _gameController = gameController;
            _infoController = infoController;
        }
            
        public PlayerStats GetPlayerStats(Guid playerId)
        {
            try
            {
                return _infoController.GetPlayerStats(playerId);
            }
            catch (EmptyResultsException e)
            {
                throw new FaultException<EmptyResultsFault>(new EmptyResultsFault());
            }
        }

        public List<GameInformation> GetGameList()
        {
            try
            {
                return Program.infoController.GetGameList();
            }
            catch (EmptyResultsException e)
            {
                throw new FaultException<EmptyResultsFault>(new EmptyResultsFault());
            }
        }

        public void CreatePlayerAccount(string username, string password)
        {
            try
            {
                _infoController.CreatePlayerAccount(username, password);
            }
            catch (UsernameAlreadyExistsException ue)
            {
                throw new FaultException<UsernameAlreadyExistsFault>(new UsernameAlreadyExistsFault());
            }
        }

        public PlayerProfile LoginPlayer(string username, string password)
        {
            try
            {
                return _infoController.LoginPlayer(username, password);
            }
            catch (InvalidUsernameException ue)
            {
                throw new FaultException<InvalidUsernameFault>(new InvalidUsernameFault());
            }
            catch (InvalidPasswordException pe)
            {
                throw new FaultException<InvalidPasswordFault>(new InvalidPasswordFault());
            }
        }

        public PlayerProfile LoginGuest()
        {
            return _infoController.LoginGuest();
        }

        public void LogoutPlayer(Guid playerId)
        {
            _infoController.LogoutPlayer(playerId);
        }

        public MatchState JoinGame(GameType type, Guid playerId)
        {
            return _gameController.JoinGame(type, playerId);
        }
        
        public void Quit(Guid matchId, Guid playerId)
        {
            try
            {
                _gameController.Quit(matchId, playerId);
            }
            catch (PlayerNotInSpecifiedGameException e)
            {
                throw new FaultException<PlayerNotInSpecifiedGameFault>(new PlayerNotInSpecifiedGameFault());
            }
            catch (EmptyResultsException e)
            {
                throw new FaultException<EmptyResultsFault>(new EmptyResultsFault());
            }
        }

        public MatchState PlayerMove(Guid matchId, Guid playerId, MovePosition move)
        {
            try
            {
                return _gameController.PlayerMove(matchId, playerId, move);
            }
            catch (WaitingForPlayersException e)
            {
                throw new FaultException<WaitingForPlayersFault>(new WaitingForPlayersFault());
            }
            catch (GameIsOverException e)
            {
                throw new FaultException<GameIsOverFault>(new GameIsOverFault());
            }
            catch (PlayerNotInSpecifiedGameException e)
            {
                throw new FaultException<PlayerNotInSpecifiedGameFault>(new PlayerNotInSpecifiedGameFault());
            }
            catch (NotPlayersTurnException e)
            {
                throw new FaultException<NotPlayersTurnFault>(new NotPlayersTurnFault());
            }
            catch (InvalidPlayerMoveException e)
            {
                throw new FaultException<InvalidPlayerMoveFault>(new InvalidPlayerMoveFault());
            }
            catch (EmptyResultsException e)
            {
                throw new FaultException<EmptyResultsFault>(new EmptyResultsFault());
            }
        }

        public MatchState GetMatchState(Guid matchId)
        {
            try
            {
                return _gameController.GetMatchState(matchId);
            }
            catch (EmptyResultsException e)
            {
                throw new FaultException<EmptyResultsFault>(new EmptyResultsFault());
            }
        }
    }
}
