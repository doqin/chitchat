using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using SixLabors.ImageSharp;

namespace Protocol
{
    public enum Types
    {
        /// <summary>
        /// Means server broadcasting its presence via UDP
        /// </summary>
        Broadcast,
        /// <summary>
        /// Means sending one message from the client to the server
        /// </summary>
        ChatMessage,
        /// <summary>
        /// Means requesting message(s) from the client
        /// </summary>
        GetMessages,
        /// <summary>
        /// Means server sending saved messages to requesting client
        /// </summary>
        SendMessages,
        SendFiles,
        GetFile,
        CheckFileExists,
        CheckFileExistsResponse,
        FileConfirmation,
        UpdateReaction,
        ConnectedUsers,
        UserConnected,
        UserUpdated,
        UserDisconnected,
    }

    public class Wrapper
    {
        public Types Type { get; set; }
        public string Payload { get; set; }

        /// <summary>
        /// Sends a wrapper with a 4-byte length prefix followed by the JSON data.
        /// </summary>
        /// <param name="stream">The network stream to write to</param>
        /// <param name="json">The JSON string to send</param>
        /// <param name="timeoutMs">Timeout in milliseconds (default: 30000ms)</param>
        /// <exception cref="ArgumentNullException">Thrown when stream or json is null</exception>
        /// <exception cref="IOException">Thrown when an I/O error occurs</exception>
        /// <exception cref="OperationCanceledException">Thrown when operation times out</exception>
        public static void SendJson(NetworkStream stream, string json, int timeoutMs = 30000)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
            if (json == null)
                throw new ArgumentNullException(nameof(json));

            stream.WriteTimeout = timeoutMs;

            try
            {
                byte[] data = Encoding.UTF8.GetBytes(json);
                byte[] lengthPrefix = BitConverter.GetBytes(data.Length);

                // Send length prefix (4 bytes)
                stream.Write(lengthPrefix, 0, lengthPrefix.Length);
                // Send JSON data
                stream.Write(data, 0, data.Length);
            }
            catch (IOException ex) when (ex.InnerException is TimeoutException)
            {
                throw new OperationCanceledException("Send operation timed out.", ex);
            }
        }

        /// <summary>
        /// Reads JSON from the stream by first reading a 4-byte length prefix, then reading the exact number of bytes.
        /// </summary>
        /// <param name="stream">The network stream to read from</param>
        /// <param name="timeoutMs">Timeout in milliseconds (default: 30000ms)</param>
        /// <returns>The JSON string, or null if the connection was closed</returns>
        /// <exception cref="ArgumentNullException">Thrown when stream is null</exception>
        /// <exception cref="IOException">Thrown when an I/O error occurs</exception>
        /// <exception cref="OperationCanceledException">Thrown when operation times out</exception>
        public static string ReadJson(NetworkStream stream, int timeoutMs = Timeout.Infinite)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            stream.ReadTimeout = timeoutMs;

