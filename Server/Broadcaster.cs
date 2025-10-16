using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Broadcaster
    {
        private readonly int tcpPort;
        private readonly int udpPort;
        private readonly int intervalMs;
        private bool running = true;

        /// <summary>
        /// Tạo một Broadcaster để phát hiện máy chủ qua UDP broadcast.
        /// </summary>
        /// <param name="tcpPort">Port TCP</param>
        /// <param name="udpPort">Port UDP</param>
        /// <param name="intervalMs">Tần số phát thông tin máy chủ</param>
        public Broadcaster(int tcpPort, int udpPort = 9999, int intervalMs = 2000)
        {
            this.tcpPort = tcpPort;
            this.udpPort = udpPort;
            this.intervalMs = intervalMs;
        }

        /// <summary>
        /// Bắt đầu phát thông tin máy chủ.
        /// </summary>
        public void Start()
        {
            Task.Run(() => BroadcastLoop());
        }

        /// <summary>
        /// Hàm vòng lặp phát thông tin máy chủ.
        /// </summary>
        private void BroadcastLoop()
        {
            using (UdpClient udp = new UdpClient())
            {
                udp.EnableBroadcast = true;

                string message = $"chitchat_server|{tcpPort}";
                byte[] data = Encoding.UTF8.GetBytes(message);

                IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, udpPort);
                while (running)
                {
                    udp.Send(data, data.Length, endPoint);
                    Task.Delay(intervalMs).Wait();
                }
            }
        }

        /// <summary>
        /// Ngừng phát thông tin máy chủ.
        /// </summary>
        public void Stop()
        {
            running = false;
        }
    }
}
