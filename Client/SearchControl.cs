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
    public partial class SearchControl : RoundControl
    {
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

        private void textBox1_Enter(object sender, EventArgs e)
        {
            BorderColor = ActiveBorderColor;
            BackgroundColor = ActiveBackgroundColor;
            textBox1.BackColor = BackgroundColor;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            BorderColor = borderColor;
            BackgroundColor = backgroundColor;
            textBox1.BackColor = BackgroundColor;
        }

        private void SearchControl_Load(object sender, EventArgs e)
        {
            borderColor = BorderColor;
            backgroundColor = BackgroundColor;
        }
    }
}
