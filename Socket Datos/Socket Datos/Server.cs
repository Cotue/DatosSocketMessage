using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketMessage
{
    class Server
    {
        public void Start()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 6400);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socket.Bind(endPoint);
            socket.Listen(10);

            Console.WriteLine("Esperando conexión...");

            Socket clientSocket = socket.Accept();
            Console.WriteLine("Cliente conectado");

            byte[] buffer = new byte[1024];
            int receivedDataLength = clientSocket.Receive(buffer);

            string receivedMessage = Encoding.Default.GetString(buffer, 0, receivedDataLength);
            Console.WriteLine("Mensaje recibido: " + receivedMessage);

            clientSocket.Close();
            socket.Close();
        }
    }
}

