using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClient.GameServerService;

namespace GameClient.Services 
{
    class ClientHelper 
    {
        public static string DoStuff()
        {
            GameServerClient client = new GameServerClient();
            string response = "";

            double value1 = 100.00D;
            double value2 = 15.99D;
            double result = client.Add(value1, value2);
            response += String.Format("Add({0},{1}) = {2}\n", value1, value2, result);

            value1 = 145D;
            value2 = 76.52D;
            result = client.Subtract(value1, value2);
            response += String.Format("Subtract({0},{1}) = {2}\n", value1, value2, result);

            value1 = 9D;
            value2 = 81.25D;
            result = client.Multiply(value1, value2);
            response += String.Format("Multiply({0},{1}) = {2}\n", value1, value2, result);

            value1 = 22D;
            value2 = 7D;
            result = client.Divide(value1, value2);
            response += String.Format("Divide({0},{1}) = {2}\n", value1, value2, result);
            client.Close();

            return response;
        }
    }
}
