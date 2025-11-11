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
            tbxPort = new TextBox();
            lblPort = new Label();
            btnDiscoverServer = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label1 = new Label();
            txtbxUsername = new TextBox();
            lsbxServers = new ListBox();
            splitContainerMain = new SplitContainer();
            panelSearch = new FlowLayoutPanel();
            label2 = new Label();
            searchControl1 = new SearchControl();
            pnlProfileArea = new Panel();
            flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            panelSearch.SuspendLayout();
            SuspendLayout();
            // 
            // tbxPort
            // 
            tbxPort.Location = new Point(4, 96);
            tbxPort.Margin = new Padding(4, 5, 4, 5);
            tbxPort.Name = "tbxPort";
            tbxPort.Size = new Size(215, 31);
            tbxPort.TabIndex = 0;
            tbxPort.Text = "9999";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.BackColor = Color.White;
            lblPort.Location = new Point(4, 66);
            lblPort.Margin = new Padding(4, 0, 4, 0);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(44, 25);
            lblPort.TabIndex = 1;
            lblPort.Text = "Port";
            // 
            // btnDiscoverServer
            // 
            btnDiscoverServer.Location = new Point(64, 808);
            btnDiscoverServer.Margin = new Padding(4, 5, 4, 5);
            btnDiscoverServer.Name = "btnDiscoverServer";
            btnDiscoverServer.Size = new Size(218, 48);
            btnDiscoverServer.TabIndex = 2;
            btnDiscoverServer.Text = "Tìm kiếm máy chủ";
            btnDiscoverServer.UseVisualStyleBackColor = true;
            btnDiscoverServer.Click += btnDiscoverServer_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(label1);
            flowLayoutPanel2.Controls.Add(txtbxUsername);
            flowLayoutPanel2.Controls.Add(lblPort);
            flowLayoutPanel2.Controls.Add(tbxPort);
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Location = new Point(288, 183);
            flowLayoutPanel2.Margin = new Padding(4, 5, 4, 5);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(228, 238);
            flowLayoutPanel2.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Location = new Point(4, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(91, 25);
            label1.TabIndex = 4;
            label1.Text = "Username";
            // 
            // txtbxUsername
            // 
            txtbxUsername.Location = new Point(4, 30);
            txtbxUsername.Margin = new Padding(4, 5, 4, 5);
            txtbxUsername.Name = "txtbxUsername";
            txtbxUsername.Size = new Size(215, 31);
            txtbxUsername.TabIndex = 3;
            txtbxUsername.Text = "anonymous";
            // 
            // lsbxServers
            // 
            lsbxServers.FormattingEnabled = true;
            lsbxServers.ItemHeight = 25;
            lsbxServers.Location = new Point(31, 213);
            lsbxServers.Margin = new Padding(4, 5, 4, 5);
            lsbxServers.Name = "lsbxServers";
            lsbxServers.Size = new Size(293, 554);
            lsbxServers.TabIndex = 4;
            lsbxServers.DoubleClick += lsbxServers_DoubleClick;
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 0);
            splitContainerMain.Margin = new Padding(2);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.AutoScroll = true;
            splitContainerMain.Panel1.BackColor = Color.SlateGray;
            splitContainerMain.Panel1.Controls.Add(lsbxServers);
            splitContainerMain.Panel1.Controls.Add(panelSearch);
            splitContainerMain.Panel1.Controls.Add(pnlProfileArea);
            splitContainerMain.Panel1.Controls.Add(btnDiscoverServer);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.AutoScroll = true;
            splitContainerMain.Panel2.BackColor = Color.DimGray;
            splitContainerMain.Panel2.Controls.Add(flowLayoutPanel2);
            splitContainerMain.Panel2.Paint += splitContainerMain_Panel2_Paint;
            splitContainerMain.Size = new Size(1709, 1000);
            splitContainerMain.SplitterDistance = 356;
            splitContainerMain.TabIndex = 5;
            // 
            // panelSearch
            // 
            panelSearch.Controls.Add(label2);
            panelSearch.Controls.Add(searchControl1);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.FlowDirection = FlowDirection.TopDown;
            panelSearch.Location = new Point(0, 0);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(356, 191);
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
            // searchControl1
            // 
            searchControl1.AutoSize = true;
            searchControl1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            searchControl1.BackColor = Color.Transparent;
            searchControl1.Location = new Point(3, 73);
            searchControl1.Name = "searchControl1";
            searchControl1.Size = new Size(334, 95);
            searchControl1.TabIndex = 0;
            // 
            // pnlProfileArea
            // 
            pnlProfileArea.BackColor = Color.Transparent;
            pnlProfileArea.Dock = DockStyle.Bottom;
            pnlProfileArea.Location = new Point(0, 886);
            pnlProfileArea.Name = "pnlProfileArea";
            pnlProfileArea.Size = new Size(356, 114);
            pnlProfileArea.TabIndex = 6;
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
            Load += ServerDiscoveryForm_Load;
            KeyDown += ServerDiscoveryForm_KeyDown;
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox tbxPort;
        private Label lblPort;
        private Button btnDiscoverServer;
        private FlowLayoutPanel flowLayoutPanel2;
        private ListBox lsbxServers;
        private Label label1;
        private TextBox txtbxUsername;
        private SplitContainer splitContainerMain;
        private Panel pnlProfileArea;
        private FlowLayoutPanel panelSearch;
        private SearchControl searchControl1;
        private Label label2;
    }
}
