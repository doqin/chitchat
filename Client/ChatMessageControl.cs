using Client.Extensions;
using Client.Properties;
using Protocol;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ChatMessageControl : UserControl
    {
        private readonly ChatMessage _chatMessage;
        private TcpClient _client;
        private bool _isRight;
        private static readonly SemaphoreSlim _readCache = new SemaphoreSlim(1, 1);
        private bool _isPreviewMode = false;
        private AlertForm alertForm;
        private string messageId;
        private ReactionManager reactionManager;
        private readonly string _currentUserId;
        private bool isSendAlert = false;

        public event EventHandler? AttachmentCompleted;

        public string Username
        {
            get { return _chatMessage.Username; }
            set
            {
                _chatMessage.Username = value;
                Invalidate();
            }
        }

        public DateTime TimeSent
        {
            get { return _chatMessage.TimeSent; }
            set
            {
                _chatMessage.TimeSent = value;
                Invalidate();
            }
        }

        IPAddress _address;
        int _port;

        public ChatMessageControl()
        {
            _isPreviewMode = true;
            InitializeComponent();
            Anchor = AnchorStyles.Right;
            flowPanelLayout.FlowDirection = FlowDirection.RightToLeft;
            rndCtrlChatBubble.Anchor = AnchorStyles.Right;
            lblTimestamp.Anchor = AnchorStyles.Right;
            pnlReaction.Visible = false;
        }

        public ChatMessageControl(
            IPAddress address,
            int port,
            string currentUserId,
            ReactionManager manager,
            ChatMessage chatMessage,
            bool isRight,
            bool isSendAlert = false
        )
        {
            reactionManager = manager ?? throw new ArgumentNullException(nameof(manager));
            _isRight = isRight;
            _chatMessage = chatMessage;
            _address = address;
            _port = port;
            _currentUserId = currentUserId;
            messageId = chatMessage.Id;
            this.isSendAlert = isSendAlert;

            InitializeComponent();
            if (_isRight)
            {
                this.Anchor = AnchorStyles.Right;
                this.flowPanelLayout.FlowDirection = FlowDirection.RightToLeft;
                this.rndCtrlChatBubble.Anchor = AnchorStyles.Right;
                this.lblTimestamp.Anchor = AnchorStyles.Right;
            }
            var tooltip = new ToolTip();
            tooltip.SetToolTip(crclrPicBoxProfilePicture, _chatMessage.Username);

            // Subscribe event reaction
            reactionManager.On_Reaction_Updated += ReactionManager_OnReactionChanged;

            // Initialize reaction row
            rctionRwCtrlRow.SetCurrentUserId(_currentUserId);
            rctionRwCtrlRow.ReactionClicked += rctionRwCtrlRow_ReactionClicked;


            // click ra ngoài ẩn
            this.Click += (s, e) => { if (reactionControl1.Visible) HideReactionControl(); };

            // Load message + attachment
            //rndCtrlChatBubble_Load(this, EventArgs.Empty);
        }



        public void SetPreview(string profilePicPath, string username, string message, DateTime timeSent)
        {
            if (!_isPreviewMode) return;
            crclrPicBoxProfilePicture.Image = Helpers.GetProfilePicture(profilePicPath);
            lblMessage.Text = username;
            lblMessage.Text = message;
            lblTimestamp.Text = DateTime.Now.Subtract(timeSent).Days > 0 ? timeSent.ToString("g") : timeSent.ToString("t");
        }

        private void ChatMessageControl_Load(object sender, EventArgs e)
        {
            if (_isPreviewMode) return;
            lblMessage.Text = _chatMessage.Message;
            if (string.IsNullOrEmpty(_chatMessage.Message))
            {
                rndCtrlChatBubble.Visible = false;
            }
            lblTimestamp.Text = DateTime.Now.Subtract(_chatMessage.TimeSent).Days > 0 ? _chatMessage.TimeSent.ToString("g") : _chatMessage.TimeSent.ToString("t");
            foreach (Control c in pnlReaction.Controls)
            {
                c.MouseEnter += pnlReaction_MouseEnter;
                c.MouseLeave += pnlReaction_MouseLeave;
            }
            if (_isRight) { 
                rctionRwCtrlRow.Anchor = AnchorStyles.Right;
                rctionRwCtrlRow.FlowDirection = FlowDirection.RightToLeft;
            } else
            {
                rndCtrlChatBubble.BackgroundColor = Color.White;
                lblMessage.ForeColor = Color.Black;
            }
            Task.Run(() =>
            {
                if (!string.IsNullOrEmpty(_chatMessage.ProfileImagePath))
                {
                    var cacheDirectory = Path.Combine(Application.StartupPath, "Cached");
                    Directory.CreateDirectory(cacheDirectory);
                    var cachedImagePath = Path.Combine(cacheDirectory, _chatMessage.ProfileImagePath);

                    System.Diagnostics.Debug.WriteLine($"Waiting for cache lock to unlock: {_chatMessage.ProfileImagePath}");
                    _readCache.Wait();
                    try
                    {
                        crclrPicBoxProfilePicture.Invoke((MethodInvoker)(() =>
                        {
                            crclrPicBoxProfilePicture.Image = Helpers.GetProfilePicture(_address, _port, _chatMessage.ProfileImagePath);
                            crclrPicBoxProfilePicture.DrawOutline = false;
                        }));
                    }
                    finally
                    {
                        _readCache.Release();
                    }
                }
                else
                {
                    crclrPicBoxProfilePicture.Invoke((MethodInvoker)(() =>
                    {
                        crclrPicBoxProfilePicture.Image = Resources.user;
                        crclrPicBoxProfilePicture.DrawOutline = false;
                    }));
                }
                if (isSendAlert)
                    this.Invoke((MethodInvoker)(() => quickAlert($"{_chatMessage.Username}: {_chatMessage.Message}", AlertForm.enmAlertType.Info, string.IsNullOrEmpty(_chatMessage.ProfileImagePath) ? "" : Path.Combine("Cached", _chatMessage.ProfileImagePath))));

                    foreach (var attachment in _chatMessage.Attachments)
                    {
                        System.Diagnostics.Debug.WriteLine($"Checking attachment: {attachment.FileName}");
                        var cacheDirectory = Path.Combine(Application.StartupPath, "Cached");
                        Directory.CreateDirectory(cacheDirectory);
                        var cachedAttachmentPath = Path.Combine(cacheDirectory, attachment.FileName);

                    if (attachment.IsImage)
                    {
                        if (System.IO.File.Exists(cachedAttachmentPath))
                        {
                            System.Diagnostics.Debug.WriteLine($"Loading cached image attachment: {attachment.FileName}");
                            Image image = Image.FromFile(cachedAttachmentPath);
                            image = Helpers.CorrectImageOrientation(image);
                            PictureBox picBox = new PictureBox
                            {
                                Image = image,
                                SizeMode = PictureBoxSizeMode.Zoom,
                                Padding = new Padding(5),
                                Size = new Size(400, image.Height * 400 / image.Width),
                                BorderStyle = BorderStyle.FixedSingle
                            };
                            if (_isRight)
                            {
                                picBox.Anchor = AnchorStyles.Right;
                            }
                            // Update the UI on the main thread
                            flowPanelAttachments.Invoke((MethodInvoker)(() =>
                            {
                                flowPanelAttachments.Controls.Add(picBox);
                            }));
                            quickAlert($"{Username} đã gửi một ảnh!", AlertForm.enmAlertType.Info, cachedAttachmentPath);

                            continue;
                        }

                        try
                        {
                            System.Diagnostics.Debug.WriteLine($"Fetching image attachment: {attachment.FileName}");
                            var request = new Wrapper
                            {
                                Type = Types.GetFile,
                                Payload = attachment.FileName
                            };
                            string requestJson = JsonSerializer.Serialize(request);
                            // Fetch the attachment data from the server
                            var filePath = Protocol.File.FetchFile(_address, _port, attachment.FileName, cachedAttachmentPath);
                            if (string.IsNullOrEmpty(filePath) || (!string.IsNullOrEmpty(filePath) && filePath == "Not found"))
                            {
                                throw new FileNotFoundException("Image not found on server.");
                            }
                            // Load image and correct orientation
                            Image image = Image.FromFile(filePath);
                            image = Helpers.CorrectImageOrientation(image);

                            PictureBox picBox = new PictureBox
                            {
                                Image = image,
                                SizeMode = PictureBoxSizeMode.Zoom,
                                Padding = new Padding(5),
                                Size = new Size(400, image.Height * 400 / image.Width),
                                BorderStyle = BorderStyle.FixedSingle
                            };
                            if (_isRight)
                            {
                                picBox.Anchor = AnchorStyles.Right;
                            }
                            // Update the UI on the main thread
                            flowPanelAttachments.Invoke((MethodInvoker)(() =>
                            {
                                flowPanelAttachments.Controls.Add(picBox);
                            }));
                            quickAlert($"{Username} đã gửi một ảnh!", AlertForm.enmAlertType.Info, cachedAttachmentPath);
                        }
                        catch { /* handle errors */ }
                    }
                    else
                    {
                        AttachmentControl attachmentControl = new AttachmentControl(_address, _port, attachment.FileName);
                        if (_isRight)
                        {
                            attachmentControl.Anchor = AnchorStyles.Right;
                        }
                        // Update the UI on the main thread
                        flowPanelAttachments.Invoke((MethodInvoker)(() =>
                        {
                            flowPanelAttachments.Controls.Add(attachmentControl);
                        }));
                    }
                }
                if (_chatMessage.Attachments.Length > 0)
                {
                    AttachmentCompleted?.Invoke(this, EventArgs.Empty);
                }
            });
        }

        private void UpdateReaction(string messageId, string emoji, string userId)
        {
            var stream = _client.GetStream();
            var reactionUpdate = new Wrapper
            {
                Type = Types.UpdateReaction,
                Payload = JsonSerializer.Serialize(new UpdateReaction
                {
                    MessageId = messageId,
                    Emoji = emoji,
                    UserId = userId
                })
            };
            var json = JsonSerializer.Serialize(reactionUpdate);
            Wrapper.SendJson(stream, json);
        }

        private void btnMainEmoji_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Main emoji button clicked.");
            reactionControl1.ShowEmojis();
            pnlReaction.Visible = false;
        }

        private void HideReactionControl()
        {
            reactionControl1.Visible = false;
            pnlReaction.Visible = true;
        }

        // Xử lý khi người dùng chọn một emoji trong ReactionControl
        private void ReactionControl1_EmojiClicked(string emoji)
        {
            //MessageBox.Show($"Bạn vừa chọn emoji: {emoji}");
            System.Diagnostics.Debug.WriteLine($"{emoji}");
            UpdateReaction(messageId, emoji, _currentUserId);
            HideReactionControl();
        }

        private void rctionRwCtrlRow_ReactionClicked(string emoji)
        {
            System.Diagnostics.Debug.WriteLine($"Reaction row emoji clicked: {emoji}");
            UpdateReaction(messageId, emoji, _currentUserId);
        }

        private void ReactionManager_OnReactionChanged(string changedMessageId)
        {
            //System.Diagnostics.Debug.WriteLine($"Reaction updated for message ID: {changedMessageId}");
            if (changedMessageId != messageId)
            {
                //System.Diagnostics.Debug.WriteLine("Message ID does not match. Ignoring update.");
                return;
            }

            var state = reactionManager.GetState(messageId);

            System.Diagnostics.Debug.WriteLine($"Updating reaction row for message ID: {changedMessageId}");
            rctionRwCtrlRow.SetState(state);
            //reactionRowControl.Visible = state.Emoji_To_Users.Any(); This is kinda useless lol
        }

        private void pnlReaction_MouseEnter(object sender, EventArgs e)
        {
            btnMainEmoji.Visible = true;
        }

        private void pnlReaction_MouseLeave(object sender, EventArgs e)
        {
            var cursorPos = pnlReaction.PointToClient(Cursor.Position);
            if (!pnlReaction.ClientRectangle.Contains(cursorPos))
            {
                btnMainEmoji.Visible = false;
            }
        }

        private void btnMainEmoji_Click_1(object sender, EventArgs e) => btnMainEmoji_Click(sender, e);

        private void quickAlert(string msg, AlertForm.enmAlertType type, string avtPath = "")
        {
            alertForm = new AlertForm();
            System.Diagnostics.Debug.WriteLine("newable");
            alertForm.showAlert(msg, type, avtPath);
        }
    }
}
