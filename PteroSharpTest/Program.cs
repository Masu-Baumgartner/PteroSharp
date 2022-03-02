using System;
using System.IO;

using Logging.Net;

using PteroSharp;

namespace PteroSharpTest
{
    class Program
    {
        private static PteroClient Client { get; set; }

        public static void Main(string[] args)
        {
            string[] config = File.ReadAllText("config.keys").Split(";"); // Only used for debbuging
                                                                          // Set yout own values below
            Client = new PteroClient();
            Client.PterodactylUrl = config[0];
            Client.AppPool.AddKey(config[2]);
            Client.ClientPool.AddKey(config[1]);

            /*
             * See all nodes
             * 
            foreach(var node in Client.Nodes)
            {
                Logger.Info("Node found: " + node.Name);

                //if (node.Name == "Node 1") Test for renaming nodes
                //    node.Name = "Testy";
            }
            */

            /*
             * See all users
             * */
            foreach(var user in Client.Users)
            {
                Logger.Info("User found: " + user.Username);
            }
            /*/

            /* Renaming
            var server = Client.FindServerById(667);
            server.Name = "Test";
            */

            /* Update limits
            var server2 = Client.FindServerById(667);
            var limits = server2.Limits;

            limits.Disk = 2048;

            server2.Limits = limits;
            */

            /* Toggle suspension
            var server3 = Client.FindServerById(667);
            Logger.Debug("Server suspended: " + server3.Suspended);
            server3.Suspended = !server3.Suspended;
            */

            /* Change startup args
            var server4 = Client.FindServerById(667);

            var con = server4.Container;

            if (con.Environment.ContainsKey("AUTO_UPDATE"))
                con.Environment["AUTO_UPDATE"] = "1";
            else
                con.Environment.Add("AUTO_UPDATE", "1");

            server4.Container = con;
            */

            /* Server resource view
            var server5 = Client.FindServerById(540);

            Logger.Info(server5.Status.CpuAbsolute);
            */
            /*
            var server6 = Client.FindServerById(540);

            server6.Console.OnConsoleContentAdded += OnMessage;
            server6.Console.Subscribe();
            */
            Logger.Debug("End reached");

            Console.ReadLine();
        }

        private static void OnMessage(object sender, string e)
        {
            Logger.Warn(e);
        }
    }
}
