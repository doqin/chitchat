namespace Client
{
    partial class SplashScreen
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
            loadingAnimationControl1 = new LoadingAnimationControl();
            lblChitChat = new Label();
            SuspendLayout();
            // 
            // loadingAnimationControl1
            // 
            loadingAnimationControl1.BackColor = Color.Transparent;
            loadingAnimationControl1.BrushColor = Color.White;
            loadingAnimationControl1.DotHeight = 5;
            loadingAnimationControl1.DotPadding = 5;
            loadingAnimationControl1.DotWidth = 5;
            loadingAnimationControl1.Location = new Point(82, 310);
            loadingAnimationControl1.Name = "loadingAnimationControl1";
            loadingAnimationControl1.Size = new Size(38, 12);
            loadingAnimationControl1.TabIndex = 0;
            loadingAnimationControl1.TickRate = 4E-07D;
            // 
            // lblChitChat
            // 
            lblChitChat.AutoSize = true;
            lblChitChat.BackColor = Color.Transparent;
            lblChitChat.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChitChat.ForeColor = Color.White;
            lblChitChat.Location = new Point(12, 305);
            lblChitChat.Name = "lblChitChat";
            lblChitChat.Size = new Size(72, 21);
            lblChitChat.TabIndex = 1;
            lblChitChat.Text = "ChitChat";
            // 
            // SplashScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(700, 338);
            Controls.Add(lblChitChat);
            Controls.Add(loadingAnimationControl1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "SplashScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            TopMost = true;
            Load += SplashScreen_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LoadingAnimationControl loadingAnimationControl1;
        private Label lblChitChat;
    }
}