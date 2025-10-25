using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol
{
    public enum Types
    {
        Broadcast,
        ChatMessage,
        Files,
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

        public long FileSize { get; set; }
    }
}
