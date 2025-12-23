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
        public Color OutlineColor { get; set; } = Color.Gray;
        public float OutlineWidth { get; set; } = 2.0f;

        public bool DrawOutline { get; set; } = false;

        public CircularPictureBox()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (this.Width != this.Height)
            {
                int side = Math.Min(this.Width, this.Height);
                this.Size = new Size(side, side);
            }

            using (GraphicsPath path = GetCirclePath())
            {
                Region = new Region(path);
            }

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (Image == null)
            {
                base.OnPaint(pe);
                return;
            }

            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pe.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            pe.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            using (GraphicsPath path = GetCirclePath())
            {
                pe.Graphics.SetClip(path);

                RectangleF sourceRect = GetCoverSourceRectangle(Image.Size);
                Rectangle destRect = ClientRectangle;

                pe.Graphics.DrawImage(Image, destRect, sourceRect, GraphicsUnit.Pixel);
                pe.Graphics.ResetClip();

                if (DrawOutline && OutlineWidth > 0f)
                {
                    using (Pen outlinePen = new Pen(OutlineColor, OutlineWidth))
                    {
                        outlinePen.Alignment = PenAlignment.Center;
                        pe.Graphics.DrawPath(outlinePen, path);
                    }
                }
            }
        }

        private RectangleF GetCoverSourceRectangle(Size imageSize)
        {
            if (Width == 0 || Height == 0)
            {
                return new RectangleF(PointF.Empty, imageSize);
            }

            float imageRatio = (float)imageSize.Width / imageSize.Height;
            float controlRatio = (float)Width / Height;

            if (imageRatio > controlRatio)
            {
                float desiredWidth = imageSize.Height * controlRatio;
                float offsetX = (imageSize.Width - desiredWidth) / 2f;
                return new RectangleF(offsetX, 0, desiredWidth, imageSize.Height);
            }
            else
            {
                float desiredHeight = imageSize.Width / controlRatio;
                float offsetY = (imageSize.Height - desiredHeight) / 2f;
                return new RectangleF(0, offsetY, imageSize.Width, desiredHeight);
            }
        }

        private GraphicsPath GetCirclePath()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, this.Width - 1, this.Height - 1);
            return path;
        }

        private void CircularPictureBox_Load(object sender, EventArgs e)
        {
            using (GraphicsPath path = GetCirclePath())
            {
                Region = new Region(path);
            }
        }
    }
}
