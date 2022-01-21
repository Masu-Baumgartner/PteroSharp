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

            foreach(var node in Client.Nodes)
            {
                Logger.Info("Node found: " + node.Name);

                //if (node.Name == "Node 1") Test for renaming nodes
                //    node.Name = "Testy";
            }

            Console.ReadLine();
        }
    }
}
