namespace Client
{
    partial class ChatMessageControl
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
            rndCtrlChatBubble = new RoundControl();
            lblMessage = new Label();
            lblUsername = new Label();
            lblTimestamp = new Label();
            flowPanelLayout = new FlowLayoutPanel();
            flowPanelMessage = new FlowLayoutPanel();
            flowPanelAttachments = new FlowLayoutPanel();
            rndCtrlChatBubble.SuspendLayout();
            flowPanelLayout.SuspendLayout();
            flowPanelMessage.SuspendLayout();
            SuspendLayout();
            // 
            // rndCtrlChatBubble
            // 
            rndCtrlChatBubble.AutoSize = true;
            rndCtrlChatBubble.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            rndCtrlChatBubble.BackgroundColor = SystemColors.MenuHighlight;
            rndCtrlChatBubble.BorderColor = SystemColors.Control;
            rndCtrlChatBubble.BorderWidth = 1F;
            rndCtrlChatBubble.Controls.Add(lblMessage);
            rndCtrlChatBubble.Location = new Point(3, 2);
            rndCtrlChatBubble.Margin = new Padding(3, 2, 3, 2);
            rndCtrlChatBubble.Name = "rndCtrlChatBubble";
            rndCtrlChatBubble.Radius = 10;
            rndCtrlChatBubble.Size = new Size(96, 55);
            rndCtrlChatBubble.TabIndex = 0;
            rndCtrlChatBubble.Load += rndCtrlChatBubble_Load;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.ForeColor = Color.White;
            lblMessage.Location = new Point(0, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Padding = new Padding(20);
            lblMessage.Size = new Size(93, 55);
            lblMessage.TabIndex = 2;
            lblMessage.Text = "message";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(3, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(59, 15);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "username";
            // 
            // lblTimestamp
            // 
            lblTimestamp.AutoSize = true;
            lblTimestamp.Font = new Font("Segoe UI", 7F);
            lblTimestamp.ForeColor = Color.White;
            lblTimestamp.Location = new Point(68, 0);
            lblTimestamp.Name = "lblTimestamp";
            lblTimestamp.Padding = new Padding(0, 2, 0, 0);
            lblTimestamp.Size = new Size(51, 14);
            lblTimestamp.TabIndex = 3;
            lblTimestamp.Text = "timestamp";
            // 
            // flowPanelLayout
            // 
            flowPanelLayout.AutoSize = true;
            flowPanelLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowPanelLayout.Controls.Add(lblUsername);
            flowPanelLayout.Controls.Add(lblTimestamp);
            flowPanelLayout.Location = new Point(0, 2);
            flowPanelLayout.Margin = new Padding(3, 2, 3, 2);
            flowPanelLayout.Name = "flowPanelLayout";
            flowPanelLayout.Size = new Size(122, 15);
            flowPanelLayout.TabIndex = 4;
            flowPanelLayout.WrapContents = false;
            // 
            // flowPanelMessage
            // 
            flowPanelMessage.AutoSize = true;
            flowPanelMessage.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowPanelMessage.Controls.Add(rndCtrlChatBubble);
            flowPanelMessage.Controls.Add(flowPanelAttachments);
            flowPanelMessage.FlowDirection = FlowDirection.TopDown;
            flowPanelMessage.Location = new Point(0, 20);
            flowPanelMessage.Name = "flowPanelMessage";
            flowPanelMessage.Size = new Size(102, 65);
            flowPanelMessage.TabIndex = 5;
            flowPanelMessage.WrapContents = false;
            // 
            // flowPanelAttachments
            // 
            flowPanelAttachments.AutoSize = true;
            flowPanelAttachments.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowPanelAttachments.Location = new Point(3, 62);
            flowPanelAttachments.Name = "flowPanelAttachments";
            flowPanelAttachments.Size = new Size(0, 0);
            flowPanelAttachments.TabIndex = 1;
            flowPanelAttachments.WrapContents = false;
            // 
            // ChatMessageControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(flowPanelMessage);
            Controls.Add(flowPanelLayout);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ChatMessageControl";
            Size = new Size(125, 88);
            rndCtrlChatBubble.ResumeLayout(false);
            rndCtrlChatBubble.PerformLayout();
            flowPanelLayout.ResumeLayout(false);
            flowPanelLayout.PerformLayout();
            flowPanelMessage.ResumeLayout(false);
            flowPanelMessage.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RoundControl rndCtrlChatBubble;
        private Label lblUsername;
        private Label lblMessage;
        private Label lblTimestamp;
        private FlowLayoutPanel flowPanelLayout;
        private FlowLayoutPanel flowPanelMessage;
        private FlowLayoutPanel flowPanelAttachments;
    }
}
