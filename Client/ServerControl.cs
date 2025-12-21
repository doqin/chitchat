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
    public partial class ServerControl : RoundButtonControl
    {
        public string ServerName
        {
            get => clkTrghLblServerName.Text; set => clkTrghLblServerName.Text = value;
        }

        public string ServerAddress
        {
            get => clkTrghLblServerAddress.Text; set => clkTrghLblServerAddress.Text = value;
        }

        public event EventHandler CloseClick
        {
            add => rndBtnCtrlClose.Click += value;
            remove => rndBtnCtrlClose.Click -= value;
        }
        public ServerControl()
        {
            InitializeComponent();
        }

        private void ServerControl_Load(object sender, EventArgs e)
        {
            clkTrghLblServerName.BackColor = BackgroundColor;
            clkTrghLblServerAddress.BackColor = BackgroundColor;
            rndBtnCtrlClose.MouseOverBackColor = MouseOverBackColor;
            rndBtnCtrlClose.BackgroundColor = BackgroundColor;
            rndBtnCtrlClose.backgroundColor = BackgroundColor;
            rndBtnCtrlClose.BorderColor = backgroundColor;
            rndBtnCtrlClose.ActiveBorderColor = ActiveBorderColor;
            btnRoundButton.MouseEnter += (s, ev) =>
            {
                clkTrghLblServerName.BackColor = MouseOverBackColor;
                clkTrghLblServerAddress.BackColor = MouseOverBackColor;
                rndBtnCtrlClose.BackgroundColor = MouseOverBackColor;
                rndBtnCtrlClose.backgroundColor = MouseOverBackColor;
                rndBtnCtrlClose.BorderColor = rndBtnCtrlClose.backgroundColor;
            };
            btnRoundButton.MouseLeave += (s, ev) =>
            {
                clkTrghLblServerName.BackColor = BackgroundColor;
                clkTrghLblServerAddress.BackColor = BackgroundColor;
                rndBtnCtrlClose.BackgroundColor = BackgroundColor;
                rndBtnCtrlClose.backgroundColor = BackgroundColor;
                rndBtnCtrlClose.BorderColor = rndBtnCtrlClose.backgroundColor;
            };
        }

        private void clickThroughLabelControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
