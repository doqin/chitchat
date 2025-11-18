namespace Client
{
    partial class ServerListControl
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
            pnlServer = new Panel();
            SuspendLayout();
            // 
            // pnlServer
            // 
            pnlServer.AutoScroll = true;
            pnlServer.BackColor = Color.FromArgb(50, 57, 61);
            pnlServer.Dock = DockStyle.Fill;
            pnlServer.Location = new Point(0, 0);
            pnlServer.Name = "pnlServer";
            pnlServer.Size = new Size(351, 530);
            pnlServer.TabIndex = 0;
            // 
            // ServerControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlServer);
            Name = "ServerControl";
            Size = new Size(351, 530);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlServer;
    }
}
