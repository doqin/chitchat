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
            txtPort = new TextBox();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            txtUsername = new TextBox();
            label1 = new Label();
            btnSubmit = new Button();
            gbLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.ForeColor = SystemColors.ControlLight;
            label2.Location = new Point(27, 71);
            label2.Name = "label2";
            label2.Size = new Size(103, 28);
            label2.TabIndex = 1;
            label2.Text = "Username:";
            // 
            // gbLogin
            // 
            gbLogin.Controls.Add(txtPort);
            gbLogin.Controls.Add(label3);
            gbLogin.Controls.Add(pictureBox1);
            gbLogin.Controls.Add(txtUsername);
            gbLogin.Controls.Add(label1);
            gbLogin.Controls.Add(label2);
            gbLogin.Font = new Font("Segoe UI", 15F);
            gbLogin.ForeColor = SystemColors.Control;
            gbLogin.Location = new Point(98, 45);
            gbLogin.Name = "gbLogin";
            gbLogin.Size = new Size(501, 280);
            gbLogin.TabIndex = 2;
            gbLogin.TabStop = false;
            gbLogin.Text = "Đăng nhập";
            // 
            // txtPort
            // 
            txtPort.Font = new Font("Segoe UI", 10F);
            txtPort.Location = new Point(184, 138);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(259, 34);
            txtPort.TabIndex = 6;
            txtPort.Text = "8080";
            txtPort.KeyDown += EnterPressed;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(27, 141);
            label3.Name = "label3";
            label3.Size = new Size(52, 28);
            label3.TabIndex = 5;
            label3.Text = "Port:";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(261, 213);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(182, 37);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(184, 71);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(259, 34);
            txtUsername.TabIndex = 3;
            txtUsername.KeyDown += EnterPressed;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = SystemColors.ControlLight;
            label1.Location = new Point(27, 214);
            label1.Name = "label1";
            label1.Size = new Size(166, 28);
            label1.TabIndex = 2;
            label1.Text = "Avatar (tùy chọn):";
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(282, 363);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(112, 34);
            btnSubmit.TabIndex = 7;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(53, 86, 109);
            ClientSize = new Size(701, 439);
            Controls.Add(btnSubmit);
            Controls.Add(gbLogin);
            Name = "LoginForm";
            Text = "Đăng nhập";
            gbLogin.ResumeLayout(false);
            gbLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label2;
        private GroupBox gbLogin;
        private Label label1;
        private PictureBox pictureBox1;
        private TextBox txtUsername;
        private TextBox txtPort;
        private Label label3;
        private Button btnSubmit;
    }
}