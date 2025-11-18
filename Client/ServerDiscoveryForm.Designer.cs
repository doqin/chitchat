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
            btnDiscoverServer = new Button();
            splitContainerMain = new SplitContainer();
            lsbxServers = new ListBox();
            searchControl3 = new SearchControl();
            label3 = new Label();
            profileControl1 = new ProfileControl();
            label2 = new Label();
            searchControl2 = new SearchControl();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.SuspendLayout();
            SuspendLayout();
            // 
            // btnDiscoverServer
            // 
            btnDiscoverServer.Dock = DockStyle.Bottom;
            btnDiscoverServer.Location = new Point(0, 413);
            btnDiscoverServer.Margin = new Padding(2);
            btnDiscoverServer.Name = "btnDiscoverServer";
            btnDiscoverServer.Size = new Size(245, 29);
            btnDiscoverServer.TabIndex = 2;
            btnDiscoverServer.Text = "Tìm kiếm máy chủ";
            btnDiscoverServer.UseVisualStyleBackColor = true;
            btnDiscoverServer.Click += btnDiscoverServer_Click;
            // 
            // splitContainerMain
            // 
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
            splitContainerMain.Panel1.BackColor = Color.FromArgb(28, 39, 74);
            splitContainerMain.Panel1.Controls.Add(lsbxServers);
            splitContainerMain.Panel1.Controls.Add(searchControl3);
            splitContainerMain.Panel1.Controls.Add(label3);
            splitContainerMain.Panel1.Controls.Add(btnDiscoverServer);
            splitContainerMain.Panel1.Controls.Add(profileControl1);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.AutoScroll = true;
            splitContainerMain.Panel2.BackColor = Color.FromArgb(26, 32, 62);
            splitContainerMain.Panel2.Paint += splitContainerMain_Panel2_Paint;
            splitContainerMain.Size = new Size(795, 544);
            splitContainerMain.SplitterDistance = 245;
            splitContainerMain.SplitterWidth = 2;
            splitContainerMain.TabIndex = 5;
            // 
            // lsbxServers
            // 
            lsbxServers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lsbxServers.FormattingEnabled = true;
            lsbxServers.ItemHeight = 15;
            lsbxServers.Location = new Point(11, 129);
            lsbxServers.Margin = new Padding(2);
            lsbxServers.Name = "lsbxServers";
            lsbxServers.Size = new Size(222, 274);
            lsbxServers.TabIndex = 6;
            lsbxServers.DoubleClick += lsbxServers_DoubleClick;
            // 
            // searchControl3
            // 
            searchControl3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            searchControl3.BackColor = Color.Transparent;
            searchControl3.Dock = DockStyle.Top;
            searchControl3.Location = new Point(0, 42);
            searchControl3.Margin = new Padding(1);
            searchControl3.Name = "searchControl3";
            searchControl3.Size = new Size(245, 82);
            searchControl3.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Symbol", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlLight;
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(5);
            label3.Size = new Size(174, 42);
            label3.TabIndex = 0;
            label3.Text = "Conversations";
            // 
            // profileControl1
            // 
            profileControl1.BackColor = Color.Transparent;
            profileControl1.Dock = DockStyle.Bottom;
            profileControl1.Location = new Point(0, 442);
            profileControl1.Margin = new Padding(1);
            profileControl1.Name = "profileControl1";
            profileControl1.Size = new Size(245, 102);
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
            // searchControl2
            // 
            searchControl2.AutoSize = true;
            searchControl2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            searchControl2.BackColor = Color.Transparent;
            searchControl2.BorderStyle = BorderStyle.Fixed3D;
            searchControl2.Location = new Point(2, 72);
            searchControl2.Margin = new Padding(2);
            searchControl2.Name = "searchControl2";
            searchControl2.Size = new Size(320, 87);
            searchControl2.TabIndex = 2;
            // 
            // ServerDiscoveryForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(795, 544);
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
            ResumeLayout(false);
        }

        #endregion
        private Button btnDiscoverServer;
        private SplitContainer splitContainerMain;
        private Label label2;
        private SearchControl searchControl1;
        private ListBox lsbxServers;
        private ProfileControl profileControl1;
        private ServerListControl serverControl1;
        private SearchControl searchControl2;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label1;
        private TextBox txtbxUsername;
        private Label lblPort;
        private TextBox tbxPort;
        private SearchControl searchControl3;
        private Label label3;
    }
}