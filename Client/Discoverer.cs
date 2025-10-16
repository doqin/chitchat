using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    /// <summary>
    /// Lớp đơn giản để phát hiện máy chủ qua UDP broadcast.
    /// </summary>
    internal class Discoverer
    {
        private readonly int udpPort;
        private bool found = false;

        public Discoverer(int udpPort = 9999)
        {
            this.udpPort = udpPort;
        }

        /// <summary>
        /// Lắng nghe các broadcast từ máy chủ. Trả về (ip, port) nếu tìm thấy, ngược lại trả về null.
        /// </summary>
        /// <param name="timeoutMs">Thời gian chờ trước khi thoát nếu không tìm thấy máy chủ</param>
        /// <returns>Trả về địa chỉ và port của máy chủ nếu tìm thấy hoặc null nếu không tìm thấy</returns>
        public (string ip, int port)? ListenForServer(int timeoutMs = 10000)
        {
            UdpClient udp = new UdpClient(udpPort);
            udp.EnableBroadcast = true;
            udp.Client.ReceiveTimeout = timeoutMs;

            Console.WriteLine("Listening for server broadcasts...");

            try
            {
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = udp.Receive(ref remoteEP);
                string msg = Encoding.UTF8.GetString(data);

                if (msg.StartsWith("chitchat_server|"))
                {
                    string[] parts = msg.Split('|');
                    int port = int.Parse(parts[1]);
                    string ip = remoteEP.Address.ToString();
                    Console.WriteLine($"Found server at {ip}:{port}");
                    found = true;
                    return (ip, port);
                }
            }
            catch (SocketException)
            {
                Console.WriteLine("No server found (timeout).");
            }
            finally
            {
                udp.Close();
            }

            return null;
        }
    }
}
