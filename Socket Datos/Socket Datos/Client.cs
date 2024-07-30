using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace SocketMessage
{
    public class Client
    {
        public void client()
        {
            Socket listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint connect = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6400);
            listen.Connect(connect);

            while (true)
            {
                Console.WriteLine("Ingrese mensaje (o 'exit' para salir):");
                string message = Console.ReadLine();

                if (message.ToLower() == "exit")
                    break;

                byte[] sendinfo = Encoding.Default.GetBytes(message);
                listen.Send(sendinfo);
            }

            listen.Shutdown(SocketShutdown.Both);
            listen.Close();
            Console.ReadKey();
        }
    }
    
 
}
