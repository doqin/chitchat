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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerDiscoveryForm));
            tbxPort = new TextBox();
            lblPort = new Label();
            btnDiscoverServer = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label1 = new Label();
            txtbxUsername = new TextBox();
            lsbxServers = new ListBox();
            splitContainerMain = new SplitContainer();
            pictureBox1 = new PictureBox();
            flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tbxPort
            // 
            tbxPort.Location = new Point(3, 79);
            tbxPort.Margin = new Padding(3, 4, 3, 4);
            tbxPort.Name = "tbxPort";
            tbxPort.Size = new Size(173, 27);
            tbxPort.TabIndex = 0;
            tbxPort.Text = "9999";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.BackColor = Color.White;
            lblPort.Location = new Point(3, 55);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(35, 20);
            lblPort.TabIndex = 1;
            lblPort.Text = "Port";
            // 
            // btnDiscoverServer
            // 
            btnDiscoverServer.Location = new Point(3, 114);
            btnDiscoverServer.Margin = new Padding(3, 4, 3, 4);
            btnDiscoverServer.Name = "btnDiscoverServer";
            btnDiscoverServer.Size = new Size(174, 38);
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
            flowLayoutPanel2.Controls.Add(btnDiscoverServer);
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Location = new Point(37, 147);
            flowLayoutPanel2.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(182, 190);
            flowLayoutPanel2.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 4;
            label1.Text = "Username";
            // 
            // txtbxUsername
            // 
            txtbxUsername.Location = new Point(3, 24);
            txtbxUsername.Margin = new Padding(3, 4, 3, 4);
            txtbxUsername.Name = "txtbxUsername";
            txtbxUsername.Size = new Size(173, 27);
            txtbxUsername.TabIndex = 3;
            txtbxUsername.Text = "anonymous";
            // 
            // lsbxServers
            // 
            lsbxServers.FormattingEnabled = true;
            lsbxServers.Location = new Point(40, 363);
            lsbxServers.Margin = new Padding(3, 4, 3, 4);
            lsbxServers.Name = "lsbxServers";
            lsbxServers.Size = new Size(182, 384);
            lsbxServers.TabIndex = 4;
            lsbxServers.DoubleClick += lsbxServers_DoubleClick;
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 0);
            splitContainerMain.Margin = new Padding(2, 2, 2, 2);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.AutoScroll = true;
            splitContainerMain.Panel1.BackColor = Color.FromArgb(17, 7, 70);
            splitContainerMain.Panel1.Controls.Add(pictureBox1);
            splitContainerMain.Panel1.Controls.Add(lsbxServers);
            splitContainerMain.Panel1.Controls.Add(flowLayoutPanel2);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.AutoScroll = true;
            splitContainerMain.Panel2.BackColor = Color.DimGray;
            splitContainerMain.Panel2.Paint += splitContainerMain_Panel2_Paint;
            splitContainerMain.Size = new Size(1367, 800);
            splitContainerMain.SplitterDistance = 285;
            splitContainerMain.SplitterWidth = 3;
            splitContainerMain.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-2, 0);
            pictureBox1.Margin = new Padding(2, 2, 2, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(290, 112);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // ServerDiscoveryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1367, 800);
            Controls.Add(splitContainerMain);
            ForeColor = Color.Black;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ServerDiscoveryForm";
            Text = "Tìm máy chủ";
            Load += ServerDiscoveryForm_Load;
            KeyDown += ServerDiscoveryForm_KeyDown;
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            splitContainerMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private PictureBox pictureBox1;
    }
}
