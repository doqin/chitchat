using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    public partial class SplashScreen : Form
    {
        private System.Windows.Forms.Timer mainTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer animationTimer = new System.Windows.Forms.Timer();

        private int alpha = 0;   // Độ mờ chữ (fade-in)
        private int radius = 20; // Bán kính vòng sáng

        public SplashScreen()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // Chống nháy khi vẽ animation
            this.FormBorderStyle = FormBorderStyle.None; // Gỡ viền form cho đẹp
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(11, 7, 17); // Nền giống app chính
            this.ClientSize = new Size(800, 450);

            // Timer điều khiển thời gian hiển thị
            mainTimer.Interval = 3500; // 3.5s rồi chuyển sang form chính
            mainTimer.Tick += Timer_Tick;
            mainTimer.Start();

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
            mainForm.Show();
        }

        private void Animation_Tick(object sender, EventArgs e)
        {
            if (alpha < 255) alpha += 5;
            if (radius < 150) radius += 4;
            this.Invalidate(); // Gọi lại OnPaint để vẽ lại
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Vẽ nền gradient nhẹ (dark tech look)
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(15, 20, 35),
                Color.FromArgb(10, 10, 20),
                45f))
            {
                g.FillRectangle(brush, this.ClientRectangle);
            }

            // Vẽ vòng sáng xung quanh logo
            using (Pen pen = new Pen(Color.FromArgb(60, 0, 180, 255), 4))
            {
                g.DrawEllipse(pen, this.Width / 2 - radius, this.Height / 2 - radius, radius * 2, radius * 2);
            }

            // Vẽ chữ logo “ChitChat”
            using (Font font = new Font("Segoe UI", 36, FontStyle.Bold))
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(alpha, 0, 200, 255)))
            {
                string text = "ChitChat";
                SizeF textSize = g.MeasureString(text, font);
                g.DrawString(text, font, brush, (this.Width - textSize.Width) / 2, (this.Height - textSize.Height) / 2 - 10);
            }

            // Vẽ phụ đề nhỏ hơn
            using (Font subFont = new Font("Segoe UI", 12, FontStyle.Italic))
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(alpha, 150, 150, 150)))
            {
                string sub = "Connecting through LAN";
                SizeF size = g.MeasureString(sub, subFont);
                g.DrawString(sub, subFont, brush, (this.Width - size.Width) / 2, (this.Height - size.Height) / 2 + 40);
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
