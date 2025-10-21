using Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Client
{
    public partial class ChatForm : Form
    {
        private readonly string username;
        private readonly string serverName;
        private readonly string serverIp;
        private readonly int serverPort;
        private TcpClient tcpClient;

        public ChatForm(string username, string serverName, string ip, int port)
        {
            this.username = username;
            this.serverName = serverName;
            serverIp = ip;
            serverPort = port;
            tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(serverIp, serverPort);
                System.Diagnostics.Debug.WriteLine($"Connected to {serverName}");
                Task.Run(() => ListenForMessages(tcpClient));
            }
            catch (Exception e)
            {
                MessageBox.Show("Cannot connect to server! Try again.");
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
            InitializeComponent();
            Text = $"Chat - {username} @ {serverName} | {serverIp}:{serverPort}";
        }

        private void ListenForMessages(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            while (true)
            {
                try
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break; // Server disconnected

                    string msg = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Wrapper wrapper = JsonSerializer.Deserialize<Wrapper>(msg);
                    if (wrapper != null)
                    {
                        switch (wrapper.Type)
                        {
                            case Types.ChatMessage:
                                ChatMessage chatMessage = JsonSerializer.Deserialize<ChatMessage>(wrapper.Payload);
                                System.Diagnostics.Debug.WriteLine($"Received: {chatMessage.Message} from {chatMessage.Username} at {chatMessage.TimeSent}");
                                string formattedMsg = $"[{chatMessage.TimeSent:HH:mm}] {chatMessage.Username}: {chatMessage.Message}";
                                if (lsbxMessages.InvokeRequired)
                                {
                                    lsbxMessages.BeginInvoke(new Action(() => lsbxMessages.Items.Add(formattedMsg)));
                                }
                                else
                                {
                                    lsbxMessages.Items.Add(formattedMsg);
                                }
                                break;
                        }
                    }
                    
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine($"Error with listening for messages: {e.Message}");
                }
            }
            System.Diagnostics.Debug.WriteLine("Disconnected from server");
        }

        /// <summary>
        /// Gửi tin nhắn cho máy chủ
        /// </summary>
        private void SendMessage(DateTime timeSent, string username, string message)
        {
            ChatMessage chatMessage = new ChatMessage
            {
                TimeSent = timeSent,
                Username = username,
                Message = message
            };
            string payload = JsonSerializer.Serialize(chatMessage);
            Wrapper wrapper = new Wrapper
            {
                Type = Types.ChatMessage,
                Payload = payload
            };
            string finalJson = JsonSerializer.Serialize(wrapper);
            byte[] data = Encoding.UTF8.GetBytes(finalJson);
            NetworkStream stream = tcpClient.GetStream();
            stream.Write(data, 0, data.Length);
        }

        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            tcpClient.Close();
        }

        private void txtbxMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(txtbxMessage.Text))
            {
                SendMessage(DateTime.Now, username, txtbxMessage.Text.Trim());
                txtbxMessage.Clear();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
