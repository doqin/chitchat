namespace Client
{
    partial class LoginForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            openFileDialog1 = new OpenFileDialog();
            lblUsername = new Label();
            lblAvatar = new Label();
            chatMessageControl1 = new ChatMessageControl();
            roundControl1 = new RoundControl();
            chatMessageControl3 = new ChatMessageControl();
            chatMessageControl2 = new ChatMessageControl();
            rndBtnCtrlChangeAvatar = new RoundButtonControl();
            lblPreview = new Label();
            rndTxtBxCtrlUsername = new RoundTextBoxControl();
            rndBtnCtrlSave = new RoundButtonControl();
            rndBtnCtrlRemoveAvatar = new RoundButtonControl();
            roundControl1.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "Ảnh (*.jpg;*.jpeg;*.png;*.gif;*.ico)|*.jpg;*.jpeg;*.png;*.gif;*.ico|Tất cả các tệp (*.*)|*.*";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = SystemColors.ControlText;
            lblUsername.Location = new Point(55, 45);
            lblUsername.Margin = new Padding(2, 0, 2, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(79, 17);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Tên hiển thị";
            // 
            // lblAvatar
            // 
            lblAvatar.AutoSize = true;
            lblAvatar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAvatar.ForeColor = SystemColors.ActiveCaptionText;
            lblAvatar.Location = new Point(55, 117);
            lblAvatar.Margin = new Padding(2, 0, 2, 0);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(48, 17);
            lblAvatar.TabIndex = 2;
            lblAvatar.Text = "Avatar";
            // 
            // chatMessageControl1
            // 
            chatMessageControl1.Anchor = AnchorStyles.Right;
            chatMessageControl1.AutoSize = true;
            chatMessageControl1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            chatMessageControl1.BackColor = Color.Transparent;
            chatMessageControl1.Location = new Point(133, 73);
            chatMessageControl1.Margin = new Padding(3, 2, 3, 2);
            chatMessageControl1.Name = "chatMessageControl1";
            chatMessageControl1.Size = new Size(159, 87);
            chatMessageControl1.TabIndex = 8;
            // 
            // roundControl1
            // 
            roundControl1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            roundControl1.BackColor = Color.Transparent;
            roundControl1.BackgroundColor = Color.FromArgb(241, 235, 227);
            roundControl1.BorderColor = SystemColors.ActiveBorder;
            roundControl1.BorderWidth = 1F;
            roundControl1.Controls.Add(chatMessageControl3);
            roundControl1.Controls.Add(chatMessageControl2);
            roundControl1.Controls.Add(chatMessageControl1);
            roundControl1.Location = new Point(331, 65);
            roundControl1.Margin = new Padding(1);
            roundControl1.Name = "roundControl1";
            roundControl1.Radius = 10;
            roundControl1.Size = new Size(312, 216);
            roundControl1.TabIndex = 9;
            // 
            // chatMessageControl3
            // 
            chatMessageControl3.Anchor = AnchorStyles.Right;
            chatMessageControl3.AutoSize = true;
            chatMessageControl3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            chatMessageControl3.BackColor = Color.Transparent;
            chatMessageControl3.Location = new Point(133, 165);
            chatMessageControl3.Margin = new Padding(3, 2, 3, 2);
            chatMessageControl3.Name = "chatMessageControl3";
            chatMessageControl3.Size = new Size(159, 87);
            chatMessageControl3.TabIndex = 10;
            // 
            // chatMessageControl2
            // 
            chatMessageControl2.Anchor = AnchorStyles.Right;
            chatMessageControl2.AutoSize = true;
            chatMessageControl2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            chatMessageControl2.BackColor = Color.Transparent;
            chatMessageControl2.Location = new Point(133, -19);
            chatMessageControl2.Margin = new Padding(3, 2, 3, 2);
            chatMessageControl2.Name = "chatMessageControl2";
            chatMessageControl2.Size = new Size(159, 87);
            chatMessageControl2.TabIndex = 9;
            // 
            // rndBtnCtrlChangeAvatar
            // 
            rndBtnCtrlChangeAvatar.ActiveBorderColor = SystemColors.ActiveBorder;
            rndBtnCtrlChangeAvatar.BackColor = Color.Transparent;
            rndBtnCtrlChangeAvatar.backgroundColor = Color.White;
            rndBtnCtrlChangeAvatar.BackgroundColor = Color.White;
            rndBtnCtrlChangeAvatar.BorderColor = SystemColors.ActiveBorder;
            rndBtnCtrlChangeAvatar.BorderWidth = 1F;
            rndBtnCtrlChangeAvatar.ButtonBackgroundImage = null;
            rndBtnCtrlChangeAvatar.ButtonBackgroundImageLayout = ImageLayout.Tile;
            rndBtnCtrlChangeAvatar.ButtonPadding = new Padding(0);
            rndBtnCtrlChangeAvatar.ButtonText = "Thay Avatar";
            rndBtnCtrlChangeAvatar.ButtonTextColor = SystemColors.ControlText;
            rndBtnCtrlChangeAvatar.Location = new Point(55, 137);
            rndBtnCtrlChangeAvatar.Margin = new Padding(1);
            rndBtnCtrlChangeAvatar.MouseOverBackColor = SystemColors.Control;
            rndBtnCtrlChangeAvatar.Name = "rndBtnCtrlChangeAvatar";
            rndBtnCtrlChangeAvatar.Radius = 10;
            rndBtnCtrlChangeAvatar.Size = new Size(109, 38);
            rndBtnCtrlChangeAvatar.TabIndex = 10;
            rndBtnCtrlChangeAvatar.UseMouseOverBackColor = true;
            rndBtnCtrlChangeAvatar.Click += rndBtnCtrlChangeAvatar_Click;
            // 
            // lblPreview
            // 
            lblPreview.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPreview.AutoSize = true;
            lblPreview.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPreview.ForeColor = SystemColors.ControlText;
            lblPreview.Location = new Point(331, 45);
            lblPreview.Margin = new Padding(2, 0, 2, 0);
            lblPreview.Name = "lblPreview";
            lblPreview.Size = new Size(55, 17);
            lblPreview.TabIndex = 11;
            lblPreview.Text = "Preview";
            // 
            // rndTxtBxCtrlUsername
            // 
            rndTxtBxCtrlUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rndTxtBxCtrlUsername.BackColor = Color.Transparent;
            rndTxtBxCtrlUsername.BackgroundColor = Color.White;
            rndTxtBxCtrlUsername.BorderColor = SystemColors.ActiveBorder;
            rndTxtBxCtrlUsername.BorderWidth = 1F;
            rndTxtBxCtrlUsername.Location = new Point(55, 65);
            rndTxtBxCtrlUsername.Margin = new Padding(1);
            rndTxtBxCtrlUsername.Name = "rndTxtBxCtrlUsername";
            rndTxtBxCtrlUsername.Radius = 10;
            rndTxtBxCtrlUsername.Size = new Size(229, 39);
            rndTxtBxCtrlUsername.TabIndex = 12;
            rndTxtBxCtrlUsername.TextBoxBackgroundColor = Color.White;
            // 
            // rndBtnCtrlSave
            // 
            rndBtnCtrlSave.ActiveBorderColor = SystemColors.ActiveBorder;
            rndBtnCtrlSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            rndBtnCtrlSave.BackColor = Color.Transparent;
            rndBtnCtrlSave.backgroundColor = Color.FromArgb(12, 192, 66);
            rndBtnCtrlSave.BackgroundColor = Color.FromArgb(12, 192, 66);
            rndBtnCtrlSave.BorderColor = SystemColors.ActiveBorder;
            rndBtnCtrlSave.BorderWidth = 2F;
            rndBtnCtrlSave.ButtonBackgroundImage = null;
            rndBtnCtrlSave.ButtonBackgroundImageLayout = ImageLayout.Tile;
            rndBtnCtrlSave.ButtonPadding = new Padding(0);
            rndBtnCtrlSave.ButtonText = "Lưu";
            rndBtnCtrlSave.ButtonTextColor = Color.FromArgb(239, 247, 242);
            rndBtnCtrlSave.Location = new Point(565, 328);
            rndBtnCtrlSave.Margin = new Padding(1);
            rndBtnCtrlSave.MouseOverBackColor = SystemColors.ControlDark;
            rndBtnCtrlSave.Name = "rndBtnCtrlSave";
            rndBtnCtrlSave.Radius = 10;
            rndBtnCtrlSave.Size = new Size(78, 38);
            rndBtnCtrlSave.TabIndex = 11;
            rndBtnCtrlSave.UseMouseOverBackColor = true;
            rndBtnCtrlSave.Click += btnSubmit_Click;
            // 
            // rndBtnCtrlRemoveAvatar
            // 
            rndBtnCtrlRemoveAvatar.ActiveBorderColor = SystemColors.ActiveBorder;
            rndBtnCtrlRemoveAvatar.BackColor = Color.Transparent;
            rndBtnCtrlRemoveAvatar.backgroundColor = Color.White;
            rndBtnCtrlRemoveAvatar.BackgroundColor = Color.White;
            rndBtnCtrlRemoveAvatar.BorderColor = SystemColors.ActiveBorder;
            rndBtnCtrlRemoveAvatar.BorderWidth = 1F;
            rndBtnCtrlRemoveAvatar.ButtonBackgroundImage = null;
            rndBtnCtrlRemoveAvatar.ButtonBackgroundImageLayout = ImageLayout.Tile;
            rndBtnCtrlRemoveAvatar.ButtonPadding = new Padding(0);
            rndBtnCtrlRemoveAvatar.ButtonText = "Gỡ bỏ Avatar";
            rndBtnCtrlRemoveAvatar.ButtonTextColor = SystemColors.ControlText;
            rndBtnCtrlRemoveAvatar.Location = new Point(175, 138);
            rndBtnCtrlRemoveAvatar.Margin = new Padding(1);
            rndBtnCtrlRemoveAvatar.MouseOverBackColor = SystemColors.Control;
            rndBtnCtrlRemoveAvatar.Name = "rndBtnCtrlRemoveAvatar";
            rndBtnCtrlRemoveAvatar.Radius = 10;
            rndBtnCtrlRemoveAvatar.Size = new Size(109, 38);
            rndBtnCtrlRemoveAvatar.TabIndex = 11;
            rndBtnCtrlRemoveAvatar.UseMouseOverBackColor = true;
            rndBtnCtrlRemoveAvatar.Click += rndBtnCtrlRemoveAvatar_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 245, 243);
            ClientSize = new Size(703, 415);
            ControlBox = false;
            Controls.Add(rndBtnCtrlRemoveAvatar);
            Controls.Add(rndBtnCtrlSave);
            Controls.Add(rndTxtBxCtrlUsername);
            Controls.Add(lblPreview);
            Controls.Add(rndBtnCtrlChangeAvatar);
            Controls.Add(roundControl1);
            Controls.Add(lblAvatar);
            Controls.Add(lblUsername);
            DoubleBuffered = true;
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "LoginForm";
            Text = "Đăng nhập";
            roundControl1.ResumeLayout(false);
            roundControl1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private OpenFileDialog openFileDialog1;
        private Label lblUsername;
        private Label lblAvatar;
        private ChatMessageControl chatMessageControl1;
        private RoundControl roundControl1;
        private ChatMessageControl chatMessageControl2;
        private ChatMessageControl chatMessageControl3;
        private RoundButtonControl rndBtnCtrlChangeAvatar;
        private Label lblPreview;
        private RoundTextBoxControl rndTxtBxCtrlUsername;
        private RoundButtonControl rndBtnCtrlSave;
        private RoundButtonControl rndBtnCtrlRemoveAvatar;
    }
}