using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Protocol
{
    public enum Types
    {
        Broadcast,
        ChatMessage,
        SendFiles,
        GetFiles,
        FileConfirmation,
    }

    public class Wrapper
    {
        public Types Type { get; set; }
        public string Payload { get; set; }
    }

    public class ChatMessage
    {
        public DateTime TimeSent { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
        public string[] Attachments { get; set; }
    }

    public class FileConfirmation
    {
        public string[] AcceptedFiles { get; set; }
        public string[] RejectedFiles { get; set; }
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

    public class Files
    {
        public string FileCount { get; set; }
        public List<File> FileList { get; set; }
    }

    public class File
    {
        public string FileName { get; set; }

        // Not important when using GetFiles protocol
        public long FileSize { get; set; }

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
}
