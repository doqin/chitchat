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
            pnlInfo = new Panel();
            lblStatus = new Label();
            lblUser = new Label();
            pnlProfilePicture = new Panel();
            crclrPctrBxProfile = new CircularPictureBox();
            roundControl1.SuspendLayout();
            pnlInfo.SuspendLayout();
            pnlProfilePicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)crclrPctrBxProfile).BeginInit();
            SuspendLayout();
            // 
            // roundControl1
            // 
            roundControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roundControl1.BackColor = Color.Transparent;
            roundControl1.BackgroundColor = Color.FromArgb(34, 44, 84);
            roundControl1.BorderColor = SystemColors.Control;
            roundControl1.BorderWidth = 1F;
            roundControl1.Controls.Add(pnlInfo);
            roundControl1.Controls.Add(pnlProfilePicture);
            roundControl1.Location = new Point(3, 2);
            roundControl1.Margin = new Padding(3, 2, 3, 2);
            roundControl1.Name = "roundControl1";
            roundControl1.Radius = 10;
            roundControl1.Size = new Size(250, 61);
            roundControl1.TabIndex = 0;
            // 
            // pnlInfo
            // 
            pnlInfo.Controls.Add(lblStatus);
            pnlInfo.Controls.Add(lblUser);
            pnlInfo.Dock = DockStyle.Fill;
            pnlInfo.Location = new Point(59, 0);
            pnlInfo.Name = "pnlInfo";
            pnlInfo.Size = new Size(191, 61);
            pnlInfo.TabIndex = 5;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblStatus.AutoEllipsis = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = SystemColors.ControlDark;
            lblStatus.Location = new Point(1, 31);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(100, 17);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "status";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUser
            // 
            lblUser.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblUser.AutoEllipsis = true;
            lblUser.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUser.ForeColor = SystemColors.Control;
            lblUser.Location = new Point(0, 8);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(172, 31);
            lblUser.TabIndex = 2;
            lblUser.Text = "username";
            lblUser.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlProfilePicture
            // 
            pnlProfilePicture.Controls.Add(crclrPctrBxProfile);
            pnlProfilePicture.Dock = DockStyle.Left;
            pnlProfilePicture.Location = new Point(0, 0);
            pnlProfilePicture.Name = "pnlProfilePicture";
            pnlProfilePicture.Padding = new Padding(10);
            pnlProfilePicture.Size = new Size(59, 61);
            pnlProfilePicture.TabIndex = 4;
            // 
            // crclrPctrBxProfile
            // 
            crclrPctrBxProfile.Dock = DockStyle.Fill;
            crclrPctrBxProfile.DrawOutline = true;
            crclrPctrBxProfile.Location = new Point(10, 10);
            crclrPctrBxProfile.Name = "crclrPctrBxProfile";
            crclrPctrBxProfile.OutlineColor = Color.White;
            crclrPctrBxProfile.OutlineWidth = 2F;
            crclrPctrBxProfile.Size = new Size(41, 41);
            crclrPctrBxProfile.SizeMode = PictureBoxSizeMode.Zoom;
            crclrPctrBxProfile.TabIndex = 0;
            crclrPctrBxProfile.TabStop = false;
            // 
            // ProfileControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(roundControl1);
            Margin = new Padding(2);
            Name = "ProfileControl";
            Size = new Size(256, 65);
            Load += ProfileControl_Load;
            Resize += ProfileControl_Resize;
            roundControl1.ResumeLayout(false);
            pnlInfo.ResumeLayout(false);
            pnlProfilePicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)crclrPctrBxProfile).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private RoundControl roundControl1;
        private CircularPictureBox crclrPctrBxProfile;
        private Label lblStatus;
        public Label lblUser;
        private Panel pnlInfo;
        private Panel pnlProfilePicture;
    }
}
