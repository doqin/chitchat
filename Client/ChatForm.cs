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

        private string[] selectedFiles = Array.Empty<string>();

        private TaskCompletionSource<string[]>? fileConfirmationTcs;

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
                Task.Run(() => HandleResponse(tcpClient));
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot connect to server! Try again.");
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
            InitializeComponent();
            Text = $"Chat - {username} @ {serverName} | {serverIp}:{serverPort}";
        }

        private void HandleResponse(TcpClient client)
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
                            // If the message is a chat message, display it
                            case Types.ChatMessage:
                                ChatMessage chatMessage = JsonSerializer.Deserialize<ChatMessage>(wrapper.Payload);
                                System.Diagnostics.Debug.WriteLine($"Received: {chatMessage.Message} from {chatMessage.Username} at {chatMessage.TimeSent}");
                                string attachments = chatMessage.Attachments != null && chatMessage.Attachments.Length > 0
                                    ? $" [Attachments: {string.Join(", ", chatMessage.Attachments)}]"
                                    : string.Empty;
                                string formattedMsg = $"[{chatMessage.TimeSent:HH:mm}] {chatMessage.Username}: {chatMessage.Message} {attachments}";
                                if (lsbxMessages.InvokeRequired)
                                {
                                    lsbxMessages.BeginInvoke(new Action(() => lsbxMessages.Items.Add(formattedMsg)));
                                }
                                else
                                {
                                    lsbxMessages.Items.Add(formattedMsg);
                                }
                                break;
                            case Types.FileConfirmation:
                                FileConfirmation confirmation = JsonSerializer.Deserialize<FileConfirmation>(wrapper.Payload);
                                System.Diagnostics.Debug.WriteLine($"Received confirmation: {confirmation?.AcceptedFiles.Length}");
                                // If someone is waiting for the confirmation, deliver attachments
                                if (fileConfirmationTcs != null)
                                {
                                    fileConfirmationTcs.TrySetResult(confirmation?.AcceptedFiles ?? Array.Empty<string>());
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
        private void SendMessage(DateTime timeSent, string username, string message, string[] attachments)
        {
            ChatMessage chatMessage = new()
            {
                TimeSent = timeSent,
                Username = username,
                Message = message,
                Attachments = attachments
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

        /// <summary>
        /// Send files to the server
        /// </summary>
        /// <param name="filePaths">Array of file paths</param>
        private string[] SendFiles(string[] filePaths)
        {
            Files files = new()
            {
                FileCount = filePaths.Length.ToString(),
                FileList = filePaths.Select(file =>
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(file);
                    return new Protocol.File
                    {
                        FileName = fi.Name,
                        FileSize = fi.Length
                    };
                }).ToList()
            };
            string payload = JsonSerializer.Serialize(files);
            Wrapper wrapper = new()
            {
                Type = Types.SendFiles,
                Payload = payload
            };
            string finalJson = JsonSerializer.Serialize(wrapper);
            byte[] data = Encoding.UTF8.GetBytes(finalJson);
            NetworkStream stream = tcpClient.GetStream();
            stream.Write(data, 0, data.Length);
            try
            {
                foreach (var filePath in filePaths)
                {
                    System.Diagnostics.Debug.WriteLine($"Preparing to send file: {filePath}");
                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        byte[] fileBuffer = new byte[8192];
                        int fileBytesRead;
                        while ((fileBytesRead = fs.Read(fileBuffer, 0, fileBuffer.Length)) > 0)
                        {
                            stream.Write(fileBuffer, 0, fileBytesRead);
                        }
                    }
                }
                System.Diagnostics.Debug.WriteLine("File data sent successfully.");
                System.Diagnostics.Debug.WriteLine("Waiting file confirmation from server...");
                fileConfirmationTcs = new TaskCompletionSource<string[]>();
                var confirmationTask = fileConfirmationTcs.Task;
                confirmationTask.Wait();
                System.Diagnostics.Debug.WriteLine("File confirmation received from server.");
                return confirmationTask.Result;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"Error sending file data: {e.Message}");
                MessageBox.Show("An error has occurred", "Error sending files to server. Please try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return [];
        }

        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            tcpClient.Close();
        }

        private void txtbxMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string[] attachments = Array.Empty<string>();
                if (selectedFiles.Length > 0)
                {
                    attachments = SendFiles(selectedFiles);
                    lblSelectedFiles.Text = "(none)";
                    selectedFiles = Array.Empty<string>();
                }
                if (!string.IsNullOrWhiteSpace(txtbxMessage.Text))
                {
                    SendMessage(DateTime.Now, username, txtbxMessage.Text.Trim(), attachments);
                    txtbxMessage.Clear();
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {

        }

        private void btnPickFiles_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                lblSelectedFiles.Text = string.Join(", ", openFileDialog1.FileNames);
                selectedFiles = openFileDialog1.FileNames;
            }
        }
    }
}
