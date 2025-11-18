using Protocol;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ChatMessageControl : UserControl
    {
        private readonly ChatMessage _chatMessage;
        private TcpClient _client;
        private Dictionary<string, Tuple<TaskCompletionSource<string>, string>> pendingFetches;

        private string messageId;
        private ReactionManager reactionManager;
        private string currentUserId;
        private ReactionRowControl reactionRowControl;

        public string Username
        {
            get { return _chatMessage.Username; }
            set
            {
                _chatMessage.Username = value;
                Invalidate();
            }
        }

        public ChatMessageControl(
            string msgId,
            ReactionManager manager,
            string userId,
            Dictionary<string, Tuple<TaskCompletionSource<string>, string>> pendingAttachmentFetches,
            TcpClient client,
            ChatMessage chatMessage
        )
        {
            pendingFetches = pendingAttachmentFetches;
            _chatMessage = chatMessage;
            _client = client;

            messageId = msgId;
            reactionManager = manager ?? throw new ArgumentNullException(nameof(manager));
            currentUserId = userId;

            InitializeComponent();

            // Khởi tạo reaction row
            reactionRowControl = new ReactionRowControl();
            reactionRowControl.SetCurrentUserId(currentUserId);
            reactionRowControl.ReactionClicked += (emoji) =>
            {
                reactionManager.ToggleReaction(messageId, emoji, currentUserId);
            };

            // Subscribe event reaction
            reactionManager.On_Reaction_Updated += ReactionManager_OnReactionChanged;

            // Thêm vào UI
            reactionRowControl.Size = new Size(400, 30);
            reactionRowControl.Location = new Point(0, 100);
            reactionRowControl.Visible = false;
            reactionRowControl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.Controls.Add(reactionRowControl);

            // click ra ngoài ẩn
            this.Click += (s, e) => { if (reactionControl1.Visible) HideReactionControl(); };

            // Load message + attachment
            rndCtrlChatBubble_Load(this, EventArgs.Empty);
        }

        private void rndCtrlChatBubble_Load(object sender, EventArgs e)
        {
            lblUsername.Text = _chatMessage.Username;
            lblMessage.Text = _chatMessage.Message;
            lblTimestamp.Text = _chatMessage.TimeSent.ToString("HH:mm");

            Task.Run(() =>
            {
                foreach (var attachment in _chatMessage.Attachments)
                {
                    if (attachment.IsImage)
                    {
                        try
                        {
                            var request = new Wrapper
                            {
                                Type = Types.GetFile,
                                Payload = attachment.FileName
                            };
                            string requestJson = JsonSerializer.Serialize(request);

                            var filePath = Protocol.File.FetchFile(_client, pendingFetches, attachment.FileName,
                                System.IO.Path.Combine("Cached", attachment.FileName), requestJson);

                            if (string.IsNullOrEmpty(filePath) || filePath == "Not found")
                                throw new System.IO.FileNotFoundException("Image not found.");

                            Image image = Image.FromFile(filePath);
                            PictureBox picBox = new PictureBox
                            {
                                Image = image,
                                SizeMode = PictureBoxSizeMode.Zoom,
                                Padding = new Padding(5),
                                Size = new Size(400, image.Height * 400 / image.Width)
                            };

                            flowPanelAttachments.Invoke((MethodInvoker)(() =>
                            {
                                flowPanelAttachments.Controls.Add(picBox);
                            }));
                        }
                        catch { /* handle errors */ }
                    }
                    else
                    {
                        AttachmentControl attachmentControl = new AttachmentControl(pendingFetches, _client, attachment.FileName);
                        flowPanelAttachments.Invoke((MethodInvoker)(() =>
                        {
                            flowPanelAttachments.Controls.Add(attachmentControl);
                        }));
                    }
                }
            });
        }

        private void btnMainEmoji_Click(object sender, EventArgs e)
        {
            reactionControl1.ShowEmojis();
            btnMainEmoji.Visible = false;
        }

        private void HideReactionControl()
        {
            reactionControl1.Visible = false;
            btnMainEmoji.Visible = true;
        }

        private void ReactionControl1_EmojiClicked(string emoji)
        {
            MessageBox.Show($"Bạn vừa chọn emoji: {emoji}");
            HideReactionControl();
        }

        private void ReactionManager_OnReactionChanged(string changedMessageId)
        {
            if (changedMessageId != messageId) return;

            var state = reactionManager.GetState(messageId);

            reactionRowControl.SetState(state);
            reactionRowControl.Visible = state.Emoji_To_Users.Any();
        }

       
    }
}
