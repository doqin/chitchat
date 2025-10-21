using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    /// <summary>
    /// Lớp đơn giản để phát hiện máy chủ qua UDP broadcast.
    /// Updates to UI-bound BindingList are marshaled to the captured SynchronizationContext.
    /// </summary>
    internal class Discoverer
    {
        private readonly int udpPort;
        private bool found = false;
        private System.Threading.Timer timer;

        public Discoverer(int udpPort = 9999)
        {
            this.udpPort = udpPort;
        }

        /// <summary>
        /// Lắng nghe các broadcast từ máy chủ. Cập nhật binding danh sách máy chủ tìm thấy.
        /// </summary>
        /// <param name="timeoutMs">Thời gian chờ trước khi thoát nếu không tìm thấy máy chủ</param>
        public void ListenForServer(BindingList<string> servers, int timeoutMs = 10000)
        {
            // Capture the current SynchronizationContext (UI thread) so we can marshal updates.
            var uiContext = SynchronizationContext.Current;

            _ = Task.Run(async () =>
            {
                using var udp = new UdpClient(udpPort) { EnableBroadcast = true };
                udp.Client.ReceiveTimeout = timeoutMs;
                var deadline = DateTime.UtcNow + TimeSpan.FromMilliseconds(timeoutMs);

                while (DateTime.UtcNow < deadline)
                {
                    try
                    {
                        var result = await udp.ReceiveAsync();
                        string msg = Encoding.UTF8.GetString(result.Buffer);
                        if (msg.StartsWith("chitchat_server|"))
                        {
                            var parts = msg.Split('|');
                            if (parts.Length >= 2 && int.TryParse(parts[1], out int port))
                            {
                                string ip = result.RemoteEndPoint.Address.ToString();
                                string serverEntry = $"{ip}:{port}";
                                System.Diagnostics.Debug.WriteLine($"Found server: {serverEntry}");

                                // Action that updates the BindingList
                                void AddServerIfMissing()
                                {
                                    if (!servers.Contains(serverEntry))
                                        servers.Add(serverEntry);
                                }

                                if (uiContext != null)
                                {
                                    // Marshal to UI thread
                                    uiContext.Post(_ => AddServerIfMissing(), null);
                                }
                                else
                                {
                                    // No UI context — safe to add directly
                                    AddServerIfMissing();
                                }

                                found = true;
                            }
                        }
                    }
                    catch (SocketException)
                    {
                        // receive timed out — exit loop
                        if (uiContext != null)
                        {
                            uiContext.Post(_ => MessageBox.Show("Không tìm thấy máy chủ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error), null);
                        }
                        else
                        {
                            // If no UI context, fallback to debug output
                            System.Diagnostics.Debug.WriteLine("Không tìm thấy máy chủ! (no UI context to show MessageBox)");
                        }

                        break;
                    }
                    catch (Exception ex)
                    {
                        // Unexpected error — report to debug and continue or break as appropriate
                        System.Diagnostics.Debug.WriteLine($"Discoverer error: {ex}");
                        break;
                    }
                }
            });
        }
    }
}
