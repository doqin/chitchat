namespace Client
{
    partial class OtherForm
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
            txtbxPort = new TextBox();
            lblPort = new Label();
            SuspendLayout();
            // 
            // txtbxPort
            // 
            txtbxPort.Location = new Point(61, 132);
            txtbxPort.Name = "txtbxPort";
            txtbxPort.Size = new Size(98, 23);
            txtbxPort.TabIndex = 0;
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblPort.ForeColor = SystemColors.ControlText;
            lblPort.Location = new Point(61, 91);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(37, 17);
            lblPort.TabIndex = 1;
            lblPort.Text = "Port:";
            // 
            // OtherForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 245, 243);
            ClientSize = new Size(657, 432);
            Controls.Add(lblPort);
            Controls.Add(txtbxPort);
            Name = "OtherForm";
            Text = "Khác";
            Load += OtherForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtbxPort;
        private Label lblPort;
    }
}