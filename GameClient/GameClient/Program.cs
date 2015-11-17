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
            var stats = new PlayerStats();
            var gameList = new List<GameInformation>();
            var gameService = new GameServiceClient();
            var infoService = new InformationServiceClient();
            var state = new BasicObservable<MatchState>(new MatchState());
            infoController = new InformationController(infoService, profile, stats, gameList);
            gameController = new GameController(gameService, state);

            infoController.GetGameList();
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartupPage());
        }
    }
}
