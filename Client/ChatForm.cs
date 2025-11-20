using Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
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
        private readonly string profilePictureAttachment;
        private TcpClient tcpClient;

        private Panel dummy;

        private TaskCompletionSource<Attachment[]>? fileConfirmationTcs;
        private Dictionary<string, Tuple<TaskCompletionSource<string>, string>> pendingAttachmentFetches = new();
        private readonly SemaphoreSlim streamReadLock = new(1, 1);

        public ChatForm(string username, string serverName, string ip, int port, string profilePicturePath)
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
                Task.Run(async () => await HandleResponse(tcpClient));
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot connect to server! Try again.");
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
            if (!string.IsNullOrEmpty(profilePicturePath) && Path.IsPathRooted(profilePicturePath)) // If is absolute path, it's a local file that needs to be uploaded
            {
                System.Diagnostics.Debug.WriteLine("Uploading profile picture to server...");
                Attachment[] attachment = SendFiles([profilePicturePath]);
                if (attachment.Length > 0)
                {
                    profilePictureAttachment = attachment[0].FileName;
                    System.Diagnostics.Debug.WriteLine("Profile picture uploaded: " + profilePictureAttachment);
                    ConfigManager.Current!.ProfileImagePath = profilePictureAttachment;
                    ConfigManager.Save();
                }
            } else
            {
                System.Diagnostics.Debug.WriteLine("Using existing profile picture: " + profilePicturePath);
                profilePictureAttachment = profilePicturePath;
            }
                InitializeComponent();
            flwLytPnlMessages.MouseWheel += FlwLytPnlMessages_MouseWheel;
            Text = $"Chat - {username} @ {serverName} | {serverIp}:{serverPort}";

        }

        /// <summary>
        /// Hàm chính để xử lý phản hồi từ máy chủ
        /// </summary>
        /// <param name="client">Client TCP</param>
        private async Task HandleResponse(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            while (true)
            {
                try
                {
                    await streamReadLock.WaitAsync();
                    System.Diagnostics.Debug.WriteLine("ChatForm | Listening for messages");

                    // Read wrapper using length-prefixed protocol
                    string json = Wrapper.ReadJson(stream);
                    if (json == null)
                    {
                        System.Diagnostics.Debug.WriteLine("ChatForm | Server disconnected");
                        streamReadLock.Release();
                        break; // Server disconnected
                    }

                    System.Diagnostics.Debug.WriteLine($"ChatForm | Received raw message: {json}");
                    Wrapper wrapper = JsonSerializer.Deserialize<Wrapper>(json);
                    if (wrapper != null)
                    {
                        switch (wrapper.Type)
                        {
                            // If the message is a chat message, display it
                            case Types.ChatMessage:
                                ChatMessage chatMessage = JsonSerializer.Deserialize<ChatMessage>(wrapper.Payload);
                                System.Diagnostics.Debug.WriteLine($"ChatForm | Received: {chatMessage?.Message} from {chatMessage?.Username} at {chatMessage?.TimeSent}");

                                var localEndPoint = tcpClient.Client.LocalEndPoint as IPEndPoint;
                                if (chatMessage.Address == localEndPoint.Address.ToString())
                                {
                                    var item = new ChatMessageControl(pendingAttachmentFetches, client, chatMessage, true);
                                    flwLytPnlMessages.Invoke(() =>
                                    {
                                        flwLytPnlMessages.Controls.Add(item);
                                    });
                                }
                                else
                                {
                                    var item = new ChatMessageControl(pendingAttachmentFetches, client, chatMessage, false);
                                    flwLytPnlMessages.Invoke(() =>
                                    {
                                        flwLytPnlMessages.Controls.Add(item);
                                    });
                                }

                                break;
                            // If the message is a file confirmation, set result to the pending TaskCompletionSource
                            case Types.FileConfirmation:
                                FileConfirmation confirmation = JsonSerializer.Deserialize<FileConfirmation>(wrapper.Payload);
                                System.Diagnostics.Debug.WriteLine($"ChatForm | Received confirmation: {confirmation?.AcceptedFiles.Length}");
                                foreach (var file in confirmation?.AcceptedFiles ?? [])
                                {
                                    System.Diagnostics.Debug.WriteLine($"ChatForm | File: {file.FileName}");
                                }
                                // If someone is waiting for the confirmation, deliver attachments
                                if (fileConfirmationTcs != null)
                                {
                                    var result = fileConfirmationTcs.TrySetResult(confirmation?.AcceptedFiles ?? []);
                                    System.Diagnostics.Debug.WriteLine($"ChatForm | Set Result: {result}");
                                }
                                break;
                            // If the message is a file sending prompt, prepare to receive it
                            case Types.SendFiles:
                                streamReadLock.Release(); // Release before calling HandleFiles
                                HandleFiles(stream, wrapper);
                                continue; // Continue to next loop to acquire lock
                            case Types.SendMessages:
                                HandleSendMessages(client, wrapper);
                                break;
                            default:
                                System.Diagnostics.Debug.WriteLine($"ChatForm | Unknown message type: {wrapper.Type}");
                                break;
                        }
                    }
                    streamReadLock.Release();
                }
                catch (Exception e)
                {
                    if (streamReadLock.CurrentCount == 0)
                    {
                        streamReadLock.Release();
                    }
                    System.Diagnostics.Debug.WriteLine($"ChatForm | Error with listening for messages: {e.Message}");
                }
            }
            System.Diagnostics.Debug.WriteLine("ChatForm | Disconnected from server");
        }

        private void HandleSendMessages(TcpClient client, Wrapper wrapper)
        {
            SendMessages sendMessage = JsonSerializer.Deserialize<SendMessages>(wrapper.Payload);
            System.Diagnostics.Debug.WriteLine($"ChatForm | Received {sendMessage?.Messages.Length} messages from server.");
            flwLytPnlMessages.Invoke(() =>
            {
                flwLytPnlMessages.SuspendLayout();
                foreach (var chatMessage in sendMessage?.Messages ?? [])
                {
                    System.Diagnostics.Debug.WriteLine($"ChatForm | Received: {chatMessage?.Message} from {chatMessage?.Username} at {chatMessage?.TimeSent}");
                    var localEndPoint = tcpClient.Client.LocalEndPoint as IPEndPoint;
                    if (chatMessage.Address == localEndPoint.Address.ToString())
                    {
                        var item = new ChatMessageControl(pendingAttachmentFetches, client, chatMessage, true);
                        flwLytPnlMessages.Controls.Add(item);
                        flwLytPnlMessages.Controls.SetChildIndex(item, 0);
                    }
                    else
                    {
                        var item = new ChatMessageControl(pendingAttachmentFetches, client, chatMessage, false);
                        flwLytPnlMessages.Controls.Add(item);
                        flwLytPnlMessages.Controls.SetChildIndex(item, 0);
                    }
                }
                flwLytPnlMessages.ResumeLayout(true);
                if (dummy != null)
                {
                    flwLytPnlMessages.ScrollControlIntoView(dummy);
                    flwLytPnlMessages.Controls.SetChildIndex(dummy, 0);
                }
            });
        }

        /// <summary>
        /// Sử lý việc nhận file từ máy chủ
        /// </summary>
        /// <param name="stream">Network Stream</param>
        /// <param name="wrapper">Đối tượng cần giải nén</param>
        private void HandleFiles(NetworkStream stream, Wrapper wrapper)
        {
            streamReadLock.Wait();
            try
            {
                Files files = JsonSerializer.Deserialize<Files>(wrapper.Payload);
                if (files?.FileCount == 0)
                {
                    var fileName = files.FileList[0].FileName;
                    if (pendingAttachmentFetches.TryGetValue(fileName, out var tuple))
                    {
                        var tcs = tuple.Item1;
                        tcs.SetResult("Not found");
                        pendingAttachmentFetches.Remove(fileName);
                    }
                    return;
                }
                System.Diagnostics.Debug.WriteLine($"ChatForm | Client is ready to receive {files?.FileCount} file(s).");
                try
                {
                    foreach (var file in files.FileList)
                    {
                        // Notify any pending fetches for this attachment
                        if (pendingAttachmentFetches.TryGetValue(file.FileName, out var tuple))
                        {
                            System.Diagnostics.Debug.WriteLine($"ChatForm | Preparing to receive file: {file.FileName} ({file.FileSize} bytes)");
                            var path = tuple.Item2;
                            // Ensure the directory exists
                            string directoryPath = Path.GetDirectoryName(path);
                            if (!string.IsNullOrEmpty(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine("ChatForm | Invalid file path: no directory specified.");
                                return;
                            }
                            // Saving files
                            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                            {
                                byte[] buffer = new byte[8192];
                                long totalRead = 0;
                                int bytesRead;

                                // Read exactly the declared file size to avoid consuming the next protocol frame
                                while (totalRead < file.FileSize)
                                {
                                    int toRead = (int)Math.Min(buffer.Length, file.FileSize - totalRead);
                                    bytesRead = stream.Read(buffer, 0, toRead);
                                    System.Diagnostics.Debug.WriteLine($"ChatForm | Read {bytesRead} bytes");
                                    if (bytesRead <= 0)
                                    {
                                        break; // connection closed
                                    }
                                    fs.Write(buffer, 0, bytesRead);
                                    totalRead += bytesRead;
                                }
                            }
                            System.Diagnostics.Debug.WriteLine($"ChatForm | File received: {file.FileName}");
                            var tcs = tuple.Item1;
                            tcs.SetResult(path);
                            pendingAttachmentFetches.Remove(file.FileName);
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine($"ChatForm | Error receiving files: {e.Message}");
                    return;
                }
            }
            finally
            {
                streamReadLock.Release();
            }
        }

        /// <summary>
        /// Gửi tin nhắn cho máy chủ
        /// </summary>
        private void SendMessage(DateTime timeSent, string username, string message, Attachment[] attachments)
        {
            var endPoint = tcpClient.Client.LocalEndPoint as IPEndPoint;
            ChatMessage chatMessage = new()
            {
                TimeSent = timeSent,
                Username = username,
                Message = message,
                Attachments = attachments,
                Address = endPoint?.Address.ToString(),
                ProfileImagePath = profilePictureAttachment,
                Port = endPoint?.Port.ToString()
            };
            string payload = JsonSerializer.Serialize(chatMessage);
            Wrapper wrapper = new Wrapper
            {
                Type = Types.ChatMessage,
                Payload = payload
            };
            string finalJson = JsonSerializer.Serialize(wrapper);
            NetworkStream stream = tcpClient.GetStream();
            Wrapper.SendJson(stream, finalJson);
        }

        /// <summary>
        /// Send files to the server
        /// </summary>
        /// <param name="filePaths">Array of file paths</param>
        private Attachment[] SendFiles(string[] filePaths)
        {
            Files files = new()
            {
                FileCount = filePaths.Length,
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
            NetworkStream stream = tcpClient.GetStream();
            Wrapper.SendJson(stream, finalJson);
            try
            {
                foreach (var filePath in filePaths)
                {
                    System.Diagnostics.Debug.WriteLine($"ChatForm | Preparing to send file: {filePath}");
                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        byte[] fileBuffer = new byte[8192];
                        int fileBytesRead;
                        while ((fileBytesRead = fs.Read(fileBuffer, 0, fileBuffer.Length)) > 0)
                        {
                            stream.Write(fileBuffer, 0, fileBytesRead);
                            System.Diagnostics.Debug.WriteLine($"Wrote {fileBytesRead} bytes.");
                        }
                    }
                }
                System.Diagnostics.Debug.WriteLine("ChatForm | File data sent successfully.");
                System.Diagnostics.Debug.WriteLine("ChatForm | Waiting file confirmation from server...");
                fileConfirmationTcs = new TaskCompletionSource<Attachment[]>();
                var confirmationTask = fileConfirmationTcs.Task;
                confirmationTask.Wait();
                var result = confirmationTask.Result;
                System.Diagnostics.Debug.WriteLine($"ChatForm | File confirmation received from server. ({string.Join(", ", result.Select(attachment => attachment.FileName))})");
                return result;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"ChatForm | Error sending file data: {e.Message}");
                MessageBox.Show("An error has occurred", "Error sending files to server. Please try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Array.Empty<Attachment>();
        }

        private void GetMessages(int n, DateTime before)
        {
            GetMessages getMessages = new GetMessages
            {
                Count = n,
                Before = before
            };
            string payload = JsonSerializer.Serialize(getMessages);
            Wrapper wrapper = new Wrapper
            {
                Type = Types.GetMessages,
                Payload = payload
            };
            string finalJson = JsonSerializer.Serialize(wrapper);
            NetworkStream stream = tcpClient.GetStream();
            Wrapper.SendJson(stream, finalJson);
        }

        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            tcpClient.Close();
        }

        private void txtbxMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Attachment[] attachments = Array.Empty<Attachment>();
                if (flwLytPnlAttachments.Controls.Count > 0)
                {
                    string[] files = flwLytPnlAttachments.Controls.Cast<SelectedFileControl>().ToArray().Select(f => f.FilePath).ToArray();
                    var paths = SendFiles(files);
                    if (paths.Length > 0)
                    {
                        attachments = paths;
                    }
                    else
                    {
                        MessageBox.Show("All selected files were rejected by the server.", "File Upload Rejected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    flwLytPnlAttachments.Invoke(() =>
                    {
                        flwLytPnlAttachments.Controls.Clear();
                    });
                }
                if (!string.IsNullOrWhiteSpace(txtbxMessage.Text) || attachments.Length != 0)
                {
                    SendMessage(DateTime.Now, username, txtbxMessage.Text.Trim(), attachments);
                    txtbxMessage.Clear();
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnPickFiles_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (var file in openFileDialog1.FileNames)
                {
                    flwLytPnlAttachments.Invoke(() =>
                    {
                        var control = new SelectedFileControl(file);
                        flwLytPnlAttachments.Controls.Add(control);
                    });
                }
            }
        }

        // csharp
        private void flwLytPnlMessages_SizeChanged(object sender, EventArgs e)
        {
            if (dummy == null) return;
            dummy.Width = flwLytPnlMessages.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
        }

        private void flwLytPnlMessages_ControlAdded(object sender, ControlEventArgs e)
        {
            flwLytPnlMessages.ScrollControlIntoView(e.Control);
        }

        private void flwLytPnlMessages_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            flwLytPnlMessages.VerticalScroll.Visible = true;
            dummy = new Panel
            {
                Width = flwLytPnlMessages.Width - SystemInformation.VerticalScrollBarWidth,
                Height = 1
            };
            flwLytPnlMessages.Invoke(() =>
            {
                flwLytPnlMessages.Controls.Add(dummy);
            });
            GetMessages(50, DateTime.Now);
        }

        private int previousAttachmentPanelHeight = 0;

        private void flwLytPnlAttachments_Resize(object sender, EventArgs e)
        {
            flwLytPnlMessages.Height += previousAttachmentPanelHeight - flwLytPnlAttachments.Height;
            previousAttachmentPanelHeight = flwLytPnlAttachments.Height;
        }

        private void flwLytPnlMessages_Scroll(object sender, ScrollEventArgs e)
        {
            if (flwLytPnlMessages.VerticalScroll.Value == flwLytPnlMessages.VerticalScroll.Minimum)
            {
                // Load more messages when scrolled to top
                if (flwLytPnlMessages.Controls.Count > 1)
                {
                    var firstMessageControl = flwLytPnlMessages.Controls
                        .OfType<ChatMessageControl>()
                        .OrderBy(c => c.TimeSent)
                        .FirstOrDefault();
                    if (firstMessageControl != null)
                    {
                        GetMessages(50, firstMessageControl.TimeSent);
                    }
                }
            }
        }

        private void FlwLytPnlMessages_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (flwLytPnlMessages.VerticalScroll.Value == flwLytPnlMessages.VerticalScroll.Minimum)
            {
                // Load more messages when scrolled to top
                if (flwLytPnlMessages.Controls.Count > 1)
                {
                    var firstMessageControl = flwLytPnlMessages.Controls
                        .OfType<ChatMessageControl>()
                        .OrderBy(c => c.TimeSent)
                        .FirstOrDefault();
                    if (firstMessageControl != null)
                    {
                        GetMessages(50, firstMessageControl.TimeSent);
                    }
                }
            }
        }
    }
}
