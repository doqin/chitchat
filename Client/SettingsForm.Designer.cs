namespace Client
{
    partial class SettingsForm
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
            splctnSettings = new SplitContainer();
            btnOther = new Button();
            btnUser = new Button();
            panel1 = new Panel();
            label1 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)splctnSettings).BeginInit();
            splctnSettings.Panel1.SuspendLayout();
            splctnSettings.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // splctnSettings
            // 
            splctnSettings.Dock = DockStyle.Fill;
            splctnSettings.Location = new Point(0, 0);
            splctnSettings.Name = "splctnSettings";
            // 
            // splctnSettings.Panel1
            // 
            splctnSettings.Panel1.BackColor = Color.Transparent;
            splctnSettings.Panel1.Controls.Add(button1);
            splctnSettings.Panel1.Controls.Add(btnOther);
            splctnSettings.Panel1.Controls.Add(btnUser);
            splctnSettings.Panel1.Controls.Add(panel1);
            // 
            // splctnSettings.Panel2
            // 
            splctnSettings.Panel2.BackColor = Color.Gainsboro;
            splctnSettings.Size = new Size(811, 542);
            splctnSettings.SplitterDistance = 246;
            splctnSettings.TabIndex = 0;
            // 
            // btnOther
            // 
            btnOther.Dock = DockStyle.Top;
            btnOther.FlatAppearance.BorderSize = 0;
            btnOther.FlatStyle = FlatStyle.Flat;
            btnOther.Font = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOther.Image = Properties.Resources.other1;
            btnOther.ImageAlign = ContentAlignment.TopLeft;
            btnOther.Location = new Point(0, 116);
            btnOther.Name = "btnOther";
            btnOther.Padding = new Padding(20, 0, 0, 0);
            btnOther.Size = new Size(246, 51);
            btnOther.TabIndex = 3;
            btnOther.Text = "  Khác";
            btnOther.TextAlign = ContentAlignment.MiddleRight;
            btnOther.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnOther.UseVisualStyleBackColor = false;
            btnOther.Click += btnOther_Click;
            btnOther.MouseHover += btnOther_MouseHover;
            // 
            // btnUser
            // 
            btnUser.Dock = DockStyle.Top;
            btnUser.FlatAppearance.BorderSize = 0;
            btnUser.FlatStyle = FlatStyle.Flat;
            btnUser.Font = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUser.Image = Properties.Resources.user1;
            btnUser.ImageAlign = ContentAlignment.MiddleLeft;
            btnUser.Location = new Point(0, 60);
            btnUser.Name = "btnUser";
            btnUser.Padding = new Padding(20, 0, 0, 0);
            btnUser.Size = new Size(246, 56);
            btnUser.TabIndex = 2;
            btnUser.Text = "  Cài đặt tài khoản";
            btnUser.TextAlign = ContentAlignment.MiddleRight;
            btnUser.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUser.UseVisualStyleBackColor = false;
            btnUser.Click += btnUser_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(246, 60);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(87, 21);
            label1.Name = "label1";
            label1.Size = new Size(62, 19);
            label1.TabIndex = 0;
            label1.Text = "Cài đặt";
            label1.TextAlign = ContentAlignment.BottomLeft;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Top;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Image = Properties.Resources.about;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(0, 167);
            button1.Name = "button1";
            button1.Padding = new Padding(20, 0, 0, 0);
            button1.Size = new Size(246, 51);
            button1.TabIndex = 4;
            button1.Text = "  About";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = false;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 245, 243);
            ClientSize = new Size(811, 542);
            Controls.Add(splctnSettings);
            Margin = new Padding(2);
            Name = "SettingsForm";
            Text = "SettingsForm";
            Load += SettingsForm_Load;
            splctnSettings.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splctnSettings).EndInit();
            splctnSettings.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splctnSettings;
        private Panel panel1;
        private Button btnUser;
        private Button btnOther;
        private Label label1;
        private Button button1;
    }
}