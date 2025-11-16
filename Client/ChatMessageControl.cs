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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ChatMessageControl : UserControl
    {
        private readonly ChatMessage _chatMessage;
        private TcpClient _client;
        private Dictionary<string, Tuple<TaskCompletionSource<string>, string>> pendingFetches;

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

        public ChatMessageControl(Dictionary<string, Tuple<TaskCompletionSource<string>, string>> pendingAttachmentFetches, TcpClient client, ChatMessage chatMessage)
        {
            pendingFetches = pendingAttachmentFetches;
            _chatMessage = chatMessage;
            _client = client;
            InitializeComponent();
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

        private void rndCtrlChatBubble_Load(object sender, EventArgs e)
        {
            lblUsername.Text = _chatMessage.Username;
            lblMessage.Text = _chatMessage.Message;
            lblTimestamp.Text = DateTime.Now.Subtract(_chatMessage.TimeSent).Days > 0 ? _chatMessage.TimeSent.ToString("g") : _chatMessage.TimeSent.ToString("t");
            Task.Run(() =>
            {
                foreach (var attachment in _chatMessage.Attachments)
                {
                    System.Diagnostics.Debug.WriteLine($"Checking attachment: {attachment.FileName}");
                    if (attachment.IsImage)
                    {
                        System.Diagnostics.Debug.WriteLine($"Fetching image attachment: {attachment.FileName}");
                        try
                        {
                            var request = new Wrapper
                            {
                                Type = Types.GetFile,
                                Payload = attachment.FileName
                            };
                            string requestJson = JsonSerializer.Serialize(request);
                            // Fetch the attachment data from the server
                            var filePath = Protocol.File.FetchFile(_client, pendingFetches, attachment.FileName, Path.Combine("Cached", attachment.FileName), requestJson);
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
