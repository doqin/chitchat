using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class RoundTextBoxControl : RoundControl
    {
        public Color TextBoxBackgroundColor { get => txtbox.BackColor; set => txtbox.BackColor = value; }
        public string Text { get => txtbox.Text; set => txtbox.Text = value; }

        public RoundTextBoxControl()
        {
            InitializeComponent();
            txtbox.BackColor = BackgroundColor;
        }

        private void RoundTextBoxControl_Load(object sender, EventArgs e)
        {

        }
    }
}
