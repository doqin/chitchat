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
            btnDiscoverServer.Location = new Point(4, 137);
            btnDiscoverServer.Margin = new Padding(4, 5, 4, 5);
            btnDiscoverServer.Name = "btnDiscoverServer";
            btnDiscoverServer.Size = new Size(217, 47);
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
            flowLayoutPanel2.Location = new Point(46, 184);
            flowLayoutPanel2.Margin = new Padding(4, 5, 4, 5);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(227, 237);
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
            lsbxServers.Location = new Point(50, 454);
            lsbxServers.Margin = new Padding(4, 5, 4, 5);
            lsbxServers.Name = "lsbxServers";
            lsbxServers.Size = new Size(227, 479);
            lsbxServers.TabIndex = 4;
            lsbxServers.DoubleClick += lsbxServers_DoubleClick;
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 0);
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
            splitContainerMain.Size = new Size(1709, 1000);
            splitContainerMain.SplitterDistance = 357;
            splitContainerMain.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-3, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(363, 140);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // ServerDiscoveryForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1709, 1000);
            Controls.Add(splitContainerMain);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
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
