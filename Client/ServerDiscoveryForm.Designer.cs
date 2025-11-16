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
            panel1 = new Panel();
            label2 = new Label();
            searchControl1 = new SearchControl();
            pnlProfileArea = new Panel();
            flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tbxPort
            // 
            tbxPort.Location = new Point(3, 62);
            tbxPort.Name = "tbxPort";
            tbxPort.Size = new Size(152, 23);
            tbxPort.TabIndex = 0;
            tbxPort.Text = "9999";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.BackColor = Color.White;
            lblPort.Location = new Point(3, 44);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(29, 15);
            lblPort.TabIndex = 1;
            lblPort.Text = "Port";
            // 
            // btnDiscoverServer
            // 
            btnDiscoverServer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnDiscoverServer.Location = new Point(12, 406);
            btnDiscoverServer.Name = "btnDiscoverServer";
            btnDiscoverServer.Size = new Size(258, 29);
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
            flowLayoutPanel2.Location = new Point(202, 110);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(160, 143);
            flowLayoutPanel2.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 4;
            label1.Text = "Username";
            // 
            // txtbxUsername
            // 
            txtbxUsername.Location = new Point(3, 18);
            txtbxUsername.Name = "txtbxUsername";
            txtbxUsername.Size = new Size(152, 23);
            txtbxUsername.TabIndex = 3;
            txtbxUsername.Text = "anonymous";
            // 
            // lsbxServers
            // 
            lsbxServers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lsbxServers.FormattingEnabled = true;
            lsbxServers.ItemHeight = 15;
            lsbxServers.Location = new Point(12, 136);
            lsbxServers.Name = "lsbxServers";
            lsbxServers.Size = new Size(258, 259);
            lsbxServers.TabIndex = 4;
            lsbxServers.DoubleClick += lsbxServers_DoubleClick;
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.FixedPanel = FixedPanel.Panel1;
            splitContainerMain.Location = new Point(0, 0);
            splitContainerMain.Margin = new Padding(1);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.AutoScroll = true;
            splitContainerMain.Panel1.BackColor = Color.SlateGray;
            splitContainerMain.Panel1.Controls.Add(panel1);
            splitContainerMain.Panel1.Controls.Add(lsbxServers);
            splitContainerMain.Panel1.Controls.Add(btnDiscoverServer);
            splitContainerMain.Panel1.Controls.Add(pnlProfileArea);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.AutoScroll = true;
            splitContainerMain.Panel2.BackColor = Color.DimGray;
            splitContainerMain.Panel2.Controls.Add(flowLayoutPanel2);
            splitContainerMain.Panel2.Paint += splitContainerMain_Panel2_Paint;
            splitContainerMain.Size = new Size(858, 513);
            splitContainerMain.SplitterDistance = 287;
            splitContainerMain.SplitterWidth = 3;
            splitContainerMain.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(searchControl1);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(281, 127);
            panel1.TabIndex = 7;
            // 
            // label2
            // 
            label2.Font = new Font("Sans Serif Collection", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Gainsboro;
            label2.Location = new Point(11, 0);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(164, 42);
            label2.TabIndex = 1;
            label2.Text = "Conversations";
            // 
            // searchControl1
            // 
            searchControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchControl1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            searchControl1.BackColor = Color.Transparent;
            searchControl1.Location = new Point(0, 43);
            searchControl1.Margin = new Padding(1);
            searchControl1.Name = "searchControl1";
            searchControl1.Size = new Size(280, 83);
            searchControl1.TabIndex = 0;
            // 
            // pnlProfileArea
            // 
            pnlProfileArea.BackColor = Color.Transparent;
            pnlProfileArea.Dock = DockStyle.Bottom;
            pnlProfileArea.Location = new Point(0, 445);
            pnlProfileArea.Margin = new Padding(2);
            pnlProfileArea.Name = "pnlProfileArea";
            pnlProfileArea.Size = new Size(287, 68);
            pnlProfileArea.TabIndex = 6;
            // 
            // ServerDiscoveryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 513);
            Controls.Add(splitContainerMain);
            ForeColor = Color.Black;
            MaximizeBox = false;
            Name = "ServerDiscoveryForm";
            Text = "Tìm máy chủ";
            FormClosed += ServerDiscoveryForm_FormClosed;
            Load += ServerDiscoveryForm_Load;
            KeyDown += ServerDiscoveryForm_KeyDown;
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            panel1.ResumeLayout(false);
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
        private SearchControl searchControl1;
        private Label label2;
        private Panel panel1;
    }
}