            try
            {
                // Read the 4-byte length prefix
                byte[] lengthBuffer = new byte[4];
                int bytesRead = 0;
                while (bytesRead < 4)
                {
                    try
                    {
                        int read = stream.Read(lengthBuffer, bytesRead, 4 - bytesRead);
                        if (read == 0)
                            return null; // Connection closed
                        bytesRead += read;
                    }
                    catch
                    {
                        throw new SocketException((int)SocketError.ConnectionReset);
                    }
                }

                int messageLength = BitConverter.ToInt32(lengthBuffer, 0);

                // Read the exact message
                byte[] buffer = new byte[messageLength];
                bytesRead = 0;
                while (bytesRead < messageLength)
                {
                    int read = stream.Read(buffer, bytesRead, messageLength - bytesRead);
                    if (read == 0)
                        return null; // Connection closed
                    bytesRead += read;
                }

                string json = Encoding.UTF8.GetString(buffer, 0, messageLength);
                return json;
            }
            catch (IOException ex) when (ex.InnerException is TimeoutException)
            {
                throw new OperationCanceledException("Read operation timed out.", ex);
            }
        }
    }

    public class User
    {
        public TcpClient Client { get; set; }
    }

    public class ConnectedUsers
    {
        public List<UserConnected> Users { get; set; } = new List<UserConnected>();
    }

    public class UserConnected
    {
        public string Username { get; set; }
        public string ProfileImagePath { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
    }

    public class UserDisconnected
    {
        public string Address { get; set; }
    }

    public class UserUpdated
    {
        public string Username { get; set; }
        public string ProfileImagePath { get; set; }
        public string Address { get; set; }
    }

    public class UpdateReaction
    {
        public string MessageId { get; set; }
        public string Emoji { get; set; }
        public string UserId { get; set; } // Which is the client's IP for now
    }

    public class GetMessages
    {
        public int Count { get; set; }
        public DateTime Before { get; set; }
    }

    public class SendMessages
    {
        public ChatMessage[] Messages { get; set; }
    }

    public class ChatMessage
    {
        public string Id { get; set; }
        public DateTime TimeSent { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
        public string Address { get; set; }
        public string ProfileImagePath { get; set; }
        public Attachment[] Attachments { get; set; }
        public ReactionState ReactionState { get; set; }
    }

    public class Attachment
    {
        public string FileName { get; set; }
        public bool IsImage { get; set; }
    }

    public class FileConfirmation
    {
        public Attachment[] AcceptedFiles { get; set; }
        public Attachment[] RejectedFiles { get; set; }
    }

    public class Broadcast
    {
        public string ServerName { get; set; }
        public int TcpPort { get; set; }
    }

    public class Server : IEquatable<Server>
    {
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public int Port { get; set; }

        public bool Equals(Server other)
        {
            return other != null &&
                   Name == other.Name &&
                   IPAddress == other.IPAddress &&
                   Port == other.Port;
        }

        public override string ToString()
        {
            return $"{Name} @ {IPAddress}:{Port}";
        }
    }

    public class SendFiles
    {
        public long FileCount { get; set; }
        public List<File> FileList { get; set; }
        public bool MangleFileNames { get; set; } = true;
    }

    public class CheckFileExistsResponse
    {
        public string FileName { get; set; }
        public bool Exists { get; set; }
    }

    public class File
    {
        public string FileName { get; set; }

        public long FileSize { get; set; }

        public static string FetchFile(IPAddress address, int port, string filePath, string savePath)
        {
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    var connectResult = client.BeginConnect(address, port, null, null).AsyncWaitHandle.WaitOne(5000); // 5 seconds timeout
                    if (!connectResult)
                    {
                        throw new TimeoutException("Connection timed out.");
                    }
                    var stream = client.GetStream();
                    var request = new Wrapper
                    {
                        Type = Types.GetFile,
                        Payload = filePath
                    };
                    var json = JsonSerializer.Serialize(request);
                    Wrapper.SendJson(stream, json);
                    var wrapperJson = Wrapper.ReadJson(stream, 10000); // 10 seconds timeout
                    var wrapper = JsonSerializer.Deserialize<Wrapper>(wrapperJson);
                    if (wrapper.Type != Types.SendFiles)
                    {
                        System.Diagnostics.Debug.WriteLine("Unexpected response type when fetching file.");
                        return "Not found";
                    }
                    SendFiles files = JsonSerializer.Deserialize<SendFiles>(wrapper.Payload);
                    System.Diagnostics.Debug.WriteLine($"Client is ready to receive {files?.FileCount} file(s).");
                    var file = files.FileList[0]; // Most likely only one file
                    System.Diagnostics.Debug.WriteLine($"Preparing to receive file: {file.FileName} ({file.FileSize} bytes)");
                    // Ensure the directory exists
                    string directoryPath = Path.GetDirectoryName(savePath);
                    if (!string.IsNullOrEmpty(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid file path: no directory specified.");
                        return "Not found";
                    }
                    // Saving files
                    using (FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write))
                    {
                        byte[] buffer = new byte[8192];
                        long totalRead = 0;
                        int bytesRead;

                        // Read exactly the declared file size to avoid consuming the next protocol frame
                        while (totalRead < file.FileSize)
                        {
                            int toRead = (int)Math.Min(buffer.Length, file.FileSize - totalRead);
                            bytesRead = stream.Read(buffer, 0, toRead);
                            System.Diagnostics.Debug.WriteLine($"Read {bytesRead} bytes");
                            if (bytesRead <= 0)
                            {
                                break; // connection closed
                            }
                            fs.Write(buffer, 0, bytesRead);
                            totalRead += bytesRead;
                        }
                    }
                    System.Diagnostics.Debug.WriteLine($"File received: {file.FileName}");
                    return savePath;
                }
            }
            catch (TimeoutException)
            {
                System.Diagnostics.Debug.WriteLine("Connection timed out.");
                return "Not found";
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"Error fetching file: {e.Message}");
                return "Not found";
            }
        }

        /// <summary>
        /// Checks if the specified file is a valid image.
        /// </summary>
        /// <param name="filePath">The path to the specified file</param>
        /// <returns>True if the file is an image</returns>
        public static bool IsImage(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath) || !System.IO.File.Exists(filePath))
                return false;

            try
            {
                // Attempt to load the file as an image
                using (var img = Image.Load(filePath))
                {
                    return true;
                }
            }
            catch (Exception) 
            {
                // Other exceptions
                return false;
            }
        }

        /// <summary>
        /// Renames the specified file to a unique name using a GUID while preserving the original file extension.
        /// </summary>
        /// <param name="filePath">The path to the specified file</param>
        /// <returns>The path of the newly named file</returns>
        /// <exception cref="ArgumentException">The specified file path is null or empty</exception>
        /// <exception cref="FileNotFoundException">The specified file does not exist</exception>
        /// <exception cref="InvalidOperationException">Invalid directory</exception>
        /// <exception cref="IOException">An error occurred while renaming the file</exception>
        public static string RenameToUniqueName(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
            }

            if (!System.IO.File.Exists(filePath))
            {
                throw new FileNotFoundException("The specified file does not exist.", filePath);
            }

            string directory = Path.GetDirectoryName(filePath) ?? throw new InvalidOperationException("Invalid directory.");
            string extension = Path.GetExtension(filePath);
            string uniqueName = Guid.NewGuid().ToString("N") + extension; // "N" format removes hyphens
            string newFilePath = Path.Combine(directory, uniqueName);

            try
            {
                System.IO.File.Move(filePath, newFilePath);
            }
            catch (IOException ex)
            {
                throw new IOException("An error occurred while renaming the file.", ex);
            }

            return newFilePath;
        }
    }

    public class ReactionState
    {
        public string MessageId { get; set; }
        public Dictionary<string, HashSet<string>> Emoji_To_Users { get; set; } = new Dictionary<string, HashSet<string>>();

        public ReactionState()
        {
            MessageId = string.Empty;
        }

        public ReactionState(string messageId)
        {
            MessageId = messageId;
        }

        // Lấy số lượng react cho mỗi emoji
        public Dictionary<string, int> GetEmojiCounts()
        {
            return Emoji_To_Users.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Count);
        }

        public bool HasUserReacted(string emoji, string username)
        {
            return Emoji_To_Users.ContainsKey(emoji) && Emoji_To_Users[emoji].Contains(username);
        }
    }
}
