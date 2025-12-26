using Client.Extensions;
using Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ToolTip = System.Windows.Forms.ToolTip;

namespace Client
{
    public partial class ChatForm : Form
    {
        private bool close = false;

        private string username;
        private readonly string serverName;
        public string serverIp { get; }
        public int serverPort { get; }
        private string profilePictureAttachment;
        private TcpClient tcpClient;
        private ReactionManager reactionManager;
        private AlertForm alertForm;

        private SoundPlayer receivedMessageSound;

        private Panel dummy;

        private TaskCompletionSource<Attachment[]>? fileConfirmationTcs;
        private Dictionary<string, Tuple<TaskCompletionSource<string>, string>> pendingAttachmentFetches = new();
        private readonly SemaphoreSlim streamReadLock = new(1, 1);

        private ConnectedUsers connectedUsers = new();

        private bool isLoading = false;
        private ToolTip toolTip = new ToolTip();

        private static string GetLocalIPv4(IPEndPoint? ep) =>
            ep?.Address switch
            {
                IPAddress addr when addr.IsIPv4MappedToIPv6 => addr.MapToIPv4().ToString(),
                IPAddress addr => addr.ToString(),
                _ => string.Empty
            };

        public ChatForm(string username, string serverName, string ip, int port, string profilePicturePath)
        {
            this.username = username;
            this.serverName = serverName;
            serverIp = ip;
            serverPort = port;
            reactionManager = new ReactionManager();
            tcpClient = new TcpClient();
            receivedMessageSound = new SoundPlayer(Properties.Resources.received_message);

            bool needToUploadProfilePicture = false;
            try
            {
                System.Diagnostics.Debug.WriteLine($"Connecting to {serverName} at {serverIp}:{serverPort}...");
                // Use async connect with timeout to avoid freezing when server is unavailable
                var connectResult = tcpClient.BeginConnect(serverIp, serverPort, null, null);
                bool connectedInTime = connectResult.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(5));
                if (!connectedInTime)
                {
                    System.Diagnostics.Debug.WriteLine("ChatForm | Connect timed out");
                    tcpClient.Close();
                    throw new TimeoutException("Connection timed out");
                }
                tcpClient.EndConnect(connectResult);
                quickAlert($"Đã kết nối đến {serverName}!", AlertForm.enmAlertType.Success);
                System.Diagnostics.Debug.WriteLine($"Connected to {serverName}");
                var stream = tcpClient.GetStream();
                GetConnectedUsers(stream, username);
                // Check if profile picture needs to be uploaded to this server (when it's a cached image)
                if (!string.IsNullOrEmpty(profilePicturePath) && !Path.IsPathRooted(profilePicturePath))
                {
                    Wrapper pfpPicWrapper = new Wrapper
                    {
                        Type = Types.CheckFileExists,
                        Payload = ConfigManager.Current!.ProfileImagePath
                    };
                    string pfpPicJson = JsonSerializer.Serialize(pfpPicWrapper);
                    Wrapper.SendJson(stream, pfpPicJson);
                    string pfpPicResponseJson = Wrapper.ReadJson(stream);
                    Wrapper pfpPicResponseWrapper = JsonSerializer.Deserialize<Wrapper>(pfpPicResponseJson);
                    if (pfpPicResponseWrapper.Type == Types.CheckFileExistsResponse)
                    {
                        CheckFileExistsResponse response = JsonSerializer.Deserialize<CheckFileExistsResponse>(pfpPicResponseWrapper.Payload);
                        if (response.Exists)
                        {
                            System.Diagnostics.Debug.WriteLine("Profile picture already exists on server: " + profilePicturePath);
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("Profile picture does not exist on server, will upload: " + profilePicturePath);
                            needToUploadProfilePicture = true;
                        }
                    }
                }

                Task.Run(async () => await HandleResponse(tcpClient));
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("ChatForm | Cannot connect to server!");
                MessageBox.Show("Cannot connect to server! Server is either unavailable or connection timed out.");
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
            // Handle profile picture upload if server doesn't the already cached image
            if (needToUploadProfilePicture)
            {
                Attachment[] attachment = SendFiles([profilePicturePath], true, false);
                if (attachment.Length > 0)
                {
                    profilePictureAttachment = attachment[0].FileName;
                    System.Diagnostics.Debug.WriteLine("Profile picture uploaded: " + profilePictureAttachment);
                }
            }
            // If is absolute path, it's a local file that needs to be uploaded and downloaded from server
            else if (!string.IsNullOrEmpty(profilePicturePath) && Path.IsPathRooted(profilePicturePath))
            {
                UploadNewProfilePicture();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Using existing profile picture: " + profilePicturePath);
                profilePictureAttachment = profilePicturePath;
            }
            InitializeComponent();
            loadingAnimationControl1.Visible = false;
            foreach(var user in connectedUsers.Users)
            {
                CircularPictureBox userPfp = new CircularPictureBox();
                userPfp.Image = Helpers.GetProfilePicture(tcpClient, pendingAttachmentFetches, user.ProfileImagePath);
                userPfp.Width = 20;
                userPfp.Height = 20;
                toolTip.SetToolTip(userPfp, user.Username);
                userPfp.Tag = user;
                flwLytPnlUsers.Controls.Add(userPfp);
            }
            smthFlwLytPnlMessages.MouseWheel += SmthFlwLytPnlMessages_MouseWheel;
            smthFlwLytPnlMessages.Scroll += SmthFlwLytPnlMessages_Scroll;
            Text = $"{serverName} - {username} @ {serverName} | {serverIp}:{serverPort}";
            lblServer.Text = $"{serverName} @ {serverIp}:{serverPort}";
            this.DoubleBuffered = true;

        }

