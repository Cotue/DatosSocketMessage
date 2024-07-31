using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketMessage
{
    class Client
    {
        public void sclient()
        {
            Socket listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint connect = new IPEndPoint(IPAddress.Parse("192.168.0.107"), 6400);
            listen.Connect(connect);
            byte[] sendinfo = new byte[100];
            string message;
            Console.WriteLine("Ingrese mensaje");
            message = Console.ReadLine();
            sendinfo = Encoding.Default.GetBytes(message);
            listen.Send(sendinfo);
            Console.ReadKey();
        }
    }
}
