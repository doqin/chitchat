using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class SplashScreen : Form
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public SplashScreen()
        {
            InitializeComponent();


            timer.Interval = 3000; // 3 giây
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();
            new ServerDiscoveryForm().Show(); // Form chính của app
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {

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

    }

}
