using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
    public partial class SplashScreen : Form
    {
        private System.Windows.Forms.Timer mainTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer animationTimer = new System.Windows.Forms.Timer();

        private int alpha = 0;   // Độ mờ chữ (fade-in)
        private int radius = 20; // Bán kính vòng sáng
        private float[] orbitAngles = new float[6];
        private float[] orbitSpeeds = new float[6];
        private float[] orbitDistances = new float[6];
        private float[] orbitSizes = new float[6];

        public SplashScreen()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // Chống nháy khi vẽ animation
            this.FormBorderStyle = FormBorderStyle.None; // Gỡ viền form cho đẹp
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(11, 7, 17); // Nền giống app chính
            //this.ClientSize = new Size(800, 450);
            Random rand = new Random(DateTime.Now.Millisecond);
            orbitAngles.Select((angle, index) => orbitAngles[index] = rand.Next(0, 360)).ToArray();
            orbitSpeeds.Select((speed, index) => orbitSpeeds[index] = (float)(rand.NextDouble() * 1.5 + 2.0)).ToArray();
            orbitDistances.Select((distance, index) => orbitDistances[index] = rand.Next(160, 250)).ToArray();
            orbitSizes.Select((size, index) => orbitSizes[index] = rand.Next(15, 30)).ToArray();
#if PREVIEW
            // Don't go to main form automatically in preview builds
#else
            // Timer điều khiển thời gian hiển thị
            mainTimer.Interval = 3500; // 3.5s rồi chuyển sang form chính
            mainTimer.Tick += Timer_Tick;
            mainTimer.Start();
#endif
            // Timer animation GDI+
            animationTimer.Interval = 40; // 25fps
            animationTimer.Tick += Animation_Tick;
            animationTimer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            mainTimer.Stop();
            animationTimer.Stop();

            this.Hide();

            // Create and show the main form
            var mainForm = new ServerDiscoveryForm();
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.Show();
        }

        private void Animation_Tick(object sender, EventArgs e)
        {
            if (alpha < 255) alpha += 5;
            if (radius < 150) radius += 4;
            for (int i = 0; i < orbitAngles.Length; i++)
            {
                orbitAngles[i] += orbitSpeeds[i];
                if (orbitAngles[i] >= 360f)
                {
                    orbitAngles[i] -= 360f;
                }
            }
            this.Invalidate(); // Gọi lại OnPaint để vẽ lại
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Vẽ nền gradient nhẹ (dark tech look)
            using (var brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(113, 96, 232),
                Color.FromArgb(81, 163, 163),
                45f)
                )
            {
                g.FillRectangle(brush, this.ClientRectangle);
            }

            PointF clientCenter = new PointF(this.ClientSize.Width / 2f, this.ClientSize.Height / 2f);

/*            using (Font font = new Font("Segoe UI", 36, FontStyle.Bold))
            {
                string text = "ChitChat";
                SizeF textSize = g.MeasureString(text, font);
                float textX = clientCenter.X - (textSize.Width / 2f);
                float textY = clientCenter.Y - (textSize.Height / 2f);
                using (var textBrush = new SolidBrush(Color.FromArgb(Math.Min(alpha, 255), 255, 255, 255)))
                {
                    g.DrawString(text, font, textBrush, textX, textY);
                }
            }*/

            PointF[] orbitPositions = new PointF[orbitAngles.Length];
            for (int i = 0; i < orbitAngles.Length; i++)
            {
                float radians = orbitAngles[i] * (float)Math.PI / 180f;
                float orbitRadius = orbitDistances[i];
                float circleX = clientCenter.X + (float)Math.Cos(radians) * orbitRadius;
                float circleY = clientCenter.Y + (float)Math.Sin(radians) * orbitRadius;
                orbitPositions[i] = new PointF(circleX, circleY);
            }

            if (orbitPositions.Length > 0)
            {
                float sumX = 0f;
                float sumY = 0f;
                for (int i = 0; i < orbitPositions.Length; i++)
                {
                    sumX += orbitPositions[i].X;
                    sumY += orbitPositions[i].Y;
                }

                float offsetX = clientCenter.X - (sumX / orbitPositions.Length);
                float offsetY = clientCenter.Y - (sumY / orbitPositions.Length);

                for (int i = 0; i < orbitPositions.Length; i++)
                {
                    orbitPositions[i] = new PointF(orbitPositions[i].X + offsetX, orbitPositions[i].Y + offsetY);
                }
            }

            Random rand = new Random(1000);
            for (int i = 0; i < orbitAngles.Length; i++)
            {
                float circleSize = orbitSizes[i];
                PointF circlePos = orbitPositions[i];
                var circleRect = new RectangleF(circlePos.X - circleSize / 2, circlePos.Y - circleSize / 2, circleSize, circleSize);
                using (var circleBrush = new SolidBrush(Color.FromArgb(rand.Next(120, 255), 255, 255, 255)))
                {
                    g.FillEllipse(circleBrush, circleRect);
                }
            }
            for (int i = 0; i < orbitAngles.Length; i++)
            {
                for (int j = i + 1; j < orbitAngles.Length; j++)
                {
                    PointF pointI = orbitPositions[i];
                    PointF pointJ = orbitPositions[j];
                    using (var linePen = new Pen(Color.FromArgb(50, 255, 255, 255), 2))
                    {
                        linePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                        g.DrawLine(linePen, pointI, pointJ);
                    }
                }
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Opacity = 0;
            System.Windows.Forms.Timer fade = new System.Windows.Forms.Timer { Interval = 50 };
            fade.Tick += (s, ev) =>
            {
                if (this.Opacity < 1)
                    this.Opacity += 0.05;
                else
                    fade.Stop();
            };
            fade.Start();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
