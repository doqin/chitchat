using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class AppConfig
    {
        public string Username { get; set; } = "";
        public string UdpPort { get; set; } = "9999";
        public string ProfileImagePath { get; set; } = "";
        public Protocol.Server[] SavedServers { get; set; } = Array.Empty<Protocol.Server>();
    }
}
