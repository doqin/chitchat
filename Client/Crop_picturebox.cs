using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
    public partial class Crop_picturebox : Form
    {
        private Image originalImage;
        private Point dragStartPoint;
        private bool isDragging = false;

        // Biến lưu tỷ lệ cơ sở (tỷ lệ để ảnh vừa khít khung ban đầu)
        private float baseScale = 1.0f;

        public Image FinalAvatar { get; private set; }

        public Crop_picturebox()
        {
            InitializeComponent();

            pictureBox.MouseDown += PictureBox_MouseDown;
            pictureBox.MouseMove += PictureBox_MouseMove;
            pictureBox.MouseUp += PictureBox_MouseUp;

            // Bật bộ đệm kép (Double Buffered) để chống nháy khi vẽ Overlay
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, panel1, new object[] { true });

            if (pictureBox.Image != null)
            {
                originalImage = pictureBox.Image;

                // Tính tỷ lệ để ảnh gốc thu về vừa với Panel

                float ratioX = (float)panel1.Width / originalImage.Width;
                float ratioY = (float)panel1.Height / originalImage.Height;

                // Chọn tỷ lệ lớn hơn để đảm bảo ảnh lấp đầy khung (cover) chứ không bị hở

                baseScale = Math.Max(ratioX, ratioY);

                // Áp dụng kích thước ban đầu
                ApplyZoom();
                CenterImage();
            }
        }

        // Hàm áp dụng Zoom dựa trên giá trị TrackBar
        private void ApplyZoom()
        {
            if (originalImage == null) return;

            float zoomFactor = trackBar.Value / 100.0f;
            float currentScale = baseScale * zoomFactor;

            int newWidth = (int)(originalImage.Width * currentScale);
            int newHeight = (int)(originalImage.Height * currentScale);

            pictureBox.Size = new Size(newWidth, newHeight);
        }

        // Sự kiện khi kéo thanh trượt
        private void trackBarZoom_ValueChanged(object sender, EventArgs e)
        {
            ApplyZoom();

            if (trackBar.Value == trackBar.Minimum)
            {
                CenterImage();
            }
        }

        private void CenterImage()
        {
            pictureBox.Left = (panel1.Width - pictureBox.Width) / 2;
            pictureBox.Top = (panel1.Height - pictureBox.Height) / 2;
        }


        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragStartPoint = e.Location;
            }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int deltaX = e.X - dragStartPoint.X;
                int deltaY = e.Y - dragStartPoint.Y;

                // Tính toán vị trí mới
                int newLeft = pictureBox.Left + deltaX;
                int newTop = pictureBox.Top + deltaY;

                if (newLeft > 0) newLeft = 0;
                if (newTop > 0) newTop = 0;
                if (newLeft + pictureBox.Width < panel1.Width) newLeft = panel1.Width - pictureBox.Width;
                if (newTop + pictureBox.Height < panel1.Height) newTop = panel1.Height - pictureBox.Height; 

                pictureBox.Left = newLeft;
                pictureBox.Top = newTop;
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void btnCrop_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;

            try
            {
                int cropSize = Math.Min(panel1.Width, panel1.Height);
                int panelCenterX = panel1.Width / 2;
                int panelCenterY = panel1.Height / 2;

                int cropX_screen = -pictureBox.Left + (panelCenterX - cropSize / 2);
                int cropY_screen = -pictureBox.Top + (panelCenterY - cropSize / 2);

                float ratio = (float)originalImage.Width / pictureBox.Width;

                int realX = (int)(cropX_screen * ratio);
                int realY = (int)(cropY_screen * ratio);
                int realSize = (int)(cropSize * ratio);

                if (realX < 0) realX = 0;
                if (realY < 0) realY = 0;
                if (realX + realSize > originalImage.Width) realSize = originalImage.Width - realX;
                if (realY + realSize > originalImage.Height) realSize = originalImage.Height - realY;

                if (realSize <= 0) return;

                Bitmap bmp = new Bitmap(originalImage);
                Rectangle rect = new Rectangle(realX, realY, realSize, realSize);
                Bitmap croppedSquare = bmp.Clone(rect, bmp.PixelFormat);

                PreviewAvatarForm preview = new PreviewAvatarForm(croppedSquare);
                if (preview.ShowDialog() == DialogResult.OK)
                {
                    this.FinalAvatar = preview.FinalCircularImage;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

    }
}