using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameClient.Views;
using GameClient.Models;
using GameClient.Controllers;
using GameClient.GameServerService;
using GameClient.Utilities;

namespace GameClient 
{
    static class Program
    {
        public static InformationController infoController { get; }
        public static GameController gameController { get; }

        static Program()
        {
            var profile = new PlayerProfile();
            var stats = new BasicObservable<PlayerStats>(new PlayerStats());
            var gameList = new BasicObservable<List<GameDetails>>(new List<GameDetails>());
            var server = new GameServerClient();    //check for connection?
            var state = new BasicObservable<GameState>();
            infoController = new InformationController(server, profile, stats, gameList);
            gameController = new GameController(server, state);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
