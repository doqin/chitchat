using Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ChatMessageControl : UserControl
    {
        private readonly ChatMessage _chatMessage;
        private TcpClient _client;
        private Dictionary<string, TaskCompletionSource<string>> pendingFetches;

        public string Username
        {
            get { return _chatMessage.Username; }
            set
            {
                _chatMessage.Username = value;
                Invalidate();
            }
        }

        public ChatMessageControl(Dictionary<string, TaskCompletionSource<string>> pendingAttachmentFetches, TcpClient client, ChatMessage chatMessage)
        {
            pendingFetches = pendingAttachmentFetches;
            _chatMessage = chatMessage;
            _client = client;
            InitializeComponent();

        }

        private void rndCtrlChatBubble_Load(object sender, EventArgs e)
        {
            lblUsername.Text = _chatMessage.Username;
            lblMessage.Text = _chatMessage.Message;
            lblTimestamp.Text = _chatMessage.TimeSent.ToString("HH:mm");
            foreach (var attachment in _chatMessage.Attachments)
            {
                System.Diagnostics.Debug.WriteLine($"Checking attachment: {attachment.FileName}");
                if (attachment.IsImage)
                {
                    System.Diagnostics.Debug.WriteLine($"Fetching image attachment: {attachment.FileName}");
                    Task.Run(() =>
                    {
                        try
                        {
                            // Fetch the attachment data from the server
                            var filePath = FetchImage(attachment.FileName);
                            if (string.IsNullOrEmpty(filePath) || (!string.IsNullOrEmpty(filePath) && filePath == "Not found"))
                            {
                                throw new FileNotFoundException("Image not found on server.");
                            }
                            // For demonstration, we'll just create a placeholder image
                            Image image = Image.FromFile(filePath);
                            PictureBox picBox = new PictureBox
                            {
                                Image = image,
                                SizeMode = PictureBoxSizeMode.Zoom,
                                Padding = new Padding(5)
                            };
                            // Update the UI on the main thread
                            flowPanelAttachments.Invoke((MethodInvoker)(() =>
                            {
                                flowPanelAttachments.Controls.Add(picBox);
                            }));
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Error fetching image: {ex.Message}");
                        }
                    });
                }
            }
        }

        private string FetchImage(string filePath)
        {
            var request = new Protocol.Wrapper
            {
                Type = Protocol.Types.GetFile,
                Payload = filePath
            };
            string requestJson = System.Text.Json.JsonSerializer.Serialize(request);
            NetworkStream ns = _client.GetStream();
            Wrapper.SendJson(ns, requestJson);
            var tcs = new TaskCompletionSource<string>();
            pendingFetches[filePath] = tcs;
            tcs.Task.Wait();
            return tcs.Task.Result;
        }
    }
}
