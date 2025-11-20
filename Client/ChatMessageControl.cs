using Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.Sockets;
using System.Text;
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
        private Dictionary<string, Tuple<TaskCompletionSource<string>, string>> pendingFetches;
        private bool _isRight;
        private static readonly SemaphoreSlim _readCache = new SemaphoreSlim(1, 1);

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

        public ChatMessageControl(Dictionary<string, Tuple<TaskCompletionSource<string>, string>> pendingAttachmentFetches, TcpClient client, ChatMessage chatMessage, bool isRight)
        {
            pendingFetches = pendingAttachmentFetches;
            _isRight = isRight;
            _chatMessage = chatMessage;
            _client = client;
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
        }

        /// <summary>
        /// Corrects the orientation of an image based on its EXIF data
        /// </summary>
        /// <param name="image">The image to correct</param>
        /// <returns>The corrected image</returns>
        private Image CorrectImageOrientation(Image image)
        {
            const int ExifOrientationTagId = 0x0112; // EXIF orientation tag

            if (!image.PropertyIdList.Contains(ExifOrientationTagId))
                return image;

            var property = image.GetPropertyItem(ExifOrientationTagId);
            int orientation = BitConverter.ToUInt16(property.Value, 0);

            switch (orientation)
            {
                case 2:
                    image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    break;
                case 3:
                    image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case 4:
                    image.RotateFlip(RotateFlipType.Rotate180FlipX);
                    break;
                case 5:
                    image.RotateFlip(RotateFlipType.Rotate90FlipX);
                    break;
                case 6:
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case 7:
                    image.RotateFlip(RotateFlipType.Rotate270FlipX);
                    break;
                case 8:
                    image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
            }

            // Remove the EXIF orientation tag to prevent double-rotation
            image.RemovePropertyItem(ExifOrientationTagId);

            return image;
        }

        private void ChatMessageControl_Load(object sender, EventArgs e)
        {
            //lblUsername.Text = _chatMessage.Username;
            lblMessage.Text = _chatMessage.Message;
            lblTimestamp.Text = DateTime.Now.Subtract(_chatMessage.TimeSent).Days > 0 ? _chatMessage.TimeSent.ToString("g") : _chatMessage.TimeSent.ToString("t");
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
                        if (System.IO.File.Exists(cachedImagePath))
                        {
                            System.Diagnostics.Debug.WriteLine($"Loading cached profile image: {_chatMessage.ProfileImagePath}");

                            Image profileImage = Image.FromFile(cachedImagePath);
                            // Update the UI on the main thread
                            crclrPicBoxProfilePicture.Invoke((MethodInvoker)(() =>
                            {
                                crclrPicBoxProfilePicture.Image = profileImage;
                            }));
                        }
                        else
                        {
                            try
                            {
                                System.Diagnostics.Debug.WriteLine($"Fetching profile image: {_chatMessage.ProfileImagePath}");
                                var request = new Wrapper
                                {
                                    Type = Types.GetFile,
                                    Payload = _chatMessage.ProfileImagePath
                                };
                                string requestJson = JsonSerializer.Serialize(request);
                                // Fetch the profile image data from the server
                                var filePath = Protocol.File.FetchFile(_client, pendingFetches, _chatMessage.ProfileImagePath, cachedImagePath, requestJson);
                                if (string.IsNullOrEmpty(filePath) || (!string.IsNullOrEmpty(filePath) && filePath == "Not found"))
                                {
                                    throw new FileNotFoundException("Profile image not found on server.");
                                }
                                // Load image
                                Image profileImage = Image.FromFile(filePath);
                                // Update the UI on the main thread
                                crclrPicBoxProfilePicture.Invoke((MethodInvoker)(() =>
                                {
                                    crclrPicBoxProfilePicture.Image = profileImage;
                                }));
                                System.Diagnostics.Debug.WriteLine($"Profile image fetched and set: {_chatMessage.ProfileImagePath}");
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Debug.WriteLine($"Error fetching profile image: {ex.Message}");
                            }
                        }
                    }
                    finally
                    {
                        _readCache.Release();
                    }
                }

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
                            image = CorrectImageOrientation(image);
                            PictureBox picBox = new PictureBox
                            {
                                Image = image,
                                SizeMode = PictureBoxSizeMode.Zoom,
                                Padding = new Padding(5),
                                Size = new Size(400, image.Height * 400 / image.Width),
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
                            var filePath = Protocol.File.FetchFile(_client, pendingFetches, attachment.FileName, cachedAttachmentPath, requestJson);
                            if (string.IsNullOrEmpty(filePath) || (!string.IsNullOrEmpty(filePath) && filePath == "Not found"))
                            {
                                throw new FileNotFoundException("Image not found on server.");
                            }
                            // Load image and correct orientation
                            Image image = Image.FromFile(filePath);
                            image = CorrectImageOrientation(image);

                            PictureBox picBox = new PictureBox
                            {
                                Image = image,
                                SizeMode = PictureBoxSizeMode.Zoom,
                                Padding = new Padding(5),
                                Size = new Size(400, image.Height * 400 / image.Width),
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
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Error fetching image: {ex.Message}");
                        }
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"Adding attachment control for: {attachment.FileName}");
                        AttachmentControl attachmentControl = new AttachmentControl(pendingFetches, _client, attachment.FileName);
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
            });
        }
    }
}
