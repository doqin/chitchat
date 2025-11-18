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
            lblTimestamp = new Label();
            flowPanelLayout = new FlowLayoutPanel();
            crclrPicBoxProfilePicture = new CircularPictureBox();
            flowPanelMessage = new FlowLayoutPanel();
            flowPanelAttachments = new FlowLayoutPanel();
            rndCtrlChatBubble.SuspendLayout();
            flowPanelLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)crclrPicBoxProfilePicture).BeginInit();
            flowPanelMessage.SuspendLayout();
            SuspendLayout();
            // 
            // rndCtrlChatBubble
            // 
            rndCtrlChatBubble.AutoSize = true;
            rndCtrlChatBubble.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            rndCtrlChatBubble.BackColor = Color.Transparent;
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
            // lblTimestamp
            // 
            lblTimestamp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTimestamp.AutoSize = true;
            lblTimestamp.Font = new Font("Segoe UI", 7F);
            lblTimestamp.ForeColor = Color.White;
            lblTimestamp.Location = new Point(3, 65);
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
            flowPanelLayout.Controls.Add(crclrPicBoxProfilePicture);
            flowPanelLayout.Controls.Add(flowPanelMessage);
            flowPanelLayout.Location = new Point(0, 2);
            flowPanelLayout.Margin = new Padding(0);
            flowPanelLayout.Name = "flowPanelLayout";
            flowPanelLayout.Size = new Size(174, 85);
            flowPanelLayout.TabIndex = 4;
            flowPanelLayout.WrapContents = false;
            // 
            // crclrPicBoxProfilePicture
            // 
            crclrPicBoxProfilePicture.Location = new Point(3, 3);
            crclrPicBoxProfilePicture.Name = "crclrPicBoxProfilePicture";
            crclrPicBoxProfilePicture.OutlineColor = Color.White;
            crclrPicBoxProfilePicture.OutlineWidth = 2F;
            crclrPicBoxProfilePicture.Size = new Size(60, 60);
            crclrPicBoxProfilePicture.TabIndex = 6;
            crclrPicBoxProfilePicture.TabStop = false;
            // 
            // flowPanelMessage
            // 
            flowPanelMessage.AutoSize = true;
            flowPanelMessage.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowPanelMessage.Controls.Add(rndCtrlChatBubble);
            flowPanelMessage.Controls.Add(flowPanelAttachments);
            flowPanelMessage.Controls.Add(lblTimestamp);
            flowPanelMessage.FlowDirection = FlowDirection.TopDown;
            flowPanelMessage.Location = new Point(69, 3);
            flowPanelMessage.Name = "flowPanelMessage";
            flowPanelMessage.Size = new Size(102, 79);
            flowPanelMessage.TabIndex = 5;
            flowPanelMessage.WrapContents = false;
            // 
            // flowPanelAttachments
            // 
            flowPanelAttachments.AutoSize = true;
            flowPanelAttachments.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowPanelAttachments.FlowDirection = FlowDirection.TopDown;
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
            Controls.Add(flowPanelLayout);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ChatMessageControl";
            Size = new Size(174, 87);
            rndCtrlChatBubble.ResumeLayout(false);
            rndCtrlChatBubble.PerformLayout();
            flowPanelLayout.ResumeLayout(false);
            flowPanelLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)crclrPicBoxProfilePicture).EndInit();
            flowPanelMessage.ResumeLayout(false);
            flowPanelMessage.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RoundControl rndCtrlChatBubble;
        private Label lblMessage;
        private Label lblTimestamp;
        private FlowLayoutPanel flowPanelMessage;
        private FlowLayoutPanel flowPanelAttachments;
        private CircularPictureBox crclrPicBoxProfilePicture;
        public FlowLayoutPanel flowPanelLayout;
    }
}
