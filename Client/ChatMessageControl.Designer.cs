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
            flowPanelAttachments = new FlowLayoutPanel();
            rndCtrlChatBubble.SuspendLayout();
            flowPanelLayout.SuspendLayout();
            SuspendLayout();
            // 
            // rndCtrlChatBubble
            // 
            rndCtrlChatBubble.AutoSize = true;
            rndCtrlChatBubble.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            rndCtrlChatBubble.backgroundColor = SystemColors.MenuHighlight;
            rndCtrlChatBubble.BorderColor = SystemColors.Control;
            rndCtrlChatBubble.BorderWidth = 1F;
            rndCtrlChatBubble.Controls.Add(lblMessage);
            rndCtrlChatBubble.Controls.Add(lblUsername);
            rndCtrlChatBubble.Location = new Point(3, 2);
            rndCtrlChatBubble.Margin = new Padding(3, 2, 3, 2);
            rndCtrlChatBubble.Name = "rndCtrlChatBubble";
            rndCtrlChatBubble.Radius = 10;
            rndCtrlChatBubble.Size = new Size(87, 79);
            rndCtrlChatBubble.TabIndex = 0;
            rndCtrlChatBubble.Load += rndCtrlChatBubble_Load;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.ForeColor = Color.White;
            lblMessage.Location = new Point(10, 39);
            lblMessage.Name = "lblMessage";
            lblMessage.Padding = new Padding(5, 5, 10, 20);
            lblMessage.Size = new Size(68, 40);
            lblMessage.TabIndex = 2;
            lblMessage.Text = "message";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(10, 9);
            lblUsername.Name = "lblUsername";
            lblUsername.Padding = new Padding(5, 5, 10, 5);
            lblUsername.Size = new Size(74, 25);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "username";
            // 
            // lblTimestamp
            // 
            lblTimestamp.AutoSize = true;
            lblTimestamp.ForeColor = Color.White;
            lblTimestamp.Location = new Point(3, 87);
            lblTimestamp.Name = "lblTimestamp";
            lblTimestamp.Padding = new Padding(4, 0, 0, 0);
            lblTimestamp.Size = new Size(68, 15);
            lblTimestamp.TabIndex = 3;
            lblTimestamp.Text = "timestamp";
            // 
            // flowPanelLayout
            // 
            flowPanelLayout.AutoSize = true;
            flowPanelLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowPanelLayout.Controls.Add(rndCtrlChatBubble);
            flowPanelLayout.Controls.Add(flowPanelAttachments);
            flowPanelLayout.Controls.Add(lblTimestamp);
            flowPanelLayout.FlowDirection = FlowDirection.TopDown;
            flowPanelLayout.Location = new Point(3, 2);
            flowPanelLayout.Margin = new Padding(3, 2, 3, 2);
            flowPanelLayout.Name = "flowPanelLayout";
            flowPanelLayout.Size = new Size(93, 102);
            flowPanelLayout.TabIndex = 4;
            flowPanelLayout.WrapContents = false;
            // 
            // flowPanelAttachments
            // 
            flowPanelAttachments.AutoSize = true;
            flowPanelAttachments.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowPanelAttachments.Location = new Point(3, 85);
            flowPanelAttachments.Margin = new Padding(3, 2, 3, 2);
            flowPanelAttachments.Name = "flowPanelAttachments";
            flowPanelAttachments.Size = new Size(0, 0);
            flowPanelAttachments.TabIndex = 4;
            // 
            // ChatMessageControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(flowPanelLayout);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ChatMessageControl";
            Size = new Size(99, 106);
            rndCtrlChatBubble.ResumeLayout(false);
            rndCtrlChatBubble.PerformLayout();
            flowPanelLayout.ResumeLayout(false);
            flowPanelLayout.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RoundControl rndCtrlChatBubble;
        private Label lblUsername;
        private Label lblMessage;
        private Label lblTimestamp;
        private FlowLayoutPanel flowPanelLayout;
        private FlowLayoutPanel flowPanelAttachments;
    }
}
