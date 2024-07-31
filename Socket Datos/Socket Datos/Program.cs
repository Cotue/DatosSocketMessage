using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Timers;
using System.Threading;
namespace SocketMessage
{
    public class Program
    {
        static void Main(string[] args)
        {
            Thread serverThread = new Thread(new ThreadStart(StartServer));
            serverThread.Start();

            // Delay to ensure the server starts first
            Thread.Sleep(1000);

            Client client = new Client();
            client.Start_client();
        }

        static void StartServer()
        {
            Server server = new Server();
            server.server();
        }

        
    }
}
