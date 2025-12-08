using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class LoadingAnimationControl : UserControl
    {
        public LoadingAnimationControl()
        {
            InitializeComponent();
        }

        public int Padding { get; set; } = 5;

        public int DotWidth { get; set; } = 15;
        public int DotHeight { get; set; } = 15;
        public double TickRate { get; set; } = 0.0000004;
        public Color BrushColor { get; set; } = Color.Gray;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int xDot1 = Padding, xDot2 = Width / 2 - DotWidth / 2, xDot3 = Width - DotWidth - Padding,
                yDot1 = (int)(((Height - DotHeight) * Math.Sin(DateTime.Now.Ticks * TickRate) + Height - DotHeight) / 2),
                yDot2 = (int)(((Height - DotHeight) * Math.Sin(DateTime.Now.Ticks * TickRate + Math.PI / 3) + Height - DotHeight) / 2),
                yDot3 = (int)(((Height - DotHeight) * Math.Sin(DateTime.Now.Ticks * TickRate + Math.PI * 2 / 3) + Height - DotHeight) / 2);
            // Draw the dots
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Brush brush = new SolidBrush(BrushColor);
            e.Graphics.FillEllipse(brush, xDot1, yDot1, DotWidth, DotHeight);
            e.Graphics.FillEllipse(brush, xDot2, yDot2, DotWidth, DotHeight);
            e.Graphics.FillEllipse(brush, xDot3, yDot3, DotWidth, DotHeight);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
