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
            flwLytPnlServers = new FlowLayoutPanel();
            label1 = new Label();
            pnlTop = new Panel();
            searchControl3 = new SearchControl();
            roundButtonControl2 = new RoundButtonControl();
            pnlProfileControl = new Panel();
            profileControl1 = new ProfileControl();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.SuspendLayout();
            pnlTop.SuspendLayout();
            pnlProfileControl.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainerMain
            // 
            splitContainerMain.BackColor = Color.FromArgb(28, 39, 74);
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
            splitContainerMain.Panel1.BackColor = Color.FromArgb(30, 30, 30);
            splitContainerMain.Panel1.Controls.Add(flwLytPnlServers);
            splitContainerMain.Panel1.Controls.Add(label1);
            splitContainerMain.Panel1.Controls.Add(pnlTop);
            splitContainerMain.Panel1.Controls.Add(pnlProfileControl);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.AutoScroll = true;
            splitContainerMain.Panel2.BackColor = Color.FromArgb(38, 38, 38);
            splitContainerMain.Panel2.Paint += splitContainerMain_Panel2_Paint;
            splitContainerMain.Size = new Size(1023, 611);
            splitContainerMain.SplitterDistance = 279;
            splitContainerMain.SplitterWidth = 2;
            splitContainerMain.TabIndex = 5;
            // 
            // flwLytPnlServers
            // 
            flwLytPnlServers.AutoScroll = true;
            flwLytPnlServers.BackColor = Color.FromArgb(20, 20, 20);
            flwLytPnlServers.Dock = DockStyle.Fill;
            flwLytPnlServers.FlowDirection = FlowDirection.TopDown;
            flwLytPnlServers.Location = new Point(0, 71);
            flwLytPnlServers.Name = "flwLytPnlServers";
            flwLytPnlServers.Size = new Size(279, 467);
            flwLytPnlServers.TabIndex = 0;
            flwLytPnlServers.WrapContents = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(0, 46);
            label1.Name = "label1";
            label1.Padding = new Padding(5);
            label1.Size = new Size(86, 25);
            label1.TabIndex = 2;
            label1.Text = "Các máy chủ";
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(searchControl3);
            pnlTop.Controls.Add(roundButtonControl2);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new Padding(5);
            pnlTop.Size = new Size(279, 46);
            pnlTop.TabIndex = 3;
            // 
            // searchControl3
            // 
            searchControl3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            searchControl3.BackColor = Color.Transparent;
            searchControl3.BackgroundColor = Color.FromArgb(30, 30, 30);
            searchControl3.BorderColor = SystemColors.Control;
            searchControl3.Dock = DockStyle.Fill;
            searchControl3.ForeColor = Color.FromArgb(30, 30, 30);
            searchControl3.IconPadding = new Padding(5);
            searchControl3.IconWidth = 40;
            searchControl3.Location = new Point(5, 5);
            searchControl3.Margin = new Padding(1);
            searchControl3.Name = "searchControl3";
            searchControl3.Size = new Size(232, 36);
            searchControl3.TabIndex = 0;
            // 
            // roundButtonControl2
            // 
            roundButtonControl2.BackColor = Color.Transparent;
            roundButtonControl2.BackgroundColor = Color.FromArgb(30, 30, 30);
            roundButtonControl2.BorderColor = SystemColors.Control;
            roundButtonControl2.BorderWidth = 1F;
            roundButtonControl2.ButtonBackgroundImage = Properties.Resources.rotate;
            roundButtonControl2.ButtonBackgroundImageLayout = ImageLayout.Zoom;
            roundButtonControl2.ButtonPadding = new Padding(5);
            roundButtonControl2.ButtonText = "";
            roundButtonControl2.ButtonTextColor = Color.Black;
            roundButtonControl2.Dock = DockStyle.Right;
            roundButtonControl2.Location = new Point(237, 5);
            roundButtonControl2.Margin = new Padding(1);
            roundButtonControl2.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            roundButtonControl2.Name = "roundButtonControl2";
            roundButtonControl2.Radius = 10;
            roundButtonControl2.Size = new Size(37, 36);
            roundButtonControl2.TabIndex = 1;
            roundButtonControl2.UseMouseOverBackColor = true;
            roundButtonControl2.Click += roundButtonControl1_Click;
            // 
            // pnlProfileControl
            // 
            pnlProfileControl.Controls.Add(profileControl1);
            pnlProfileControl.Dock = DockStyle.Bottom;
            pnlProfileControl.Location = new Point(0, 538);
            pnlProfileControl.Name = "pnlProfileControl";
            pnlProfileControl.Padding = new Padding(5);
            pnlProfileControl.Size = new Size(279, 73);
            pnlProfileControl.TabIndex = 0;
            // 
            // profileControl1
            // 
            profileControl1.BackColor = Color.Transparent;
            profileControl1.BackgroundColor = Color.FromArgb(30, 30, 30);
            profileControl1.BorderColor = SystemColors.Control;
            profileControl1.Dock = DockStyle.Fill;
            profileControl1.Location = new Point(5, 5);
            profileControl1.Margin = new Padding(2);
            profileControl1.Name = "profileControl1";
            profileControl1.ProfilePicturePadding = new Padding(10);
            profileControl1.Size = new Size(269, 63);
            profileControl1.TabIndex = 0;
            // 
            // label2
            // 
            label2.Font = new Font("Sans Serif Collection", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
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
            ClientSize = new Size(1023, 611);
            Controls.Add(splitContainerMain);
            ForeColor = Color.Black;
            MaximizeBox = false;
            Name = "ServerDiscoveryForm";
            Text = "Tìm máy chủ";
            FormClosed += ServerDiscoveryForm_FormClosed;
            Load += ServerDiscoveryForm_Load;
            KeyDown += ServerDiscoveryForm_KeyDown;
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            pnlTop.ResumeLayout(false);
            pnlProfileControl.ResumeLayout(false);
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
        private Label label1;
        private TextBox txtbxUsername;
        private Label lblPort;
        private TextBox tbxPort;
        private SearchControl srchCtrlSearch;
        private Label lblConversations;
        private Panel pnlTop;
        private Panel pnlLabelConversations;
        private Panel pnlProfileControl;
        private RoundButtonControl roundButtonControl1;
        private FlowLayoutPanel flwLytPnlServers;
        private SearchControl searchControl3;
        private RoundButtonControl roundButtonControl2;
        private ProfileControl profileControl1;
    }
}