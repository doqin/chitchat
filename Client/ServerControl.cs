using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ServerControl : UserControl
    {
        public string ServerName
        {
            get => clkTrghLblServerName.Text; set => clkTrghLblServerName.Text = value;
        }

        public string ServerAddress
        {
            get => clkTrghLblServerAddress.Text; set => clkTrghLblServerAddress.Text = value;
        }

        public bool UseMouseOverBackColor
        {
            get => roundButtonControl1.UseMouseOverBackColor;
            set => roundButtonControl1.UseMouseOverBackColor = value;
        }

        public Color MouseOverBackColor
        {
            get => roundButtonControl1.MouseOverBackColor;
            set => roundButtonControl1.MouseOverBackColor = value;
        }

        public Color ServerNameColor
        {
            get => clkTrghLblServerName.ForeColor;
            set => clkTrghLblServerName.ForeColor = value;
        }

        public Color ServerAddressColor
        {
            get => clkTrghLblServerAddress.ForeColor;
            set => clkTrghLblServerAddress.ForeColor = value;
        }

        public Color BackgroundColor
        {
            get => roundButtonControl1.BackgroundColor;
            set
            {
                roundButtonControl1.BackgroundColor = value;
                clkTrghLblServerName.BackColor = value;
                clkTrghLblServerAddress.BackColor = value;
            }
        }

        public Color backgroundColor;

        public Color BorderColor
        {
            get => roundButtonControl1.BorderColor;
            set => roundButtonControl1.BorderColor = value;
        }

        public ServerControl()
        {
            InitializeComponent();
        }

        private void roundButtonControl1_Click(object sender, EventArgs e) => InvokeOnClick(this, e);

        private void lblServerAddress_Click(object sender, EventArgs e) => InvokeOnClick(this, e);

        private void roundButtonControl1_MouseEnter(object sender, EventArgs e)
        {
            if (UseMouseOverBackColor)
            {
                BackgroundColor = MouseOverBackColor;
            }
        }

        private void roundButtonControl1_MouseLeave(object sender, EventArgs e)
        {
            if (UseMouseOverBackColor)
            {
                BackgroundColor = backgroundColor;
            }
        }

        private void ServerControl_Load(object sender, EventArgs e)
        {
            backgroundColor = BackgroundColor;
            roundButtonControl1.btnRoundButton.MouseEnter += roundButtonControl1_MouseEnter;
            roundButtonControl1.btnRoundButton.MouseLeave += roundButtonControl1_MouseLeave;
        }

        private void clickThroughLabelControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
