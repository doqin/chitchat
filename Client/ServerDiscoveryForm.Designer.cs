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
            panelSearch = new FlowLayoutPanel();
            label2 = new Label();
            searchControl2 = new SearchControl();
            pnlProfileArea = new Panel();
            profileControl1 = new ProfileControl();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.SuspendLayout();
            panelSearch.SuspendLayout();
            pnlProfileArea.SuspendLayout();
            SuspendLayout();
            // 
            // btnDiscoverServer
            // 
            btnDiscoverServer.Location = new Point(64, 808);
            btnDiscoverServer.Margin = new Padding(4, 5, 4, 5);
            btnDiscoverServer.Name = "btnDiscoverServer";
            btnDiscoverServer.Size = new Size(219, 48);
            btnDiscoverServer.TabIndex = 2;
            btnDiscoverServer.Text = "Tìm kiếm máy chủ";
            btnDiscoverServer.UseVisualStyleBackColor = true;
            btnDiscoverServer.Click += btnDiscoverServer_Click;
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 0);
            splitContainerMain.Margin = new Padding(1, 2, 1, 2);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.AutoScroll = true;
            splitContainerMain.Panel1.BackColor = Color.FromArgb(28, 39, 74);
            splitContainerMain.Panel1.Controls.Add(lsbxServers);
            splitContainerMain.Panel1.Controls.Add(panelSearch);
            splitContainerMain.Panel1.Controls.Add(pnlProfileArea);
            splitContainerMain.Panel1.Controls.Add(btnDiscoverServer);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.AutoScroll = true;
            splitContainerMain.Panel2.BackColor = Color.FromArgb(26, 32, 62);
            splitContainerMain.Panel2.Paint += splitContainerMain_Panel2_Paint;
            splitContainerMain.Size = new Size(1709, 1000);
            splitContainerMain.SplitterDistance = 355;
            splitContainerMain.TabIndex = 5;
            // 
            // lsbxServers
            // 
            lsbxServers.FormattingEnabled = true;
            lsbxServers.ItemHeight = 25;
            lsbxServers.Location = new Point(27, 217);
            lsbxServers.Name = "lsbxServers";
            lsbxServers.Size = new Size(303, 479);
            lsbxServers.TabIndex = 6;
            lsbxServers.DoubleClick += lsbxServers_DoubleClick;
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.FromArgb(34, 44, 84);
            panelSearch.Controls.Add(label2);
            panelSearch.Controls.Add(searchControl2);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.FlowDirection = FlowDirection.TopDown;
            panelSearch.Location = new Point(0, 0);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(355, 192);
            panelSearch.TabIndex = 0;
            panelSearch.WrapContents = false;
            // 
            // label2
            // 
            label2.Font = new Font("Sans Serif Collection", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Gainsboro;
            label2.Location = new Point(3, 0);
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
            searchControl2.Location = new Point(3, 73);
            searchControl2.Name = "searchControl2";
            searchControl2.Size = new Size(320, 90);
            searchControl2.TabIndex = 2;
            // 
            // pnlProfileArea
            // 
            pnlProfileArea.BackColor = Color.Transparent;
            pnlProfileArea.Controls.Add(profileControl1);
            pnlProfileArea.Dock = DockStyle.Bottom;
            pnlProfileArea.Location = new Point(0, 887);
            pnlProfileArea.Name = "pnlProfileArea";
            pnlProfileArea.Size = new Size(355, 113);
            pnlProfileArea.TabIndex = 6;
            // 
            // profileControl1
            // 
            profileControl1.AutoSize = true;
            profileControl1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            profileControl1.BackColor = Color.Transparent;
            profileControl1.Dock = DockStyle.Bottom;
            profileControl1.Location = new Point(0, -8);
            profileControl1.Name = "profileControl1";
            profileControl1.Size = new Size(355, 121);
            profileControl1.TabIndex = 0;
            // 
            // ServerDiscoveryForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1709, 1000);
            Controls.Add(splitContainerMain);
            ForeColor = Color.Black;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "ServerDiscoveryForm";
            Text = "Tìm máy chủ";
            FormClosed += ServerDiscoveryForm_FormClosed;
            Load += ServerDiscoveryForm_Load;
            KeyDown += ServerDiscoveryForm_KeyDown;
            splitContainerMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            pnlProfileArea.ResumeLayout(false);
            pnlProfileArea.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnDiscoverServer;
        private SplitContainer splitContainerMain;
        private Panel pnlProfileArea;
        private FlowLayoutPanel panelSearch;
        private Label label2;
        private SearchControl searchControl1;
        private ListBox lsbxServers;
        private ProfileControl profileControl1;
        private ServerListControl serverControl1;
        private SearchControl searchControl2;
    }
}