        private void UploadNewProfilePicture()
        {
            System.Diagnostics.Debug.WriteLine("Uploading profile picture to server...");
            Attachment[] attachment = SendFiles([ConfigManager.Current!.ProfileImagePath]);
            if (attachment.Length > 0)
            {
                profilePictureAttachment = attachment[0].FileName;
                System.Diagnostics.Debug.WriteLine("Profile picture uploaded: " + profilePictureAttachment);
                Helpers.GetProfilePicture(tcpClient, pendingAttachmentFetches, profilePictureAttachment);
                ConfigManager.Current!.ProfileImagePath = profilePictureAttachment;
                ConfigManager.Save();
            }
        }

        private void GetConnectedUsers(NetworkStream stream, string username)
        {
            Wrapper wrapper = new Wrapper
            {
                Type = Types.UserConnected,
                Payload = JsonSerializer.Serialize(new UserConnected
                {
                    Username = username,
                    ProfileImagePath = ConfigManager.Current!.ProfileImagePath,
                    Address = GetLocalIPv4(tcpClient.Client.LocalEndPoint as IPEndPoint)
                })
            };
            string json = JsonSerializer.Serialize(wrapper);
            Wrapper.SendJson(stream, json);
            // Get connected users information
            json = Wrapper.ReadJson(stream);
            wrapper = JsonSerializer.Deserialize<Wrapper>(json);
            if (wrapper.Type == Types.ConnectedUsers)
            {
                connectedUsers = JsonSerializer.Deserialize<ConnectedUsers>(wrapper.Payload);
                System.Diagnostics.Debug.WriteLine($"Những người kết nối: {string.Join(", ", connectedUsers?.Users?.Select(u => u.Username) ?? [])}");
            }
        }

        public void UpdateUserInfo()
        {
            if (!string.IsNullOrEmpty(ConfigManager.Current!.ProfileImagePath))
            {
                System.Diagnostics.Debug.WriteLine("Updating profile picture...");
                UploadNewProfilePicture();
            } else
            {
                profilePictureAttachment = "";
            }
            username = ConfigManager.Current!.Username;
            Wrapper wrapper = new Wrapper
            {
                Type = Types.UserUpdated,
                Payload = JsonSerializer.Serialize(
                    new UserUpdated
                    {
                        Username = username,
                        ProfileImagePath = profilePictureAttachment,
                        Address = GetLocalIPv4(tcpClient?.Client?.LocalEndPoint as IPEndPoint)
                    }
                )
            };
            string json = JsonSerializer.Serialize(wrapper);
            NetworkStream stream = tcpClient.GetStream();
            System.Diagnostics.Debug.WriteLine("Sending updated user info to server...");
            Wrapper.SendJson(stream, json);
        }

