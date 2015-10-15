using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GameClient.GameServerService;

namespace GameClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DoStuff();
        }

        private void Window_SourceInitialized(object sender, EventArgs e)
        {

        }

        public void DoStuff()
        {
            try
            {
                this.Response.Text = "HEADS UP\n";
                this.Response.Text += ClientHelper.DoStuff();
            } 
            catch (Exception e)
            {
                this.Response.Text = "Unable to communicate with host." + e.Message;
            }
        }
    }
}
