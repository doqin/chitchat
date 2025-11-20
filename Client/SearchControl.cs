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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void roundControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
