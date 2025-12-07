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

        private const double dotWidthRate = 15, dotHeightRate = 15;
        private const double tickRate = 0.0000004;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            int dotWidth = (int)(Width / dotWidthRate), dotHeight = (int)(Height * dotHeightRate);

            int xDot1 = 0, xDot2 = Width / 2 - dotWidth / 2, xDot3 = Width - dotWidth,
                yDot1 = (int)(((Height - dotHeight) * Math.Sin(DateTime.Now.Ticks * tickRate) + Height - dotHeight) / 2),
                yDot2 = (int)(((Height - dotHeight) * Math.Sin(DateTime.Now.Ticks * tickRate + Math.PI / 3) + Height - dotHeight) / 2),
                yDot3 = (int)(((Height - dotHeight) * Math.Sin(DateTime.Now.Ticks * tickRate + Math.PI * 2 / 3) + Height - dotHeight) / 2);
            // Draw the dots
            e.Graphics.FillEllipse(Brushes.Black, xDot1, yDot1, dotWidth, dotHeight);
            e.Graphics.FillEllipse(Brushes.Black, xDot2, yDot2, dotWidth, dotHeight);
            e.Graphics.FillEllipse(Brushes.Black, xDot3, yDot3, dotWidth, dotHeight);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
