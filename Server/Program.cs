using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Program
    {
        static private readonly int port = 8080;
        static readonly List<TcpClient> clients = new List<TcpClient>();
        static readonly object clientsLock = new object();
        static TcpListener listener = new TcpListener(IPAddress.Any, port);

        static void Main(string[] args)
        {
            listener.Start();
            Console.WriteLine($"Server started on port {port}.");
            Broadcaster broadcaster = new Broadcaster(port);
            broadcaster.Start();
            Console.WriteLine("Broadcasting server presence...");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                lock (clientsLock)
                {
                    clients.Add(client);
                }
                Console.WriteLine($"Client connected: {client.Client.RemoteEndPoint}");
                Task.Run(() => HandleClient(client));
            }
        }

        /// <summary>
        /// Hàm xử lý kết nối từ một client.
        /// </summary>
        /// <param name="client">client</param>
        static void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];

            try
            {
                while (true)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break; // Client disconnected

                    string msg = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Received: {msg} from {client.Client.RemoteEndPoint}");
                    BroadcastMessage(msg, client);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error with client {client.Client.RemoteEndPoint}: {e.Message}");
            }
            finally
            {
                lock (clientsLock) clients.Remove(client);
                Console.WriteLine($"Client disconnected: {client.Client.RemoteEndPoint}");
                client.Close();
            }
        }

        /// <summary>
        /// Hàm gửi tin nhắn đến tất cả các client trừ người gửi.
        /// </summary>
        /// <param name="message">Nội dung tin nhắn</param>
        /// <param name="sender">Client người gửi tin nhắn</param>
        static void BroadcastMessage(string message, TcpClient sender)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            lock (clientsLock)
            {
                foreach (var c in clients)
                {
                    try
                    {
                        NetworkStream stream = c.GetStream();
                        stream.Write(data, 0, data.Length);
                        Console.WriteLine($"Sent to {c.Client.RemoteEndPoint}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error sending to client: {e.Message}");
                        // Ignore dead clients
                    }
                }
            }
        }
    }
}
