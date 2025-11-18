using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class CircularPictureBox : PictureBox
    {
        public Color OutlineColor { get; set; } = Color.White;
        public float OutlineWidth { get; set; } = 2.0f;

        public CircularPictureBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, this.Width - 1, this.Height - 1);
                this.Region = new Region(path);

                if (this.Image != null)
                {
                    // Calculate the aspect ratios
                    float rpb = (float)this.Width / (float)this.Height;
                    float rimg = (float)this.Image.Width / (float)this.Image.Height;

                    RectangleF srcRect;
                    if (rpb > rimg) // PictureBox is wider than image
                    {
                        float newWidth = this.Image.Width;
                        float newHeight = newWidth / rpb;
                        float y = (this.Image.Height - newHeight) / 2;
                        srcRect = new RectangleF(0, y, newWidth, newHeight);
                    }
                    else // PictureBox is taller than or same as image
                    {
                        float newHeight = this.Image.Height;
                        float newWidth = newHeight * rpb;
                        float x = (this.Image.Width - newWidth) / 2;
                        srcRect = new RectangleF(x, 0, newWidth, newHeight);
                    }

                    pe.Graphics.DrawImage(this.Image, this.ClientRectangle, srcRect, GraphicsUnit.Pixel);
                }
                // Draws outline

                using (var pen = new Pen(OutlineColor, OutlineWidth))
                {
                    pe.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                    pe.Graphics.DrawEllipse(pen, 1, 1, this.Width - 3, this.Height - 3);
                }
            }
        }
    }
}
