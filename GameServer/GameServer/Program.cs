using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using GameServer.Models;
using GameServer.Services;
using GameServer.Controllers;
using GameServer.Data;

namespace GameServer
{
    class Program
    {
        //TODO: ensure both these are singletons with locking write access
        public static List<MatchState> onlineMatchList = new List<MatchState>();
        public static List<PlayerProfile> onlinePlayerList = new List<PlayerProfile>();
        public static GameController gameController = new GameController(new DataController(), onlineMatchList);
        public static InformationController infoController = new InformationController(new DataController(), onlinePlayerList);

        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8000/");
            ServiceHost selfHost = new ServiceHost(typeof(BaseService), baseAddress);

            try
            {
                selfHost.AddServiceEndpoint(typeof(IInformationService), new WSHttpBinding(), "Info");
                selfHost.AddServiceEndpoint(typeof(IGameService), new WSHttpBinding(), "Game");


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
