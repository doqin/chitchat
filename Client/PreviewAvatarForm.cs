using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
    public partial class PreviewAvatarForm : Form
    {
        public Image FinalCircularImage { get; private set; }

        public PreviewAvatarForm(Image croppedSquare)
        {
            InitializeComponent();
            
            FinalCircularImage = MakeCircularImage(croppedSquare);
            
            // Hiển thị lên PictureBox
            pictureBoxPreview.Image = FinalCircularImage;
            pictureBoxPreview.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private Image MakeCircularImage(Image img)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias; 
                
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, img.Width, img.Height);
                
                g.SetClip(path);

                g.DrawImage(img, 0, 0);
            }
            return bmp;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}