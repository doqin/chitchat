namespace Client
{
    partial class AlertForm
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
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            ptrbxCloseButton = new PictureBox();
            panel3 = new Panel();
            ptrbxAlertType = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptrbxCloseButton).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptrbxAlertType).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoEllipsis = true;
            label1.Font = new Font("Segoe UI Light", 10F);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(0, 6);
            label1.MaximumSize = new Size(340, 70);
            label1.Name = "label1";
            label1.Size = new Size(252, 28);
            label1.TabIndex = 0;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            label1.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(79, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(259, 38);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // panel2
            // 
            panel2.Controls.Add(ptrbxCloseButton);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(337, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(70, 80);
            panel2.TabIndex = 2;
            panel2.Click += panel2_Click;
            panel2.Paint += panel2_Paint;
            panel2.MouseLeave += panel2_MouseLeave;
            panel2.MouseMove += panel2_MouseMove;
            // 
            // ptrbxCloseButton
            // 
            ptrbxCloseButton.Anchor = AnchorStyles.Left;
            ptrbxCloseButton.Image = Properties.Resources.close_button1;
            ptrbxCloseButton.InitialImage = Properties.Resources.close_button1;
            ptrbxCloseButton.Location = new Point(20, 26);
            ptrbxCloseButton.Name = "ptrbxCloseButton";
            ptrbxCloseButton.Size = new Size(30, 30);
            ptrbxCloseButton.SizeMode = PictureBoxSizeMode.StretchImage;
            ptrbxCloseButton.TabIndex = 0;
            ptrbxCloseButton.TabStop = false;
            ptrbxCloseButton.MouseClick += ptrbxCloseButton_MouseClick;
            ptrbxCloseButton.MouseMove += panel2_MouseMove;
            // 
            // panel3
            // 
            panel3.Controls.Add(ptrbxAlertType);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(81, 80);
            panel3.TabIndex = 3;
            // 
            // ptrbxAlertType
            // 
            ptrbxAlertType.Anchor = AnchorStyles.Left;
            ptrbxAlertType.Location = new Point(16, 15);
            ptrbxAlertType.Name = "ptrbxAlertType";
            ptrbxAlertType.Size = new Size(50, 50);
            ptrbxAlertType.SizeMode = PictureBoxSizeMode.StretchImage;
            ptrbxAlertType.TabIndex = 0;
            ptrbxAlertType.TabStop = false;
            // 
            // AlertForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DodgerBlue;
            ClientSize = new Size(407, 80);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AlertForm";
            Text = "\\";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptrbxCloseButton).EndInit();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptrbxAlertType).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private PictureBox ptrbxCloseButton;
        private PictureBox ptrbxAlertType;
    }
}