        private void SmthFlwLytPnlMessages_MouseWheel(object? sender, MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"ChatForm | Mouse wheel scrolled: Delta={e.Delta}, ScrollValue={smthFlwLytPnlMessages.VerticalScroll.Value}");
            if (smthFlwLytPnlMessages.VerticalScroll.Value == smthFlwLytPnlMessages.VerticalScroll.Minimum)
            {
                System.Diagnostics.Debug.WriteLine("ChatForm | Scrolled to top, loading more messages...");
                // Load more messages when scrolled to top
                if (smthFlwLytPnlMessages.Controls.Count > 1)
                {
                    var firstMessageControl = smthFlwLytPnlMessages.Controls
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

        private void SmthFlwLytPnlMessages_Scroll(object? sender, ScrollEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"ChatForm | Mouse wheel scrolled: Delta={e.NewValue - e.OldValue}, ScrollValue={smthFlwLytPnlMessages.VerticalScroll.Value}");
            if (smthFlwLytPnlMessages.VerticalScroll.Value == smthFlwLytPnlMessages.VerticalScroll.Minimum)
            {
                System.Diagnostics.Debug.WriteLine("ChatForm | Scrolled to top, loading more messages...");
                // Load more messages when scrolled to top
                if (smthFlwLytPnlMessages.Controls.Count > 1)
                {
                    var firstMessageControl = smthFlwLytPnlMessages.Controls
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

        private void SetLoading(bool loading)
        {
            isLoading = loading;
            if (loadingAnimationControl1 != null)
            {
                if (smthFlwLytPnlMessages.InvokeRequired)
                {
                    smthFlwLytPnlMessages.Invoke(() =>
                    {
                        smthFlwLytPnlMessages.Visible = !isLoading;
                    });
                }
                else
                {
                    smthFlwLytPnlMessages.Visible = !isLoading;
                }
                if (loadingAnimationControl1.InvokeRequired)
                {
                    loadingAnimationControl1.Invoke(() =>
                    {
                        loadingAnimationControl1.Visible = isLoading;
                        /*
                        if (isLoading)
                        {
                            loadingAnimationControl1.BringToFront();
                        }
                        */
                    });
                }
                else
                {
                    loadingAnimationControl1.Visible = isLoading;
                    /*
                    if (isLoading)
                    {
                        loadingAnimationControl1.BringToFront();
                    }
                    */
                }
            }
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
                    if (close) break;
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
                                AddMessage(client, chatMessage);
                                receivedMessageSound.Play();
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
                            case Types.UpdateReaction:
                                HandleUpdateReaction(client, wrapper);
                                break;
                            case Types.UserConnected:
                                UserConnected userConnected = JsonSerializer.Deserialize<UserConnected>(wrapper.Payload);
                                connectedUsers.Users.Add(userConnected);
                                System.Diagnostics.Debug.WriteLine($"ChatForm | User connected: {userConnected.Username}");
                                CircularPictureBox userPfp = new CircularPictureBox();
                                userPfp.Image = Helpers.GetProfilePicture(tcpClient, pendingAttachmentFetches, userConnected.ProfileImagePath);
                                userPfp.Width = 20;
                                userPfp.Height = 20;
                                userPfp.Tag = userConnected;
                                if (flwLytPnlUsers.InvokeRequired)
                                {
                                    flwLytPnlUsers.Invoke(() =>
                                    {
                                        flwLytPnlUsers.Controls.Add(userPfp);
                                    });
                                }
                                else
                                {
                                    flwLytPnlUsers.Controls.Add(userPfp);
                                }
                                break;
                            case Types.UserDisconnected:
                                UserConnected userDisconnected = JsonSerializer.Deserialize<UserConnected>(wrapper.Payload);
                                connectedUsers.Users.RemoveAll(u => u.Address == userDisconnected.Address);
                                System.Diagnostics.Debug.WriteLine($"ChatForm | User disconnected: {userDisconnected.Username}");
                                flwLytPnlUsers.Invoke(() =>
                                {
                                    var userPfpToRemove = flwLytPnlUsers.Controls.OfType<CircularPictureBox>().FirstOrDefault(p =>
                                    {
                                        var tag = p.Tag as UserConnected;
                                        return tag != null && tag.Address == userDisconnected.Address;
                                    });
                                    if (userPfpToRemove != null)
                                    {
                                        flwLytPnlUsers.Controls.Remove(userPfpToRemove);
                                    }
                                });
                                break;
                            case Types.UserUpdated:
                                UserUpdated userUpdated = JsonSerializer.Deserialize<UserUpdated>(wrapper.Payload);
                                System.Diagnostics.Debug.WriteLine($"ChatForm | User updated: {userUpdated.Username}");
                                UserConnected user = connectedUsers.Users.FirstOrDefault(u => u.Address == userUpdated.Address);
                                if (user != null)
                                {
                                    user.Username = userUpdated.Username;
                                    user.ProfileImagePath = userUpdated.ProfileImagePath;
                                }
                                flwLytPnlUsers.Invoke(() =>
                                {
                                    var userPfpToUpdate = flwLytPnlUsers.Controls.OfType<CircularPictureBox>().FirstOrDefault(p =>
                                    {
                                        var tag = p.Tag as UserConnected;
                                        return tag != null && tag.Address == userUpdated.Address;
                                    });
                                    if (userPfpToUpdate != null)
                                    {
                                        System.Diagnostics.Debug.WriteLine($"Updating {userUpdated.Username}'s profile picture");
                                        userPfpToUpdate.Image = Helpers.GetProfilePicture(tcpClient, pendingAttachmentFetches, userUpdated.ProfileImagePath);
                                        toolTip.SetToolTip(userPfpToUpdate, userUpdated.Username);
                                    }
                                });
                                break;
                            default:
                                System.Diagnostics.Debug.WriteLine($"ChatForm | Unknown message type: {wrapper.Type}");
                                break;
                        }
                    }
                    streamReadLock.Release();
                }
                catch (SocketException e)
                {
                    if (e.SocketErrorCode == SocketError.NotConnected || e.SocketErrorCode == SocketError.ConnectionReset)
                    {
                        System.Diagnostics.Debug.WriteLine($"Socket disconnected\n{e.StackTrace}");
                        Invoke(() => quickAlert($"Server {serverName} đã bị đóng!", AlertForm.enmAlertType.Error));
                        break;
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"e.SocketErrorCode = {e.ErrorCode}");
                    }
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
            Invoke(() => rndBtnCtrlClose.btnRoundButton.PerformClick());
            //rndBtnCtrlClose.btnRoundButton.PerformClick();
        }

        private void HandleUpdateReaction(TcpClient client, Wrapper wrapper)
        {
            UpdateReaction reaction = JsonSerializer.Deserialize<UpdateReaction>(wrapper.Payload);
            reactionManager.ToggleReaction(reaction.MessageId, reaction.Emoji, reaction.UserId);
        }

        private async void HandleSendMessages(TcpClient client, Wrapper wrapper)
        {
            await Task.Run(() =>
            {
                SetLoading(true);
                System.Diagnostics.Debug.WriteLine("ChatForm | Handling SendMessages...");
                if (smthFlwLytPnlMessages.InvokeRequired)
                {
                    smthFlwLytPnlMessages.Invoke(() =>
                    {
                        smthFlwLytPnlMessages.Controls.SetChildIndex(dummy, 0);
                        smthFlwLytPnlMessages.SuspendLayout();
                        SuspendPainting.SuspendPaintingControl(smthFlwLytPnlMessages);
                    });
                }
                else
                {
                    smthFlwLytPnlMessages.Controls.SetChildIndex(dummy, 0);
                    smthFlwLytPnlMessages.SuspendLayout();
                    SuspendPainting.SuspendPaintingControl(smthFlwLytPnlMessages);
                }
                SendMessages sendMessage = JsonSerializer.Deserialize<SendMessages>(wrapper.Payload);
                System.Diagnostics.Debug.WriteLine($"ChatForm | Received {sendMessage?.Messages.Length} messages from server.");
                //smthFlwLytPnlMessages.SuspendLayout();
                foreach (var chatMessage in sendMessage?.Messages ?? [])
                {
                    AddMessage(client, chatMessage, true);
                }
                if (smthFlwLytPnlMessages.InvokeRequired)
                {
                    smthFlwLytPnlMessages.Invoke(() =>
                    {
                        smthFlwLytPnlMessages.ResumeLayout(true);
                        if (dummy != null)
                        {
                            smthFlwLytPnlMessages.ScrollControlIntoView(dummy);
                        }
                        SuspendPainting.ResumePaintingControl(smthFlwLytPnlMessages);
                    });
                }
                else
                {
                    smthFlwLytPnlMessages.ResumeLayout(true);
                    if (dummy != null)
                    {
                        smthFlwLytPnlMessages.ScrollControlIntoView(dummy);
                    }
                    SuspendPainting.ResumePaintingControl(smthFlwLytPnlMessages);
                }
                // Hide loading after messages rendered
                SetLoading(false);
            });
        }

        private void AddMessage(TcpClient client, ChatMessage? chatMessage, bool sendToBack = false)
        {
            try
            {
                var isImageInfo = chatMessage.Attachments.Length == 1 ? ("and is" + (!chatMessage.Attachments[0].IsImage ? " not " : "") + "image") : "";
                System.Diagnostics.Debug.WriteLine($"ChatForm | Received: {chatMessage?.Message} from {chatMessage?.Username} at {chatMessage?.TimeSent} with {chatMessage.Attachments.Length} attachments {isImageInfo}");
                var localEndPoint = tcpClient?.Client?.LocalEndPoint as IPEndPoint;
                var localIPv4 = GetLocalIPv4(localEndPoint);
                if (chatMessage.Address == localIPv4)
                {
                    var item = new ChatMessageControl(pendingAttachmentFetches, reactionManager, client, chatMessage, true);
                    item.AttachmentCompleted += (s, e) =>
                    {
                        // Scroll to bottom when attachment is loaded
                        smthFlwLytPnlMessages.Invoke(() =>
                        {
                            if (dummy != null)
                            {
                                smthFlwLytPnlMessages.ScrollControlIntoView(dummy);
                            }
                        });
                    };
                    smthFlwLytPnlMessages.Invoke(() =>
                    {
                        smthFlwLytPnlMessages.Controls.Add(item);
                    });
                    if (sendToBack)
                    {
                        smthFlwLytPnlMessages.Invoke(() =>
                        {
                            smthFlwLytPnlMessages.Controls.SetChildIndex(item, 0);
                        });
                    }
                }
                else
                {
                    var item = new ChatMessageControl(pendingAttachmentFetches, reactionManager, client, chatMessage, false, !sendToBack);
                    item.AttachmentCompleted += (s, e) =>
                    {
                        // Scroll to bottom when attachment is loaded
                        smthFlwLytPnlMessages.Invoke(() =>
                        {
                            if (dummy != null)
                            {
                                smthFlwLytPnlMessages.ScrollControlIntoView(dummy);
                            }
                        });
                    };
                    smthFlwLytPnlMessages.Invoke(() =>
                    {
                        smthFlwLytPnlMessages.Controls.Add(item);
                    });
                    if (sendToBack)
                    {
                        smthFlwLytPnlMessages.Invoke(() =>
                        {
                            smthFlwLytPnlMessages.Controls.SetChildIndex(item, 0);
                        });
                    }
                }
                if (chatMessage.ReactionState != null)
                {
                    reactionManager.SetReactionState(chatMessage.Id, chatMessage.ReactionState);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"ChatForm | Error adding message: {e.Message}");
            }
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
                SendFiles files = JsonSerializer.Deserialize<SendFiles>(wrapper.Payload);
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
                Id = Guid.NewGuid().ToString(),
                TimeSent = timeSent,
                Username = username,
                Message = message,
                Attachments = attachments,
                Address = GetLocalIPv4(endPoint),
                ProfileImagePath = profilePictureAttachment,
            };
            string payload = JsonSerializer.Serialize(chatMessage);
            Wrapper wrapper = new Wrapper
            {
                Type = Types.ChatMessage,
                Payload = payload
            };
            string finalJson = JsonSerializer.Serialize(wrapper);
            NetworkStream stream = tcpClient.GetStream();
            try {
                Wrapper.SendJson(stream, finalJson);
            }
            catch (OperationCanceledException e)
            {
                Invoke(() => quickAlert("nigga yo network slow", AlertForm.enmAlertType.Error));
            }
        }

