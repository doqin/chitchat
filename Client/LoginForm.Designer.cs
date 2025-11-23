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
            label2 = new Label();
            gbLogin = new GroupBox();
            btnSubmit = new Button();
            circularPictureBox1 = new CircularPictureBox();
            txtPort = new TextBox();
            label3 = new Label();
            txtUsername = new TextBox();
            label1 = new Label();
            openFileDialog1 = new OpenFileDialog();
            gbLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)circularPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.ForeColor = SystemColors.ControlLight;
            label2.Location = new Point(19, 43);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(74, 19);
            label2.TabIndex = 1;
            label2.Text = "Username:";
            // 
            // gbLogin
            // 
            gbLogin.Controls.Add(btnSubmit);
            gbLogin.Controls.Add(circularPictureBox1);
            gbLogin.Controls.Add(txtPort);
            gbLogin.Controls.Add(label3);
            gbLogin.Controls.Add(txtUsername);
            gbLogin.Controls.Add(label1);
            gbLogin.Controls.Add(label2);
            gbLogin.Font = new Font("Segoe UI", 15F);
            gbLogin.ForeColor = SystemColors.Control;
            gbLogin.Location = new Point(11, 11);
            gbLogin.Margin = new Padding(2);
            gbLogin.Name = "gbLogin";
            gbLogin.Padding = new Padding(2);
            gbLogin.Size = new Size(409, 252);
            gbLogin.TabIndex = 2;
            gbLogin.TabStop = false;
            gbLogin.Text = "Đăng nhập";
            // 
            // btnSubmit
            // 
            btnSubmit.ForeColor = SystemColors.ControlText;
            btnSubmit.Location = new Point(156, 204);
            btnSubmit.Margin = new Padding(2);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(92, 39);
            btnSubmit.TabIndex = 7;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // circularPictureBox1
            // 
            circularPictureBox1.DrawOutline = true;
            circularPictureBox1.Location = new Point(184, 113);
            circularPictureBox1.Name = "circularPictureBox1";
            circularPictureBox1.OutlineColor = Color.White;
            circularPictureBox1.OutlineWidth = 2F;
            circularPictureBox1.Size = new Size(80, 80);
            circularPictureBox1.TabIndex = 7;
            circularPictureBox1.TabStop = false;
            circularPictureBox1.Click += circularPictureBox1_Click;
            // 
            // txtPort
            // 
            txtPort.Font = new Font("Segoe UI", 10F);
            txtPort.Location = new Point(129, 83);
            txtPort.Margin = new Padding(2);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(182, 25);
            txtPort.TabIndex = 6;
            txtPort.Text = "9999";
            txtPort.KeyDown += EnterPressed;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(19, 85);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(37, 19);
            label3.TabIndex = 5;
            label3.Text = "Port:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(129, 43);
            txtUsername.Margin = new Padding(2);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(182, 25);
            txtUsername.TabIndex = 3;
            txtUsername.KeyDown += EnterPressed;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = SystemColors.ControlLight;
            label1.Location = new Point(19, 143);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(118, 19);
            label1.TabIndex = 2;
            label1.Text = "Avatar (tùy chọn):";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(53, 86, 109);
            ClientSize = new Size(431, 270);
            Controls.Add(gbLogin);
            Margin = new Padding(2);
            Name = "LoginForm";
            Text = "Đăng nhập";
            gbLogin.ResumeLayout(false);
            gbLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)circularPictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label2;
        private GroupBox gbLogin;
        private Label label1;
        private TextBox txtUsername;
        private TextBox txtPort;
        private Label label3;
        private Button btnSubmit;
        private OpenFileDialog openFileDialog1;
        public CircularPictureBox circularPictureBox1;
    }
}