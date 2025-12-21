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
            panel3 = new Panel();
            label1 = new Label();
            rndBtnCtrlAddServer = new RoundButtonControl();
            pnlLeft = new Panel();
            panel2 = new Panel();
            btnSettings = new RoundButtonControl();
            panel1 = new Panel();
            picAvatar = new CircularPictureBox();
            lblProceed = new Label();
            lblWelcome = new Label();
            loadingAnimationControl1 = new LoadingAnimationControl();
            pnlBottom = new Panel();
            lblListening = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            pnlServers.SuspendLayout();
            pnlTop.SuspendLayout();
            panel3.SuspendLayout();
            pnlLeft.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            pnlBottom.SuspendLayout();
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
            splitContainerMain.Panel1.Controls.Add(panel3);
            splitContainerMain.Panel1.Controls.Add(pnlLeft);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.AutoScroll = true;
            splitContainerMain.Panel2.BackColor = SystemColors.Control;
            splitContainerMain.Panel2.Controls.Add(lblProceed);
            splitContainerMain.Panel2.Controls.Add(lblWelcome);
            splitContainerMain.Size = new Size(1509, 771);
            splitContainerMain.SplitterDistance = 486;
            splitContainerMain.SplitterWidth = 2;
            splitContainerMain.TabIndex = 5;
            splitContainerMain.Paint += splitContainerMain_Paint;
            // 
            // pnlServers
            // 
            pnlServers.Controls.Add(flwLytPnlServers);
            pnlServers.Dock = DockStyle.Fill;
            pnlServers.Location = new Point(78, 130);
            pnlServers.Margin = new Padding(4);
            pnlServers.Name = "pnlServers";
            pnlServers.Padding = new Padding(6);
            pnlServers.Size = new Size(408, 641);
            pnlServers.TabIndex = 4;
            // 
            // flwLytPnlServers
            // 
            flwLytPnlServers.AutoScroll = true;
            flwLytPnlServers.BackColor = Color.Transparent;
            flwLytPnlServers.Dock = DockStyle.Fill;
            flwLytPnlServers.FlowDirection = FlowDirection.TopDown;
            flwLytPnlServers.Location = new Point(6, 6);
            flwLytPnlServers.Margin = new Padding(4);
            flwLytPnlServers.Name = "flwLytPnlServers";
            flwLytPnlServers.Size = new Size(396, 629);
            flwLytPnlServers.TabIndex = 0;
            flwLytPnlServers.WrapContents = false;
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(searchControl1);
            pnlTop.Controls.Add(roundButtonControl1);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(78, 65);
            pnlTop.Margin = new Padding(4);
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new Padding(6);
            pnlTop.Size = new Size(408, 65);
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
            searchControl1.IconPadding = new Padding(9);
            searchControl1.IconWidth = 50;
            searchControl1.Location = new Point(6, 6);
            searchControl1.Margin = new Padding(1);
            searchControl1.Name = "searchControl1";
            searchControl1.Radius = 20;
            searchControl1.Size = new Size(344, 53);
            searchControl1.TabIndex = 0;
            // 
            // roundButtonControl1
            // 
            roundButtonControl1.ActiveBorderColor = SystemColors.ActiveBorder;
            roundButtonControl1.BackColor = Color.Transparent;
            roundButtonControl1.backgroundColor = SystemColors.Control;
            roundButtonControl1.BackgroundColor = SystemColors.Control;
            roundButtonControl1.BorderColor = SystemColors.InactiveBorder;
            roundButtonControl1.BorderWidth = 1F;
            roundButtonControl1.ButtonBackgroundImage = Properties.Resources.refresh;
            roundButtonControl1.ButtonBackgroundImageLayout = ImageLayout.Zoom;
            roundButtonControl1.ButtonPadding = new Padding(10);
            roundButtonControl1.ButtonText = "";
            roundButtonControl1.ButtonTextColor = Color.Black;
            roundButtonControl1.Dock = DockStyle.Right;
            roundButtonControl1.Location = new Point(350, 6);
            roundButtonControl1.Margin = new Padding(1);
            roundButtonControl1.MouseOverBackColor = SystemColors.ButtonHighlight;
            roundButtonControl1.Name = "roundButtonControl1";
            roundButtonControl1.Radius = 20;
            roundButtonControl1.Size = new Size(52, 53);
            roundButtonControl1.TabIndex = 1;
            roundButtonControl1.UseMouseOverBackColor = true;
            roundButtonControl1.Click += roundButtonControl1_Click;
            // 
            // panel3
            // 
            panel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel3.Controls.Add(label1);
            panel3.Controls.Add(rndBtnCtrlAddServer);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(78, 0);
            panel3.Margin = new Padding(4);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(6);
            panel3.Size = new Size(408, 65);
            panel3.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(113, 96, 232);
            label1.Location = new Point(14, 16);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(119, 31);
            label1.TabIndex = 1;
            label1.Text = "ChitChat";
            // 
            // rndBtnCtrlAddServer
            // 
            rndBtnCtrlAddServer.ActiveBorderColor = SystemColors.ActiveBorder;
            rndBtnCtrlAddServer.BackColor = Color.Transparent;
            rndBtnCtrlAddServer.backgroundColor = Color.White;
            rndBtnCtrlAddServer.BackgroundColor = Color.White;
            rndBtnCtrlAddServer.BorderColor = Color.White;
            rndBtnCtrlAddServer.BorderWidth = 1F;
            rndBtnCtrlAddServer.ButtonBackgroundImage = Properties.Resources.add_server;
            rndBtnCtrlAddServer.ButtonBackgroundImageLayout = ImageLayout.Zoom;
            rndBtnCtrlAddServer.ButtonPadding = new Padding(10);
            rndBtnCtrlAddServer.ButtonText = "";
            rndBtnCtrlAddServer.ButtonTextColor = Color.Black;
            rndBtnCtrlAddServer.Dock = DockStyle.Right;
            rndBtnCtrlAddServer.Location = new Point(350, 6);
            rndBtnCtrlAddServer.Margin = new Padding(1);
            rndBtnCtrlAddServer.MouseOverBackColor = SystemColors.Control;
            rndBtnCtrlAddServer.Name = "rndBtnCtrlAddServer";
            rndBtnCtrlAddServer.Radius = 999;
            rndBtnCtrlAddServer.Size = new Size(52, 53);
            rndBtnCtrlAddServer.TabIndex = 5;
            rndBtnCtrlAddServer.UseMouseOverBackColor = true;
            rndBtnCtrlAddServer.Click += rndBtnCtrlAddServer_Click;
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = SystemColors.Control;
            pnlLeft.Controls.Add(panel2);
            pnlLeft.Controls.Add(panel1);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.ForeColor = SystemColors.ActiveBorder;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Margin = new Padding(4);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(78, 771);
            pnlLeft.TabIndex = 1;
            pnlLeft.Paint += pnlLeft_Paint;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnSettings);
            panel2.Dock = DockStyle.Bottom;
            panel2.ForeColor = SystemColors.Control;
            panel2.Location = new Point(0, 617);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(6);
            panel2.Size = new Size(78, 78);
            panel2.TabIndex = 2;
            // 
            // btnSettings
            // 
            btnSettings.ActiveBorderColor = SystemColors.Control;
            btnSettings.BackColor = Color.Transparent;
            btnSettings.backgroundColor = SystemColors.Control;
            btnSettings.BackgroundColor = SystemColors.Control;
            btnSettings.BorderColor = SystemColors.Control;
            btnSettings.BorderWidth = 0F;
            btnSettings.ButtonBackgroundImage = Properties.Resources.settings;
            btnSettings.ButtonBackgroundImageLayout = ImageLayout.Zoom;
            btnSettings.ButtonPadding = new Padding(10);
            btnSettings.ButtonText = "";
            btnSettings.ButtonTextColor = SystemColors.ActiveBorder;
            btnSettings.Dock = DockStyle.Fill;
            btnSettings.Location = new Point(6, 6);
            btnSettings.Margin = new Padding(1);
            btnSettings.MouseOverBackColor = SystemColors.ButtonHighlight;
            btnSettings.Name = "btnSettings";
            btnSettings.Radius = 999;
            btnSettings.Size = new Size(66, 66);
            btnSettings.TabIndex = 1;
            btnSettings.UseMouseOverBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(picAvatar);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 695);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(12);
            panel1.Size = new Size(78, 76);
            panel1.TabIndex = 2;
            // 
            // picAvatar
            // 
            picAvatar.Dock = DockStyle.Fill;
            picAvatar.DrawOutline = true;
            picAvatar.Location = new Point(12, 12);
            picAvatar.Margin = new Padding(4);
            picAvatar.Name = "picAvatar";
            picAvatar.OutlineColor = Color.Gray;
            picAvatar.OutlineWidth = 2F;
            picAvatar.Size = new Size(52, 52);
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;
            // 
            // lblProceed
            // 
            lblProceed.Anchor = AnchorStyles.None;
            lblProceed.AutoSize = true;
            lblProceed.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProceed.Location = new Point(350, 379);
            lblProceed.Margin = new Padding(4, 0, 4, 0);
            lblProceed.Name = "lblProceed";
            lblProceed.Size = new Size(420, 23);
            lblProceed.TabIndex = 1;
            lblProceed.Text = "Kết nối đến một máy chủ LAN để bắt đầu trò chuyện.";
            // 
            // lblWelcome
            // 
            lblWelcome.Anchor = AnchorStyles.None;
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(313, 339);
            lblWelcome.Margin = new Padding(4, 0, 4, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(469, 41);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Chào mừng bạn đến với ChitChat!";
            // 
            // loadingAnimationControl1
            // 
            loadingAnimationControl1.BackColor = Color.Transparent;
            loadingAnimationControl1.BrushColor = Color.WhiteSmoke;
            loadingAnimationControl1.Dock = DockStyle.Left;
            loadingAnimationControl1.DotHeight = 4;
            loadingAnimationControl1.DotPadding = 3;
            loadingAnimationControl1.DotWidth = 4;
            loadingAnimationControl1.Location = new Point(5, 5);
            loadingAnimationControl1.Margin = new Padding(4, 5, 4, 5);
            loadingAnimationControl1.Name = "loadingAnimationControl1";
            loadingAnimationControl1.Size = new Size(35, 18);
            loadingAnimationControl1.TabIndex = 0;
            loadingAnimationControl1.TickRate = 4E-07D;
            loadingAnimationControl1.Visible = false;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.FromArgb(113, 96, 232);
            pnlBottom.Controls.Add(lblListening);
            pnlBottom.Controls.Add(loadingAnimationControl1);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 771);
            pnlBottom.Margin = new Padding(4);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(5);
            pnlBottom.Size = new Size(1509, 28);
            pnlBottom.TabIndex = 0;
            // 
            // lblListening
            // 
            lblListening.AutoSize = true;
            lblListening.Dock = DockStyle.Left;
            lblListening.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblListening.ForeColor = Color.White;
            lblListening.Location = new Point(40, 5);
            lblListening.Margin = new Padding(4, 0, 4, 0);
            lblListening.Name = "lblListening";
            lblListening.Size = new Size(162, 17);
            lblListening.TabIndex = 1;
            lblListening.Text = "Đang tìm kiếm máy chủ";
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
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1509, 799);
            Controls.Add(splitContainerMain);
            Controls.Add(pnlBottom);
            ForeColor = Color.Black;
            Margin = new Padding(4);
            Name = "ServerDiscoveryForm";
            Text = "ChitChat";
            FormClosed += ServerDiscoveryForm_FormClosed;
            Load += ServerDiscoveryForm_Load;
            KeyDown += ServerDiscoveryForm_KeyDown;
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            splitContainerMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            pnlServers.ResumeLayout(false);
            pnlTop.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            pnlLeft.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            pnlBottom.ResumeLayout(false);
            pnlBottom.PerformLayout();
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
        private Panel panel3;
        private RoundButtonControl rndBtnCtrlAddServer;
        private LoadingAnimationControl loadingAnimationControl1;
        private Panel pnlBottom;
        private Label lblListening;
    }
}