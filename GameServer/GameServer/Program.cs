using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace GameServer 
{
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface IGameServer
    {
        [OperationContract]
        PlayerStats GetPlayerStats(Guid playerId);

        [OperationContract]
        bool Login(Guid playerId, string password);

        [OperationContract]
        GameState PlayerMove(Guid playerId, Guid MatchId, Move move);

        [OperationContract]
        double Divide(double n1, double n2);

        [OperationContract]
        List<GameDetails> GetGameList();
    }

    public class PlayerStats { }
    public class Move { }
    public class GameState { }
    public class GameDetails { }

    public class GameServer : IGameServer
    {
        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            Console.WriteLine("Received Add({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Subtract(double n1, double n2)
        {
            double result = n1 - n2;
            Console.WriteLine("Received Subtract({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Multiply(double n1, double n2)
        {
            double result = n1 * n2;
            Console.WriteLine("Received Multiply({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Divide(double n1, double n2)
        {
            double result = n1 / n2;
            Console.WriteLine("Received Divide({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public bool Login(Guid playerId, string password)
        {
            throw new NotImplementedException();
        }

        public GameState PlayerMove(Guid playerId, Guid MatchId, Move move)
        {
            throw new NotImplementedException();
        }

        public PlayerStats GetPlayerStats(Guid playerId)
        {
            throw new NotImplementedException();
        }

        public List<GameDetails> GetGameList()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8000/GameServer/");

            ServiceHost selfHost = new ServiceHost(typeof(GameServer), baseAddress);

            try
            {
                selfHost.AddServiceEndpoint(typeof(IGameServer), new WSHttpBinding(), "Service");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                selfHost.Open();
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }
        }
    }
}
