namespace Client
{
    partial class ServerControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            rndBtnCtrlClose = new RoundButtonControl();
            clkTrghLblServerName = new ClickThroughLabelControl();
            clkTrghLblServerAddress = new ClickThroughLabelControl();
            SuspendLayout();
            // 
            // rndBtnCtrlClose
            // 
            rndBtnCtrlClose.ActiveBorderColor = SystemColors.ActiveBorder;
            rndBtnCtrlClose.Anchor = AnchorStyles.Right;
            rndBtnCtrlClose.BackColor = Color.Transparent;
            rndBtnCtrlClose.backgroundColor = SystemColors.Control;
            rndBtnCtrlClose.BackgroundColor = SystemColors.Control;
            rndBtnCtrlClose.BorderColor = SystemColors.InactiveBorder;
            rndBtnCtrlClose.BorderWidth = 1F;
            rndBtnCtrlClose.ButtonBackgroundImage = Properties.Resources.close;
            rndBtnCtrlClose.ButtonBackgroundImageLayout = ImageLayout.Zoom;
            rndBtnCtrlClose.ButtonPadding = new Padding(5);
            rndBtnCtrlClose.ButtonText = "";
            rndBtnCtrlClose.ButtonTextColor = SystemColors.ControlText;
            rndBtnCtrlClose.Location = new Point(206, 16);
            rndBtnCtrlClose.Margin = new Padding(1);
            rndBtnCtrlClose.MouseOverBackColor = SystemColors.Control;
            rndBtnCtrlClose.Name = "rndBtnCtrlClose";
            rndBtnCtrlClose.Radius = 999;
            rndBtnCtrlClose.Size = new Size(27, 27);
            rndBtnCtrlClose.TabIndex = 2;
            rndBtnCtrlClose.UseMouseOverBackColor = true;
            // 
            // clkTrghLblServerName
            // 
            clkTrghLblServerName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            clkTrghLblServerName.BackColor = SystemColors.Control;
            clkTrghLblServerName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clkTrghLblServerName.Location = new Point(14, 8);
            clkTrghLblServerName.Name = "clkTrghLblServerName";
            clkTrghLblServerName.Size = new Size(188, 23);
            clkTrghLblServerName.TabIndex = 2;
            clkTrghLblServerName.Text = "server name";
            // 
            // clkTrghLblServerAddress
            // 
            clkTrghLblServerAddress.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            clkTrghLblServerAddress.BackColor = SystemColors.Control;
            clkTrghLblServerAddress.ForeColor = SystemColors.ControlDarkDark;
            clkTrghLblServerAddress.Location = new Point(17, 29);
            clkTrghLblServerAddress.Name = "clkTrghLblServerAddress";
            clkTrghLblServerAddress.Size = new Size(185, 15);
            clkTrghLblServerAddress.TabIndex = 2;
            clkTrghLblServerAddress.Text = "server address";
            clkTrghLblServerAddress.Click += clickThroughLabelControl1_Click;
            // 
            // ServerControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            backgroundColor = SystemColors.Control;
            ButtonText = "";
            Controls.Add(clkTrghLblServerAddress);
            Controls.Add(clkTrghLblServerName);
            Controls.Add(rndBtnCtrlClose);
            Name = "ServerControl";
            Size = new Size(243, 56);
            Load += ServerControl_Load;
            Controls.SetChildIndex(rndBtnCtrlClose, 0);
            Controls.SetChildIndex(clkTrghLblServerName, 0);
            Controls.SetChildIndex(clkTrghLblServerAddress, 0);
            ResumeLayout(false);
        }

        #endregion
        private ClickThroughLabelControl clkTrghLblServerName;
        private ClickThroughLabelControl clkTrghLblServerAddress;
        private RoundButtonControl rndBtnCtrlClose;
    }
}
