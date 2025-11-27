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
            roundButtonControl1 = new RoundButtonControl();
            clkTrghLblServerName = new ClickThroughLabelControl();
            clkTrghLblServerAddress = new ClickThroughLabelControl();
            SuspendLayout();
            // 
            // roundButtonControl1
            // 
            roundButtonControl1.ActiveBorderColor = SystemColors.ActiveBorder;
            roundButtonControl1.BackColor = Color.Transparent;
            roundButtonControl1.BackgroundColor = SystemColors.Control;
            roundButtonControl1.BorderColor = SystemColors.Control;
            roundButtonControl1.BorderWidth = 1F;
            roundButtonControl1.ButtonBackgroundImage = null;
            roundButtonControl1.ButtonBackgroundImageLayout = ImageLayout.Tile;
            roundButtonControl1.ButtonPadding = new Padding(0);
            roundButtonControl1.ButtonText = "";
            roundButtonControl1.ButtonTextColor = SystemColors.ControlText;
            roundButtonControl1.Dock = DockStyle.Fill;
            roundButtonControl1.Location = new Point(0, 0);
            roundButtonControl1.Margin = new Padding(1);
            roundButtonControl1.MouseOverBackColor = Color.Empty;
            roundButtonControl1.Name = "roundButtonControl1";
            roundButtonControl1.Radius = 10;
            roundButtonControl1.Size = new Size(241, 59);
            roundButtonControl1.TabIndex = 0;
            roundButtonControl1.UseMouseOverBackColor = true;
            roundButtonControl1.Click += roundButtonControl1_Click;
            // 
            // clkTrghLblServerName
            // 
            clkTrghLblServerName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            clkTrghLblServerName.BackColor = SystemColors.Control;
            clkTrghLblServerName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clkTrghLblServerName.Location = new Point(16, 10);
            clkTrghLblServerName.Name = "clkTrghLblServerName";
            clkTrghLblServerName.Size = new Size(206, 23);
            clkTrghLblServerName.TabIndex = 2;
            clkTrghLblServerName.Text = "server name";
            // 
            // clkTrghLblServerAddress
            // 
            clkTrghLblServerAddress.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            clkTrghLblServerAddress.BackColor = SystemColors.Control;
            clkTrghLblServerAddress.ForeColor = SystemColors.ControlDarkDark;
            clkTrghLblServerAddress.Location = new Point(18, 31);
            clkTrghLblServerAddress.Name = "clkTrghLblServerAddress";
            clkTrghLblServerAddress.Size = new Size(204, 15);
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
            Controls.Add(clkTrghLblServerName);
            Controls.Add(clkTrghLblServerAddress);
            Controls.Add(roundButtonControl1);
            Name = "ServerControl";
            Size = new Size(241, 59);
            Load += ServerControl_Load;
            ResumeLayout(false);
        }

        #endregion

        private RoundButtonControl roundButtonControl1;
        private ClickThroughLabelControl clkTrghLblServerName;
        private ClickThroughLabelControl clkTrghLblServerAddress;
    }
}
