using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketMessage
{
    public class Client
    {
        public void Start_client()
        {
            try
            {
                // Crear un socket
                Socket listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Crear el punto de conexión
                IPEndPoint connect = new IPEndPoint(IPAddress.Parse("192.168.0.100"), 5550);

                // Conectar al servidor
                listen.Connect(connect);

                while (true)
                {
                    // Solicitar información al usuario
                    Console.WriteLine("Ingrese la información (o 'salir' para terminar):");
                    string data = Console.ReadLine();

                    if (data.ToLower() == "salir")
                    {
                        byte[] info_salir = Encoding.UTF8.GetBytes(data);
                        listen.Send(info_salir);
                        break;
                    }

                    // Convertir la información a bytes
                    byte[] info_a_enviar = Encoding.UTF8.GetBytes(data); // Usar UTF8 para codificar

                    // Enviar la información
                    listen.Send(info_a_enviar);
                }

                Console.WriteLine("Conexión cerrada. Presione cualquier tecla para cerrar.");
                Console.ReadKey();

                // Cerrar el socket
                listen.Shutdown(SocketShutdown.Both);
                listen.Close();
            }
            catch (SocketException se)
            {
                Console.WriteLine($"Error de conexión: {se.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se produjo un error: {ex.Message}");
            }
        }
    }
}