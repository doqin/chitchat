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
            label1 = new Label();
            pnlLeft = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            lblProceed = new Label();
            lblWelcome = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            pnlServers.SuspendLayout();
            pnlLeft.SuspendLayout();
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
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(62, 46);
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new Padding(5);
            pnlTop.Size = new Size(327, 46);
            pnlTop.TabIndex = 3;
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
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 516);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(5);
            panel2.Size = new Size(62, 62);
            panel2.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 578);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(62, 61);
            panel1.TabIndex = 2;
            // 
            // lblProceed
            // 
            lblProceed.Anchor = AnchorStyles.None;
            lblProceed.AutoSize = true;
            lblProceed.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProceed.Location = new Point(307, 316);
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
            lblWelcome.Location = new Point(278, 284);
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
            pnlLeft.ResumeLayout(false);
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