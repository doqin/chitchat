namespace Client
{
    partial class ChatForm
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
            openFileDialog1 = new OpenFileDialog();
            txtbxMessage = new TextBox();
            btnPickFiles = new Button();
            pnlChatPanel = new Panel();
            flwLytPnlMessages = new FlowLayoutPanel();
            flwLytPnlAttachments = new FlowLayoutPanel();
            pnlChatPanel.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Multiselect = true;
            // 
            // txtbxMessage
            // 
            txtbxMessage.BackColor = SystemColors.Window;
            txtbxMessage.BorderStyle = BorderStyle.None;
            txtbxMessage.Dock = DockStyle.Fill;
            txtbxMessage.Location = new Point(53, 0);
            txtbxMessage.Multiline = true;
            txtbxMessage.Name = "txtbxMessage";
            txtbxMessage.ScrollBars = ScrollBars.Vertical;
            txtbxMessage.Size = new Size(748, 49);
            txtbxMessage.TabIndex = 1;
            txtbxMessage.KeyDown += txtbxMessage_KeyDown;
            // 
            // btnPickFiles
            // 
            btnPickFiles.Dock = DockStyle.Left;
            btnPickFiles.Location = new Point(0, 0);
            btnPickFiles.Margin = new Padding(3, 2, 3, 2);
            btnPickFiles.Name = "btnPickFiles";
            btnPickFiles.Size = new Size(53, 49);
            btnPickFiles.TabIndex = 2;
            btnPickFiles.Text = "+";
            btnPickFiles.UseVisualStyleBackColor = true;
            btnPickFiles.Click += btnPickFiles_Click;
            // 
            // pnlChatPanel
            // 
            pnlChatPanel.BorderStyle = BorderStyle.FixedSingle;
            pnlChatPanel.Controls.Add(txtbxMessage);
            pnlChatPanel.Controls.Add(btnPickFiles);
            pnlChatPanel.Dock = DockStyle.Bottom;
            pnlChatPanel.Location = new Point(0, 428);
            pnlChatPanel.Name = "pnlChatPanel";
            pnlChatPanel.Size = new Size(803, 51);
            pnlChatPanel.TabIndex = 7;
            // 
            // flwLytPnlMessages
            // 
            flwLytPnlMessages.AutoScroll = true;
            flwLytPnlMessages.BorderStyle = BorderStyle.FixedSingle;
            flwLytPnlMessages.Dock = DockStyle.Fill;
            flwLytPnlMessages.FlowDirection = FlowDirection.TopDown;
            flwLytPnlMessages.Location = new Point(0, 0);
            flwLytPnlMessages.Name = "flwLytPnlMessages";
            flwLytPnlMessages.Size = new Size(803, 428);
            flwLytPnlMessages.TabIndex = 8;
            flwLytPnlMessages.WrapContents = false;
            flwLytPnlMessages.Scroll += flwLytPnlMessages_Scroll;
            flwLytPnlMessages.SizeChanged += flwLytPnlMessages_SizeChanged;
            flwLytPnlMessages.ControlAdded += flwLytPnlMessages_ControlAdded;
            flwLytPnlMessages.Paint += flwLytPnlMessages_Paint;
            // 
            // flwLytPnlAttachments
            // 
            flwLytPnlAttachments.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            flwLytPnlAttachments.AutoSize = true;
            flwLytPnlAttachments.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flwLytPnlAttachments.Location = new Point(16, 428);
            flwLytPnlAttachments.Name = "flwLytPnlAttachments";
            flwLytPnlAttachments.Size = new Size(0, 0);
            flwLytPnlAttachments.TabIndex = 9;
            flwLytPnlAttachments.WrapContents = false;
            flwLytPnlAttachments.Resize += flwLytPnlAttachments_Resize;
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(23, 21, 32);
            ClientSize = new Size(803, 479);
            Controls.Add(flwLytPnlAttachments);
            Controls.Add(flwLytPnlMessages);
            Controls.Add(pnlChatPanel);
            Name = "ChatForm";
            Text = "ChatForm";
            FormClosing += ChatForm_FormClosing;
            Load += ChatForm_Load;
            pnlChatPanel.ResumeLayout(false);
            pnlChatPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private TextBox txtbxMessage;
        private Button btnPickFiles;
        private Panel pnlChatPanel;
        private FlowLayoutPanel flwLytPnlMessages;
        private FlowLayoutPanel flwLytPnlAttachments;
    }
}