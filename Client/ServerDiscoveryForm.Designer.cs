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
            panel5 = new Panel();
            lsbxServers = new ListBox();
            panel4 = new Panel();
            searchControl3 = new SearchControl();
            panel3 = new Panel();
            label3 = new Label();
            panel2 = new Panel();
            panel1 = new Panel();
            profileControl1 = new ProfileControl();
            label2 = new Label();
            searchControl2 = new SearchControl();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnDiscoverServer
            // 
            btnDiscoverServer.Dock = DockStyle.Fill;
            btnDiscoverServer.Location = new Point(7, 7);
            btnDiscoverServer.Margin = new Padding(2);
            btnDiscoverServer.Name = "btnDiscoverServer";
            btnDiscoverServer.Size = new Size(265, 35);
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
            splitContainerMain.Panel1.Controls.Add(panel5);
            splitContainerMain.Panel1.Controls.Add(panel4);
            splitContainerMain.Panel1.Controls.Add(panel3);
            splitContainerMain.Panel1.Controls.Add(panel2);
            splitContainerMain.Panel1.Controls.Add(panel1);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.AutoScroll = true;
            splitContainerMain.Panel2.BackColor = Color.FromArgb(26, 32, 62);
            splitContainerMain.Panel2.Paint += splitContainerMain_Panel2_Paint;
            splitContainerMain.Size = new Size(1023, 611);
            splitContainerMain.SplitterDistance = 279;
            splitContainerMain.SplitterWidth = 2;
            splitContainerMain.TabIndex = 5;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel5.Controls.Add(lsbxServers);
            panel5.Location = new Point(12, 145);
            panel5.Name = "panel5";
            panel5.Size = new Size(255, 311);
            panel5.TabIndex = 4;
            // 
            // lsbxServers
            // 
            lsbxServers.Dock = DockStyle.Fill;
            lsbxServers.FormattingEnabled = true;
            lsbxServers.ItemHeight = 15;
            lsbxServers.Location = new Point(0, 0);
            lsbxServers.Margin = new Padding(2);
            lsbxServers.Name = "lsbxServers";
            lsbxServers.Size = new Size(255, 311);
            lsbxServers.TabIndex = 6;
            lsbxServers.DoubleClick += lsbxServers_DoubleClick;
            // 
            // panel4
            // 
            panel4.Controls.Add(searchControl3);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 57);
            panel4.Name = "panel4";
            panel4.Size = new Size(279, 84);
            panel4.TabIndex = 3;
            // 
            // searchControl3
            // 
            searchControl3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            searchControl3.BackColor = Color.Transparent;
            searchControl3.Dock = DockStyle.Fill;
            searchControl3.Location = new Point(0, 0);
            searchControl3.Margin = new Padding(1);
            searchControl3.Name = "searchControl3";
            searchControl3.Size = new Size(279, 84);
            searchControl3.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(label3);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(279, 57);
            panel3.TabIndex = 2;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Symbol", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlLight;
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(5);
            label3.Size = new Size(279, 57);
            label3.TabIndex = 0;
            label3.Text = "Conversations";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnDiscoverServer);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 462);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(7);
            panel2.Size = new Size(279, 49);
            panel2.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(profileControl1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 511);
            panel1.Name = "panel1";
            panel1.Size = new Size(279, 100);
            panel1.TabIndex = 0;
            // 
            // profileControl1
            // 
            profileControl1.BackColor = Color.Transparent;
            profileControl1.Dock = DockStyle.Fill;
            profileControl1.Location = new Point(0, 0);
            profileControl1.Margin = new Padding(1);
            profileControl1.Name = "profileControl1";
            profileControl1.Size = new Size(279, 100);
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
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
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
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
    }
}