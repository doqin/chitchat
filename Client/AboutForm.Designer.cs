namespace Client
{
    partial class AboutForm
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
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(198, 199);
            label1.Name = "label1";
            label1.Size = new Size(291, 90);
            label1.TabIndex = 0;
            label1.Text = "Proudly made by 3 members from IT008.Q12.1\r\nNguyễn Tuấn Khang\r\nNguyễn Lê Đức Huy\r\nTrần Hữu Quốc Hướng\r\nAnd a special thanks to Copilot, ChatGPT and Gemini \r\nfor helping reviewing the codes.";
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 245, 243);
            ClientSize = new Size(710, 526);
            Controls.Add(label1);
            Name = "AboutForm";
            Text = "AboutForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
    }
}