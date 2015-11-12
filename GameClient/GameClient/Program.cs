using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameClient.Controllers;
using GameClient.Server;
using GameClient.Utilities;
using GameClient.Views;

namespace GameClient 
{
    static class Program
    {
        public static InformationController infoController { get; }
        public static GameController gameController { get; }

        static Program()
        {
            var profile = new PlayerProfile();
            var stats = new BasicObservable<PlayerStats>(new PlayerStats()); //TODO probably don't need observer here
            var gameList = new BasicObservable<List<GameInformation>>(new List<GameInformation>()); //TODO: probably don't need observer here
            var gameService = new GameServiceClient();    //check for connection?
            var infoService = new InformationServiceClient();
            var state = new BasicObservable<MatchState>(new MatchState());
            infoController = new InformationController(infoService, profile, stats, gameList);
            gameController = new GameController(gameService, state);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SignupPage());
        }
    }
}
