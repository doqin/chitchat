using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using System.Net;

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
        /// <exception cref="ArgumentNullException">Thrown when stream or json is null</exception>
        /// <exception cref="IOException">Thrown when an I/O error occurs</exception>
        public static void SendJson(NetworkStream stream, string json)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
            if (json == null)
                throw new ArgumentNullException(nameof(json));

            byte[] data = Encoding.UTF8.GetBytes(json);
            byte[] lengthPrefix = BitConverter.GetBytes(data.Length);

            // Send length prefix (4 bytes)
            stream.Write(lengthPrefix, 0, lengthPrefix.Length);
            // Send JSON data
            stream.Write(data, 0, data.Length);
        }

        /// <summary>
        /// Reads JSON from the stream by first reading a 4-byte length prefix, then reading the exact number of bytes.
        /// </summary>
        /// <param name="stream">The network stream to read from</param>
        /// <returns>The JSON string, or null if the connection was closed</returns>
        /// <exception cref="ArgumentNullException">Thrown when stream is null</exception>
        /// <exception cref="IOException">Thrown when an I/O error occurs</exception>
        public static string ReadJson(NetworkStream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            // Read the 4-byte length prefix
            byte[] lengthBuffer = new byte[4];
            int bytesRead = 0;
            while (bytesRead < 4)
            {
                int read = stream.Read(lengthBuffer, bytesRead, 4 - bytesRead);
                if (read == 0)
                    return null; // Connection closed
                bytesRead += read;
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
    }

    public class User
    {
        public string Username { get; set; }
        public TcpClient Client { get; set; }
    }

    public class ConnectedUsers
    {
        public List<string> Usernames { get; set; }
    }

    public class UserConnected
    {
        public string Username { get; set; }
    }

    public class UserDisconnected
    {
        public string Username { get; set; }
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

        public static async Task<string> FetchFileAsync(TcpClient client, Dictionary<string, Tuple<TaskCompletionSource<string>, string>> pendingFetches, string filePath, string savePath, string json)
        {
            try
            {
                NetworkStream ns = client.GetStream();
                Wrapper.SendJson(ns, json);
                var tcs = new TaskCompletionSource<string>();
                var tuple = new Tuple<TaskCompletionSource<string>, string>(tcs, savePath);
                pendingFetches[filePath] = tuple;
                return await tcs.Task;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"Error fetching file: {e.Message}");
                return "Not found";
            }
        }

        public static string FetchFile(TcpClient client, Dictionary<string, Tuple<TaskCompletionSource<string>, string>> pendingFetches, string filePath, string savePath, string json)
        {
            try
            {
                NetworkStream ns = client.GetStream();
                Wrapper.SendJson(ns, json);
                var tcs = new TaskCompletionSource<string>();
                var tuple = new Tuple<TaskCompletionSource<string>, string>(tcs, savePath);
                pendingFetches[filePath] = tuple;
                tcs.Task.Wait();
                return tcs.Task.Result;
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
                using (var img = Image.FromFile(filePath))
                {
                    return true;
                }
            }
            catch (OutOfMemoryException)
            {
                // Thrown by Image.FromFile if the file is not a valid image format
                return false;
            }
            catch (FileNotFoundException)
            {
                // File does not exist
                return false;
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
