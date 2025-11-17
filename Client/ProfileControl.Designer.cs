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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileControl));
            roundControl1 = new RoundControl();
            btnLogin = new Button();
            lblStatus = new Label();
            lblUser = new Label();
            pictureBox1 = new PictureBox();
            roundControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // roundControl1
            // 
            roundControl1.backgroundColor = Color.FromArgb(34, 44, 84);
            roundControl1.BorderColor = SystemColors.Control;
            roundControl1.BorderWidth = 1F;
            roundControl1.Controls.Add(btnLogin);
            roundControl1.Controls.Add(lblStatus);
            roundControl1.Controls.Add(lblUser);
            roundControl1.Controls.Add(pictureBox1);
            roundControl1.Location = new Point(4, 4);
            roundControl1.Margin = new Padding(4, 4, 4, 4);
            roundControl1.Name = "roundControl1";
            roundControl1.Radius = 10;
            roundControl1.Size = new Size(345, 113);
            roundControl1.TabIndex = 0;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(117, 40);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(190, 34);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = SystemColors.Control;
            lblStatus.Location = new Point(108, 60);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(126, 25);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Status: status";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUser.ForeColor = SystemColors.Control;
            lblUser.Location = new Point(106, 23);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(190, 25);
            lblUser.TabIndex = 2;
            lblUser.Text = "Username: username";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(24, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(69, 64);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // ProfileControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(roundControl1);
            Name = "ProfileControl";
            Size = new Size(353, 121);
            roundControl1.ResumeLayout(false);
            roundControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private RoundControl roundControl1;
        private PictureBox pictureBox1;
        private Button btnLogin;
        private Label lblStatus;
        public Label lblUser;
    }
}
