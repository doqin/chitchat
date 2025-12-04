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
            label2 = new Label();
            label1 = new Label();
            txtUsername = new TextBox();
            picAvatar = new CircularPictureBox();
            btnSubmit = new Button();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "Ảnh (*.jpg;*.jpeg;*.png;*.gif;*.ico)|*.jpg;*.jpeg;*.png;*.gif;*.ico|Tất cả các tệp (*.*)|*.*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(59, 205);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(74, 19);
            label2.TabIndex = 1;
            label2.Text = "Username:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(59, 287);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(118, 19);
            label1.TabIndex = 2;
            label1.Text = "Avatar (tùy chọn):";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(169, 202);
            txtUsername.Margin = new Padding(2);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(323, 25);
            txtUsername.TabIndex = 3;
            txtUsername.KeyDown += EnterPressed;
            // 
            // picAvatar
            // 
            picAvatar.DrawOutline = true;
            picAvatar.Location = new Point(252, 260);
            picAvatar.Name = "picAvatar";
            picAvatar.OutlineColor = Color.White;
            picAvatar.OutlineWidth = 2F;
            picAvatar.Size = new Size(80, 80);
            picAvatar.TabIndex = 7;
            picAvatar.TabStop = false;
            picAvatar.Click += circularPictureBox1_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.FlatAppearance.BorderColor = Color.Black;
            btnSubmit.FlatAppearance.MouseOverBackColor = Color.DimGray;
            btnSubmit.FlatStyle = FlatStyle.System;
            btnSubmit.ForeColor = SystemColors.ControlText;
            btnSubmit.Location = new Point(248, 375);
            btnSubmit.Margin = new Padding(2);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(92, 39);
            btnSubmit.TabIndex = 7;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(585, 658);
            Controls.Add(btnSubmit);
            Controls.Add(label1);
            Controls.Add(picAvatar);
            Controls.Add(txtUsername);
            Controls.Add(label2);
            Margin = new Padding(2);
            Name = "LoginForm";
            Text = "Đăng nhập";
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private OpenFileDialog openFileDialog1;
        private Label label2;
        private Label label1;
        private TextBox txtUsername;
        public CircularPictureBox picAvatar;
        private Button btnSubmit;
    }
}