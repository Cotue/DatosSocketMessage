using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SocketMessage
{
    public class Server
    {
        public void server()
        {
            Socket listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint connect = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6400);
            listen.Bind(connect);
            listen.Listen(10);

            Console.WriteLine("Servidor en espera de conexiones...");

            while (true)
            {
                Socket conexion = listen.Accept();
                Console.WriteLine("Conexión aceptada");

                byte[] getinfo = new byte[20000];
                int array_size = conexion.Receive(getinfo, 0, getinfo.Length, 0);

                if (array_size > 0)
                {
                    Array.Resize(ref getinfo, array_size);
                    string message = Encoding.Default.GetString(getinfo);
                    Console.WriteLine("La info recibida es: {0}", message);
                }

                conexion.Shutdown(SocketShutdown.Both);
               
                Console.ReadKey();
            }
        }
    }
}
