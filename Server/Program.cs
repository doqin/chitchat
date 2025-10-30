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
using System.Security.Cryptography;
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
            using (NetworkStream stream = client.GetStream())
            {
                try
                {
                    while (true)
                    {
                        // Read wrapper using length-prefixed protocol
                        string msg = Wrapper.ReadJson(stream);
                        if (msg == null)
                        {
                            Console.WriteLine($"Client {client.Client.RemoteEndPoint} disconnected");
                            break; // Client disconnected
                        }

                        Wrapper wrapper = JsonSerializer.Deserialize<Wrapper>(msg);
                        if (wrapper != null)
                        {
                            switch (wrapper.Type)
                            {
                                case Types.ChatMessage:
                                    HandleChatMessage(client, wrapper);
                                    break;
                                case Types.SendFiles:
                                    HandleFiles(client, stream, wrapper);
                                    break;
                                case Types.GetFile:
                                    SendFiles(client, stream, wrapper);
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
        }

        /// <summary>
        /// Hàm xử lý việc gửi file đến client
        /// </summary>
        /// <param name="client"></param>
        /// <param name="stream"></param>
        /// <param name="wrapper"></param>
        private static void SendFiles(TcpClient client, NetworkStream stream, Wrapper wrapper)
        {
            var fileName = wrapper.Payload;
            var filePath = Path.Combine("Received Files", fileName);
            if (System.IO.File.Exists(filePath))
            {
                // Creating file info
                Files files = new Files
                {
                    FileCount = 1,
                    FileList = new List<Protocol.File>
                    {
                        new Protocol.File
                        {
                            FileName = fileName,
                            FileSize = new FileInfo(filePath).Length
                        }
                    }
                };
                string payload = JsonSerializer.Serialize(files);
                Wrapper responseWrapper = new Wrapper
                {
                    Type = Types.SendFiles,
                    Payload = payload
                };
                string finalJson = JsonSerializer.Serialize(responseWrapper);
                Console.WriteLine($"Sending raw json: {finalJson}");
                Wrapper.SendJson(stream, finalJson);
                Console.WriteLine($"Client {client.Client.RemoteEndPoint} requested file: {fileName}");
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[8192];
                    int bytesRead;
                    while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        stream.Write(buffer, 0, bytesRead);
                    }
                }
                Console.WriteLine($"File {fileName} sent to {client.Client.RemoteEndPoint}");
            }
            else
            {
                Console.WriteLine($"Requested file not found: {fileName} from {client.Client.RemoteEndPoint}");
                Files payload = new Files
                {
                    FileCount = 0,
                    FileList = new List<Protocol.File>
                    {
                        new Protocol.File
                        {
                            FileName = fileName,
                            FileSize = 0
                        }
                    }
                };
                string payloadJson = JsonSerializer.Serialize(payload);
                Wrapper responseWrapper = new Wrapper
                {
                    Type = Types.SendFiles,
                    Payload = payloadJson
                };
                string finalJson = JsonSerializer.Serialize(responseWrapper);
                Wrapper.SendJson(stream, finalJson);
            }
        }

        /// <summary>
        /// Hàm xử lý nhận file từ client
        /// </summary>
        /// <param name="client"></param>
        /// <param name="ns"></param>
        /// <param name="wrapper"></param>
        private static void HandleFiles(TcpClient client, NetworkStream ns, Wrapper wrapper)
        {
            Protocol.Files files = JsonSerializer.Deserialize<Protocol.Files>(wrapper.Payload);
            if (files != null)
            {
                Console.WriteLine($"Received: {files.FileCount} file(s) from {client.Client.RemoteEndPoint}");
                string[] savedFiles = new string[files.FileList.Count];
                int i = 0;
                try
                {
                    byte[] excessBuffer = new byte[8192];
                    int excessBufferLength = 0;
                    foreach (var file in files.FileList)
                    {
                        Console.WriteLine($"Preparing to receive file: {file.FileName} ({file.FileSize} bytes)");
                        var savedPath = Path.Combine(Guid.NewGuid().ToString("N"), Path.GetFileName(file.FileName));
                        var fullPath = Path.Combine("Received Files", savedPath);
                        // Ensure the directory exists
                        string directoryPath = Path.GetDirectoryName(fullPath);
                        if (!string.IsNullOrEmpty(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }
                        else
                        {
                            Console.WriteLine("Invalid file path: no directory specified.");
                            return;
                        }
                        // Saving files
                        using (FileStream fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                        {
                            byte[] buffer = new byte[8192];
                            long totalRead = 0;
                            int bytesRead;

                            while (totalRead < file.FileSize && (bytesRead = ns.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                if (excessBufferLength > 0)
                                {
                                    // Write excess buffer first
                                    fs.Write(excessBuffer, 0, excessBufferLength);
                                    totalRead += excessBufferLength;
                                    excessBufferLength = 0;
                                    Console.WriteLine($"Wrote excess buffer of {excessBufferLength} bytes. Total read: {totalRead}");
                                }
                                int bytesToWrite = bytesRead;
                                // Check for excess data
                                if (bytesToWrite + totalRead > file.FileSize)
                                {
                                    excessBufferLength = (int)((long)bytesRead + totalRead - file.FileSize);
                                    Array.Copy(buffer, bytesRead - excessBufferLength, excessBuffer, 0, excessBufferLength);
                                    bytesToWrite = bytesRead - excessBufferLength;
                                    Console.WriteLine($"Excess data detected ({excessBufferLength}), storing in excess buffer.");
                                }
                                fs.Write(buffer, 0, bytesToWrite);
                                totalRead += bytesToWrite;
                                Console.WriteLine($"Read {bytesToWrite} bytes. Total read: {totalRead}");
                            }
                        }
                        Console.WriteLine($"File received: {file.FileName} ({savedPath})");
                        savedFiles[i] = savedPath;
                        i++;
                    }
                    // Send file info back to the client
                    FileConfirmation fileMessage = new FileConfirmation
                    {
                        AcceptedFiles = savedFiles.Select(file => new Attachment
                        {
                            FileName = file,
                            IsImage = Protocol.File.IsImage(Path.Combine("Received Files", file))
                        }).ToArray(),
                    };
                    string payload = JsonSerializer.Serialize(fileMessage);
                    Wrapper responseWrapper = new Wrapper
                    {
                        Type = Types.FileConfirmation,
                        Payload = payload
                    };
                    string finalJson = JsonSerializer.Serialize(responseWrapper);
                    Wrapper.SendJson(ns, finalJson);
                    Console.WriteLine("Sent file receipt confirmation to client.");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error receiving files: {e.Message}");
                    return;
                }
            }
        }

        /// <summary>
        /// Hàm xử lý nhận tin nhắn từ client
        /// </summary>
        /// <param name="client"></param>
        /// <param name="wrapper"></param>
        private static void HandleChatMessage(TcpClient client, Wrapper wrapper)
        {
            ChatMessage message = JsonSerializer.Deserialize<ChatMessage>(wrapper.Payload);
            if (message != null)
            {
                Console.WriteLine($"Received: [{message.TimeSent:HH:mm}] {message.Message} from {message.Username} @ {client.Client.RemoteEndPoint} ({message.Attachments.Length} attachments)");
                BroadcastMessage(message);
            }
        }

        /// <summary>
        /// Hàm gửi tin nhắn đến tất cả các client trừ người gửi.
        /// </summary>
        /// <param name="message">Nội dung tin nhắn</param>
        /// <param name="sender">Client người gửi tin nhắn</param>
        static void BroadcastMessage(ChatMessage message)
        {
            string payload = JsonSerializer.Serialize(message);
            Wrapper wrapper = new Wrapper
            {
                Type = Types.ChatMessage,
                Payload = payload
            };
            string finalJson = JsonSerializer.Serialize(wrapper);
            lock (clientsLock)
            {
                foreach (var c in clients)
                {
                    try
                    {
                        NetworkStream stream = c.GetStream();
                        Wrapper.SendJson(stream, finalJson);
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