        /// <summary>
        /// Send files to the server
        /// </summary>
        /// <param name="filePaths">Array of file paths</param>
        private Attachment[] SendFiles(string[] filePaths, bool usingCached = false, bool mangleFileNames = true)
        {
            SetLoading(true);
            Invalidate();
            SendFiles files;
            try
            {
                files = new SendFiles()
                {
                    FileCount = filePaths.Length,
                    FileList = filePaths.Select(file =>
                    {
                        System.IO.FileInfo fi = new System.IO.FileInfo(usingCached ? Path.Combine("Cached", file) : file);
                        string fileName = usingCached ? file : fi.Name;
                        return new Protocol.File
                        {
                            FileName = fileName,
                            FileSize = fi.Length
                        };
                    }).ToList(),
                    MangleFileNames = mangleFileNames
                };
            } catch
            {
                return [];
            }
            
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
                    using (FileStream fs = new FileStream(
                            usingCached ? Path.Combine("Cached", filePath) : filePath,
                            FileMode.Open,
                            FileAccess.Read
                            )
                        )
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
            finally
            {
                SetLoading(false);
            }
            return Array.Empty<Attachment>();
        }

        private void GetMessages(int n, DateTime before)
        {
            // Show loading while requesting messages

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
            close = true;
            tcpClient.Close();
        }

