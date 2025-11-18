namespace Client
{
    partial class ProfileControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            roundControl1 = new RoundControl();
            btnLogin = new Button();
            lblStatus = new Label();
            lblUser = new Label();
            pictureBox1 = new CircularPictureBox();
            roundControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // roundControl1
            // 
            roundControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roundControl1.BackColor = Color.Transparent;
            roundControl1.BackgroundColor = Color.FromArgb(34, 44, 84);
            roundControl1.BorderColor = SystemColors.Control;
            roundControl1.BorderWidth = 1F;
            roundControl1.Controls.Add(btnLogin);
            roundControl1.Controls.Add(lblStatus);
            roundControl1.Controls.Add(lblUser);
            roundControl1.Controls.Add(pictureBox1);
            roundControl1.Location = new Point(3, 2);
            roundControl1.Margin = new Padding(3, 2, 3, 2);
            roundControl1.Name = "roundControl1";
            roundControl1.Radius = 10;
            roundControl1.Size = new Size(248, 106);
            roundControl1.TabIndex = 0;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Right;
            btnLogin.Location = new Point(125, 41);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(79, 34);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Right;
            lblStatus.AutoEllipsis = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = SystemColors.Control;
            lblStatus.Location = new Point(101, 63);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(125, 16);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "status";
            // 
            // lblUser
            // 
            lblUser.Anchor = AnchorStyles.Right;
            lblUser.AutoEllipsis = true;
            lblUser.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUser.ForeColor = SystemColors.Control;
            lblUser.Location = new Point(101, 33);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(125, 15);
            lblUser.TabIndex = 2;
            lblUser.Text = "username";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Location = new Point(22, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.OutlineColor = Color.White;
            pictureBox1.OutlineWidth = 2F;
            pictureBox1.Size = new Size(71, 71);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // ProfileControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(roundControl1);
            Margin = new Padding(2);
            Name = "ProfileControl";
            Size = new Size(256, 110);
            roundControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private RoundControl roundControl1;
        private CircularPictureBox pictureBox1;
        private Button btnLogin;
        private Label lblStatus;
        public Label lblUser;
    }
}
