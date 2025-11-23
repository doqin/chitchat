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

        public bool DrawOutline { get; set; } = false;

        public CircularPictureBox()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Width = this.Height; // Keep it a circle
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            this.Region = null; // Allow painting outside the region

            using (var path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, this.Width, this.Height);

                // Fill the circle with the image
                if (this.Image != null)
                {
                    using (var brush = new TextureBrush(this.Image, WrapMode.Clamp))
                    {
                        // Center the image inside the circle, maintaining aspect ratio and cropping.
                        float rpb = (float)this.Width / this.Height;
                        float rimg = (float)this.Image.Width / this.Image.Height;

                        float scale;
                        float dx = 0, dy = 0;

                        if (rpb > rimg) // PictureBox is wider than image, so scale to width
                        {
                            scale = (float)this.Width / this.Image.Width;
                            dy = (this.Height - this.Image.Height * scale) / 2;
                        }
                        else // PictureBox is taller or same aspect ratio, so scale to height
                        {
                            scale = (float)this.Height / this.Image.Height;
                            dx = (this.Width - this.Image.Width * scale) / 2;
                        }

                        // Apply the transformation
                        brush.ScaleTransform(scale, scale);
                        brush.TranslateTransform(dx / scale, dy / scale);

                        pe.Graphics.FillPath(brush, path);
                    }
                }

                // Set the region to the circular path to clip the control's visible area
                this.Region = new Region(path);

                // Draws outline
                if (DrawOutline)
                {
                    using (var pen = new Pen(OutlineColor, OutlineWidth))
                    {
                        // Adjust for pen width to draw inside the circle
                        float halfPenWidth = pen.Width / 2;
                        pe.Graphics.DrawEllipse(pen, halfPenWidth, halfPenWidth, this.Width - pen.Width, this.Height - pen.Width);
                    }
                }
            }
        }

        private void CircularPictureBox_Load(object sender, EventArgs e)
        {

        }
    }
}