        private async void txtbxMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await Task.Run(() =>
                {
                    bool flowControl = Send();
                    if (!flowControl)
                    {
                        return;
                    }
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                });
            }
        }

        private bool Send()
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
                    return false;
                }
                flwLytPnlAttachments.Invoke(() =>
                {
                    flwLytPnlAttachments.Controls.Clear();
                });
            }
            if (!string.IsNullOrWhiteSpace(txtbxMessage.Text) || attachments.Length != 0)
            {
                SendMessage(DateTime.Now, username, txtbxMessage.Text.Trim(), attachments);
                txtbxMessage.Invoke(() =>
                {
                    txtbxMessage.Clear();
                });
            }
            return true;
        }

        // csharp
        private void smthFlwLytPnlMessages_SizeChanged(object sender, EventArgs e)
        {
            if (dummy == null) return;
            dummy.Width = smthFlwLytPnlMessages.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
        }

        private void smthFlwLytPnlMessages_ControlAdded(object sender, ControlEventArgs e)
        {
            if (!isLoading)
                smthFlwLytPnlMessages.ScrollControlIntoView(e.Control);
        }


        private void ChatForm_Load(object sender, EventArgs e)
        {
            smthFlwLytPnlMessages.VerticalScroll.Visible = true;
            pnlChatPanel.Height = txtbxMessage.Height + pnlChatPanel.Padding.Top + pnlChatPanel.Padding.Bottom + txtbxMessage.Location.Y * 2;
            dummy = new Panel
            {
                Width = smthFlwLytPnlMessages.Width - SystemInformation.VerticalScrollBarWidth,
                Height = 1
            };
            smthFlwLytPnlMessages.Invoke(() =>
            {
                smthFlwLytPnlMessages.Controls.Add(dummy);
            });
            GetMessages(50, DateTime.Now);
            AddMouseDownToLoseFocus(this);
        }

        private void txtbxMessage_Click(object sender, EventArgs e)
        {

        }

        private void roundButtonControl1_Click(object sender, EventArgs e)
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

        private void ChatForm_Paint(object sender, PaintEventArgs e)
        {
            /*
            var width = 60;
            for (int i = 0; i < Width; i += width)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(231, 236, 239)), new Rectangle(i, 0, width / 2, Height));
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(218, 65, 103)), new Rectangle(i + width / 2, 0, width / 2, Height));
                // e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(239, 62, 54)), new Rectangle(i + width * 2 / 3, 0, width / 3, Height));
            }
            */
        }

        private async void sendbutton_Click(object sender, EventArgs e)
        {
            await Task.Run(() => Send());
        }

        private void AddMouseDownToLoseFocus(Control parent)
        {
            if (!(parent is System.Windows.Forms.Button) && !(parent is System.Windows.Forms.TextBox))
            {
                parent.MouseDown += (s, e) =>
                {
                    this.ActiveControl = null; // mất focus textbox
                };
            }

            foreach (Control c in parent.Controls)
            {
                AddMouseDownToLoseFocus(c);
            }
        }

        private void txtbxMessage_TextChanged(object sender, EventArgs e)
        {
            if (txtbxMessage.Text.Length > 0)
            {
                send_roundbutton.BackgroundColor = Color.FromArgb(113, 96, 232);
                send_roundbutton.backgroundColor = Color.FromArgb(113, 96, 232);
                send_roundbutton.MouseOverBackColor = Color.FromArgb(100, 81, 199);
                send_roundbutton.ButtonBackgroundImage = Properties.Resources.send_white;
            }
            else
            {
                send_roundbutton.BackgroundColor = Color.White;
                send_roundbutton.backgroundColor = Color.White;
                send_roundbutton.MouseOverBackColor = Color.White;
                send_roundbutton.ButtonBackgroundImage = Properties.Resources.send_gray;
            }
            var g = CreateGraphics();
            var size = g.MeasureString(txtbxMessage.Text, txtbxMessage.Font);
            if (size.Width > txtbxMessage.Width)
            {
                txtbxMessage.Multiline = true;
                bool continueProcess = true;
                int i = 1; //Zero Based So Start from 1
                int j = 0;
                int lines = 0;
                while (continueProcess)
                {
                    var index = txtbxMessage.GetFirstCharIndexFromLine(i);
                    if (index != -1)
                    {
                        lines++;
                        j = index;
                        i++;
                    }
                    else
                    {
                        lines++;
                        continueProcess = false;
                    }
                }
                System.Diagnostics.Debug.WriteLine($"Lines: {lines}");
                txtbxMessage.Height = txtbxMessage.Font.Height * lines;
                pnlChatPanel.Height = txtbxMessage.Height + pnlChatPanel.Padding.Top + pnlChatPanel.Padding.Bottom + txtbxMessage.Location.Y * 2;
            } else
            {
                txtbxMessage.Multiline = false;
                pnlChatPanel.Height = txtbxMessage.Height + pnlChatPanel.Padding.Top + pnlChatPanel.Padding.Bottom + txtbxMessage.Location.Y * 2;
            }
        }

        private void quickAlert(string msg, AlertForm.enmAlertType type, string avtPath = "")
        {
            alertForm = new AlertForm();
            alertForm.showAlert(msg, type, avtPath);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void rndBtnCtrlClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch
            {
                // Ignore errors on close
            }
        }

        private void ChatForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Dispose();
            }
            catch { }
        }

        private void rndCtrlChatbox_Click(object sender, EventArgs e)
        {
            txtbxMessage.Focus();
        }

        private void rndCtrlChatbox_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.IBeam;
        }

        private void rndCtrlChatbox_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
    }
}

