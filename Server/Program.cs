using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Protocol;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Server
{
    internal class Program
    {
        static readonly List<TcpClient> clients = new List<TcpClient>();
        static readonly object clientsLock = new object();
        static TcpListener listener;

        static void Main(string[] args)
        {
            // Set up configuration
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // Sets the base path to the app's folder
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration config = builder.Build();

            // Read the settings
            string serverName = config["ServerSettings:Name"];
            int tcpPort = int.Parse(config["ServerSettings:TCPPort"]);
            int udpPort = int.Parse(config["ServerSettings:UDPPort"]);

            listener = new TcpListener(IPAddress.Any, tcpPort);

            listener.Start();
            Console.WriteLine($"Server started on port {tcpPort}.");
            Broadcaster broadcaster = new Broadcaster(serverName, tcpPort, udpPort);
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
                    Wrapper wrapper = JsonSerializer.Deserialize<Wrapper>(msg);
                    if (wrapper != null)
                    {
                        switch (wrapper.Type)
                        {
                            case Types.ChatMessage:
                                ChatMessage message = JsonSerializer.Deserialize<ChatMessage>(wrapper.Payload);
                                if (message != null)
                                {
                                    Console.WriteLine($"Received: [{message.TimeSent:HH:mm}] {message.Message} from {message.Username} @ {client.Client.RemoteEndPoint}");
                                    BroadcastMessage(message, client);
                                }
                                break;
                            default:
                                Console.WriteLine("Unknown message type received.");
                                continue;
                        }
                    }
                    
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
        static void BroadcastMessage(ChatMessage message, TcpClient sender)
        {
            string payload = JsonSerializer.Serialize(message);
            Wrapper wrapper = new Wrapper
            {
                Type = Types.ChatMessage,
                Payload = payload
            };
            string finalJson = JsonSerializer.Serialize(wrapper);
            byte[] data = Encoding.UTF8.GetBytes(finalJson);
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
