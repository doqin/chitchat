namespace Client
{
    partial class ChatMessageControl
    {
        private MainButtonReaction btnMainEmoji;               // button đại diện
        private ReactionControl reactionControl1;  // control chứa các emoji
        private ReactionRowControl rctionRwCtrlRow; // control hiển thị reactions
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
            btnMainEmoji = new MainButtonReaction();
            reactionControl1 = new ReactionControl();
            lblTimestamp = new Label();
            flowPanelLayout = new FlowLayoutPanel();
            crclrPicBoxProfilePicture = new CircularPictureBox();
            flowPanelMessage = new FlowLayoutPanel();
            rctionRwCtrlRow = new ReactionRowControl();
            flowPanelAttachments = new FlowLayoutPanel();
            pnlReaction = new Panel();
            rndCtrlChatBubble.SuspendLayout();
            flowPanelLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)crclrPicBoxProfilePicture).BeginInit();
            flowPanelMessage.SuspendLayout();
            pnlReaction.SuspendLayout();
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
            rndCtrlChatBubble.MaximumSize = new Size(438, 0);
            rndCtrlChatBubble.Name = "rndCtrlChatBubble";
            rndCtrlChatBubble.Radius = 10;
            rndCtrlChatBubble.Size = new Size(96, 55);
            rndCtrlChatBubble.TabIndex = 0;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.ForeColor = Color.White;
            lblMessage.Location = new Point(0, 0);
            lblMessage.MaximumSize = new Size(500, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Padding = new Padding(20);
            lblMessage.Size = new Size(93, 55);
            lblMessage.TabIndex = 2;
            lblMessage.Text = "message";
            // 
            // btnMainEmoji
            // 
            btnMainEmoji.Location = new Point(8, 7);
            btnMainEmoji.Margin = new Padding(3, 2, 3, 2);
            btnMainEmoji.Name = "btnMainEmoji";
            btnMainEmoji.Size = new Size(44, 42);
            btnMainEmoji.TabIndex = 5;
            btnMainEmoji.Visible = false;
            btnMainEmoji.MainEmojiClick += btnMainEmoji_Click;
            btnMainEmoji.Click += btnMainEmoji_Click_1;
            // 
            // reactionControl1
            // 
            reactionControl1.AutoSize = true;
            reactionControl1.Location = new Point(229, 2);
            reactionControl1.Margin = new Padding(3, 2, 3, 2);
            reactionControl1.Name = "reactionControl1";
            reactionControl1.Size = new Size(133, 26);
            reactionControl1.TabIndex = 6;
            reactionControl1.Visible = false;
            reactionControl1.EmojiClicked += ReactionControl1_EmojiClicked;
            // 
            // lblTimestamp
            // 
            lblTimestamp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTimestamp.AutoSize = true;
            lblTimestamp.Font = new Font("Segoe UI", 7F);
            lblTimestamp.ForeColor = SystemColors.GrayText;
            lblTimestamp.Location = new Point(3, 67);
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
            flowPanelLayout.Controls.Add(pnlReaction);
            flowPanelLayout.Controls.Add(reactionControl1);
            flowPanelLayout.Location = new Point(0, 2);
            flowPanelLayout.Margin = new Padding(0);
            flowPanelLayout.Name = "flowPanelLayout";
            flowPanelLayout.Size = new Size(365, 85);
            flowPanelLayout.TabIndex = 4;
            flowPanelLayout.WrapContents = false;
            // 
            // crclrPicBoxProfilePicture
            // 
            crclrPicBoxProfilePicture.DrawOutline = true;
            crclrPicBoxProfilePicture.Location = new Point(3, 2);
            crclrPicBoxProfilePicture.Margin = new Padding(3, 2, 3, 2);
            crclrPicBoxProfilePicture.Name = "crclrPicBoxProfilePicture";
            crclrPicBoxProfilePicture.OutlineColor = Color.White;
            crclrPicBoxProfilePicture.OutlineWidth = 1F;
            crclrPicBoxProfilePicture.Size = new Size(45, 45);
            crclrPicBoxProfilePicture.TabIndex = 6;
            crclrPicBoxProfilePicture.TabStop = false;
            // 
            // flowPanelMessage
            // 
            flowPanelMessage.AutoSize = true;
            flowPanelMessage.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowPanelMessage.Controls.Add(rndCtrlChatBubble);
            flowPanelMessage.Controls.Add(rctionRwCtrlRow);
            flowPanelMessage.Controls.Add(flowPanelAttachments);
            flowPanelMessage.Controls.Add(lblTimestamp);
            flowPanelMessage.FlowDirection = FlowDirection.TopDown;
            flowPanelMessage.Location = new Point(54, 2);
            flowPanelMessage.Margin = new Padding(3, 2, 3, 2);
            flowPanelMessage.Name = "flowPanelMessage";
            flowPanelMessage.Size = new Size(102, 81);
            flowPanelMessage.TabIndex = 5;
            flowPanelMessage.WrapContents = false;
            // 
            // rctionRwCtrlRow
            // 
            rctionRwCtrlRow.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rctionRwCtrlRow.AutoSize = true;
            rctionRwCtrlRow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            rctionRwCtrlRow.Location = new Point(3, 61);
            rctionRwCtrlRow.Margin = new Padding(3, 2, 3, 2);
            rctionRwCtrlRow.Name = "rctionRwCtrlRow";
            rctionRwCtrlRow.Size = new Size(96, 0);
            rctionRwCtrlRow.TabIndex = 5;
            rctionRwCtrlRow.WrapContents = false;
            // 
            // flowPanelAttachments
            // 
            flowPanelAttachments.AutoSize = true;
            flowPanelAttachments.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowPanelAttachments.FlowDirection = FlowDirection.TopDown;
            flowPanelAttachments.Location = new Point(3, 65);
            flowPanelAttachments.Margin = new Padding(3, 2, 3, 2);
            flowPanelAttachments.Name = "flowPanelAttachments";
            flowPanelAttachments.Size = new Size(0, 0);
            flowPanelAttachments.TabIndex = 1;
            flowPanelAttachments.WrapContents = false;
            // 
            // pnlReaction
            // 
            pnlReaction.Controls.Add(btnMainEmoji);
            pnlReaction.Location = new Point(162, 3);
            pnlReaction.Name = "pnlReaction";
            pnlReaction.Size = new Size(61, 56);
            pnlReaction.TabIndex = 7;
            pnlReaction.MouseEnter += pnlReaction_MouseEnter;
            pnlReaction.MouseLeave += pnlReaction_MouseLeave;
            // 
            // ChatMessageControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(flowPanelLayout);
            DoubleBuffered = true;
            Margin = new Padding(3, 2, 3, 2);
            Name = "ChatMessageControl";
            Size = new Size(365, 87);
            Load += ChatMessageControl_Load;
            rndCtrlChatBubble.ResumeLayout(false);
            rndCtrlChatBubble.PerformLayout();
            flowPanelLayout.ResumeLayout(false);
            flowPanelLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)crclrPicBoxProfilePicture).EndInit();
            flowPanelMessage.ResumeLayout(false);
            flowPanelMessage.PerformLayout();
            pnlReaction.ResumeLayout(false);
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
        private Panel pnlReaction;
    }
}

