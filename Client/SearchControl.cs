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
    public partial class SearchControl : UserControl
    {

        public Color BackgroundColor { get => roundControl1.BackgroundColor; set { roundControl1.BackgroundColor = value; textBox1.BackColor = value; } }
        public Color BorderColor { get => roundControl1.BorderColor; set => roundControl1.BorderColor = value; }
        public Color ActiveBorderColor { get; set; } = Color.FromKnownColor(KnownColor.ActiveBorder);
        public Color ActiveBackgroundColor { get; set; } = Color.FromKnownColor(KnownColor.ButtonHighlight);

        private Color borderColor;

        private Color backgroundColor;

        public Padding IconPadding
        {
            get { return pnlIcon.Padding; }
            set { pnlIcon.Padding = value; }
        }

        public int IconWidth
        {
            get { return pnlIcon.Width; }
            set { pnlIcon.Width = value; }
        }

        public SearchControl()
        {
            InitializeComponent();
        }

        private void roundControl1_Load(object sender, EventArgs e)
        {
            borderColor = roundControl1.BorderColor;
            backgroundColor = roundControl1.BackgroundColor;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            roundControl1.BorderColor = ActiveBorderColor;
            BackgroundColor = ActiveBackgroundColor;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            roundControl1.BorderColor = borderColor;
            BackgroundColor = backgroundColor;
        }
    }
}
