namespace Client
{
    partial class ServerDiscoveryForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainerMain = new SplitContainer();
            pnlServers = new Panel();
            flwLytPnlServers = new FlowLayoutPanel();
            pnlTop = new Panel();
            searchControl1 = new SearchControl();
            roundButtonControl1 = new RoundButtonControl();
            label1 = new Label();
            pnlLeft = new Panel();
            panel2 = new Panel();
            btnSettings = new RoundButtonControl();
            panel1 = new Panel();
            picAvatar = new CircularPictureBox();
            lblProceed = new Label();
            lblWelcome = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            pnlServers.SuspendLayout();
            pnlTop.SuspendLayout();
            pnlLeft.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            SuspendLayout();
            // 
            // splitContainerMain
            // 
            splitContainerMain.BackColor = Color.FromArgb(247, 245, 243);
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.FixedPanel = FixedPanel.Panel1;
            splitContainerMain.IsSplitterFixed = true;
            splitContainerMain.Location = new Point(0, 0);
            splitContainerMain.Margin = new Padding(1);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.AutoScroll = true;
            splitContainerMain.Panel1.BackColor = Color.White;
            splitContainerMain.Panel1.Controls.Add(pnlServers);
            splitContainerMain.Panel1.Controls.Add(pnlTop);
            splitContainerMain.Panel1.Controls.Add(label1);
            splitContainerMain.Panel1.Controls.Add(pnlLeft);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.AutoScroll = true;
            splitContainerMain.Panel2.BackColor = Color.FromArgb(247, 245, 243);
            splitContainerMain.Panel2.Controls.Add(lblProceed);
            splitContainerMain.Panel2.Controls.Add(lblWelcome);
            splitContainerMain.Size = new Size(1207, 639);
            splitContainerMain.SplitterDistance = 389;
            splitContainerMain.SplitterWidth = 2;
            splitContainerMain.TabIndex = 5;
            splitContainerMain.Paint += splitContainerMain_Paint;
            // 
            // pnlServers
            // 
            pnlServers.Controls.Add(flwLytPnlServers);
            pnlServers.Dock = DockStyle.Fill;
            pnlServers.Location = new Point(62, 92);
            pnlServers.Name = "pnlServers";
            pnlServers.Padding = new Padding(5);
            pnlServers.Size = new Size(327, 547);
            pnlServers.TabIndex = 4;
            // 
            // flwLytPnlServers
            // 
            flwLytPnlServers.AutoScroll = true;
            flwLytPnlServers.BackColor = Color.Transparent;
            flwLytPnlServers.Dock = DockStyle.Fill;
            flwLytPnlServers.FlowDirection = FlowDirection.TopDown;
            flwLytPnlServers.Location = new Point(5, 5);
            flwLytPnlServers.Name = "flwLytPnlServers";
            flwLytPnlServers.Size = new Size(317, 537);
            flwLytPnlServers.TabIndex = 0;
            flwLytPnlServers.WrapContents = false;
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(searchControl1);
            pnlTop.Controls.Add(roundButtonControl1);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(62, 46);
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new Padding(5);
            pnlTop.Size = new Size(327, 46);
            pnlTop.TabIndex = 3;
            // 
            // searchControl1
            // 
            searchControl1.ActiveBackgroundColor = SystemColors.ButtonHighlight;
            searchControl1.ActiveBorderColor = Color.FromArgb(113, 96, 232);
            searchControl1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            searchControl1.BackColor = Color.Transparent;
            searchControl1.BackgroundColor = SystemColors.Control;
            searchControl1.BorderColor = SystemColors.InactiveBorder;
            searchControl1.BorderWidth = 1F;
            searchControl1.Dock = DockStyle.Fill;
            searchControl1.IconPadding = new Padding(7);
            searchControl1.IconWidth = 40;
            searchControl1.Location = new Point(5, 5);
            searchControl1.Margin = new Padding(1);
            searchControl1.Name = "searchControl1";
            searchControl1.Radius = 10;
            searchControl1.Size = new Size(277, 36);
            searchControl1.TabIndex = 0;
            // 
            // roundButtonControl1
            // 
            roundButtonControl1.ActiveBorderColor = SystemColors.ActiveBorder;
            roundButtonControl1.BackColor = Color.Transparent;
            roundButtonControl1.BackgroundColor = SystemColors.Control;
            roundButtonControl1.BorderColor = SystemColors.InactiveBorder;
            roundButtonControl1.BorderWidth = 1F;
            roundButtonControl1.ButtonBackgroundImage = Properties.Resources.refresh;
            roundButtonControl1.ButtonBackgroundImageLayout = ImageLayout.Zoom;
            roundButtonControl1.ButtonPadding = new Padding(8);
            roundButtonControl1.ButtonText = "";
            roundButtonControl1.ButtonTextColor = Color.Black;
            roundButtonControl1.Dock = DockStyle.Right;
            roundButtonControl1.Location = new Point(282, 5);
            roundButtonControl1.Margin = new Padding(1);
            roundButtonControl1.MouseOverBackColor = SystemColors.ButtonHighlight;
            roundButtonControl1.Name = "roundButtonControl1";
            roundButtonControl1.Radius = 10;
            roundButtonControl1.Size = new Size(40, 36);
            roundButtonControl1.TabIndex = 1;
            roundButtonControl1.UseMouseOverBackColor = true;
            roundButtonControl1.Click += roundButtonControl1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(113, 96, 232);
            label1.Location = new Point(62, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(10);
            label1.Size = new Size(115, 46);
            label1.TabIndex = 1;
            label1.Text = "ChitChat";
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(247, 245, 243);
            pnlLeft.Controls.Add(panel2);
            pnlLeft.Controls.Add(panel1);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.ForeColor = SystemColors.ActiveBorder;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(62, 639);
            pnlLeft.TabIndex = 1;
            pnlLeft.Paint += pnlLeft_Paint;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnSettings);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 516);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(5);
            panel2.Size = new Size(62, 62);
            panel2.TabIndex = 2;
            // 
            // btnSettings
            // 
            btnSettings.ActiveBorderColor = SystemColors.ActiveBorder;
            btnSettings.BackColor = Color.Transparent;
            btnSettings.BackgroundColor = Color.FromArgb(247, 245, 243);
            btnSettings.BorderColor = Color.FromArgb(247, 245, 243);
            btnSettings.BorderWidth = 1F;
            btnSettings.ButtonBackgroundImage = Properties.Resources.settings;
            btnSettings.ButtonBackgroundImageLayout = ImageLayout.Zoom;
            btnSettings.ButtonPadding = new Padding(10);
            btnSettings.ButtonText = "";
            btnSettings.ButtonTextColor = SystemColors.ActiveBorder;
            btnSettings.Dock = DockStyle.Fill;
            btnSettings.Location = new Point(5, 5);
            btnSettings.Margin = new Padding(1);
            btnSettings.MouseOverBackColor = SystemColors.ButtonHighlight;
            btnSettings.Name = "btnSettings";
            btnSettings.Radius = 999;
            btnSettings.Size = new Size(52, 52);
            btnSettings.TabIndex = 1;
            btnSettings.UseMouseOverBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(picAvatar);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 578);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(62, 61);
            panel1.TabIndex = 2;
            // 
            // picAvatar
            // 
            picAvatar.Dock = DockStyle.Fill;
            picAvatar.DrawOutline = false;
            picAvatar.Location = new Point(10, 10);
            picAvatar.Name = "picAvatar";
            picAvatar.OutlineColor = Color.White;
            picAvatar.OutlineWidth = 2F;
            picAvatar.Size = new Size(41, 41);
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;
            // 
            // lblProceed
            // 
            lblProceed.Anchor = AnchorStyles.None;
            lblProceed.AutoSize = true;
            lblProceed.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProceed.Location = new Point(301, 316);
            lblProceed.Name = "lblProceed";
            lblProceed.Size = new Size(318, 17);
            lblProceed.TabIndex = 1;
            lblProceed.Text = "Kết nối đến một máy chủ LAN để bắt đầu trò chuyện.";
            // 
            // lblWelcome
            // 
            lblWelcome.Anchor = AnchorStyles.None;
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(272, 284);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(379, 32);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Chào mừng bạn đến với ChitChat!";
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Gainsboro;
            label2.Location = new Point(2, 0);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(234, 70);
            label2.TabIndex = 1;
            label2.Text = "Conversations";
            // 
            // ServerDiscoveryForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1207, 639);
            Controls.Add(splitContainerMain);
            ForeColor = Color.Black;
            Name = "ServerDiscoveryForm";
            Text = "ChitChat";
            FormClosed += ServerDiscoveryForm_FormClosed;
            Load += ServerDiscoveryForm_Load;
            KeyDown += ServerDiscoveryForm_KeyDown;
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel1.PerformLayout();
            splitContainerMain.Panel2.ResumeLayout(false);
            splitContainerMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            pnlServers.ResumeLayout(false);
            pnlTop.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private SplitContainer splitContainerMain;
        private Label label2;
        private SearchControl searchControl1;
        private ProfileControl prflCtrlProfile;
        private ServerListControl serverControl1;
        private SearchControl searchControl2;
        private FlowLayoutPanel flowLayoutPanel2;
        private TextBox txtbxUsername;
        private Label lblPort;
        private TextBox tbxPort;
        private SearchControl srchCtrlSearch;
        private Label lblConversations;
        private Panel pnlTop;
        private Panel pnlLabelConversations;
        private RoundButtonControl roundButtonControl1;
        private FlowLayoutPanel flwLytPnlServers;
        private SearchControl searchControl3;
        private RoundButtonControl btnSettings;
        private ProfileControl profileControl1;
        private Panel pnlServers;
        private Panel pnlLeft;
        private Label label1;
        private Label lblWelcome;
        private Label lblProceed;
        private CircularPictureBox picAvatar;
        private Panel panel1;
        private Panel panel2;
    }
}