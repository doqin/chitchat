using Client.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class RoundButtonControl : RoundControl
    {
        public string ButtonText
        {
            get { return btnRoundButton.Text; }
            set { btnRoundButton.Text = value; }
        }

        public Color ButtonTextColor
        {
            get { return btnRoundButton.ForeColor; }
            set { btnRoundButton.ForeColor = value; }
        }

        public Image? ButtonBackgroundImage
        {
            get { return btnRoundButton.BackgroundImage; }
            set { btnRoundButton.BackgroundImage = value; }
        }

        public ImageLayout ButtonBackgroundImageLayout
        {
            get { return btnRoundButton.BackgroundImageLayout; }
            set { btnRoundButton.BackgroundImageLayout = value; }
        }

        public Padding ButtonPadding
        {
            get { return pnlButton.Padding; }
            set { pnlButton.Padding = value; }
        }

        public bool UseMouseOverBackColor { get; set; } = false;

        public Color MouseOverBackColor { get; set; }

        private Color backgroundColor;

        public RoundButtonControl()
        {
            InitializeComponent();
        }

        private void RoundButtonControl_Load(object sender, EventArgs e)
        {
            btnRoundButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnRoundButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            //btnRoundButton.BackColor = BackgroundColor;
            backgroundColor = BackgroundColor;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //btnRoundButton.Location = new Point(0, 0);
            //btnRoundButton.Size = new Size(Size.Width - 40, Size.Height - 40);
            //btnRoundButton.BackColor = BackgroundColor;
        }

        private void btnRoundButton_Click(object sender, EventArgs e) => InvokeOnClick(this, e);

        public void btnRoundButton_MouseEnter(object sender, EventArgs e)
        {
            if (UseMouseOverBackColor)
            {
                BackgroundColor = MouseOverBackColor;
                
            }
        }

        public void btnRoundButton_MouseLeave(object sender, EventArgs e)
        {
            if (UseMouseOverBackColor)
            {
                BackgroundColor = backgroundColor;
            }
        }

        private void RoundButton_MouseEnter(object sender, EventArgs e) => btnRoundButton_MouseEnter((object)sender, e);
        private void RoundButton_MouseLeave(object sender, EventArgs e) => btnRoundButton_MouseLeave((object)sender, e);

    }
}
