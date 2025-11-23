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
            pnlChatPanel = new Panel();
            roundControl1 = new RoundControl();
            panel1 = new Panel();
            roundButtonControl1 = new RoundButtonControl();
            flwLytPnlAttachments = new FlowLayoutPanel();
            smthFlwLytPnlMessages = new SmoothFlowLayoutPanel();
            pnlChatPanel.SuspendLayout();
            roundControl1.SuspendLayout();
            panel1.SuspendLayout();
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
            txtbxMessage.Location = new Point(66, 19);
            txtbxMessage.Name = "txtbxMessage";
            txtbxMessage.PlaceholderText = "Message";
            txtbxMessage.Size = new Size(720, 16);
            txtbxMessage.TabIndex = 1;
            txtbxMessage.Click += txtbxMessage_Click;
            txtbxMessage.KeyDown += txtbxMessage_KeyDown;
            // 
            // pnlChatPanel
            // 
            pnlChatPanel.BackColor = Color.Transparent;
            pnlChatPanel.Controls.Add(roundControl1);
            pnlChatPanel.Dock = DockStyle.Bottom;
            pnlChatPanel.Location = new Point(0, 418);
            pnlChatPanel.Name = "pnlChatPanel";
            pnlChatPanel.Padding = new Padding(5);
            pnlChatPanel.Size = new Size(803, 61);
            pnlChatPanel.TabIndex = 7;
            // 
            // roundControl1
            // 
            roundControl1.BackColor = Color.Transparent;
            roundControl1.BackgroundColor = SystemColors.ButtonHighlight;
            roundControl1.BorderColor = SystemColors.InactiveBorder;
            roundControl1.BorderWidth = 1F;
            roundControl1.Controls.Add(txtbxMessage);
            roundControl1.Controls.Add(panel1);
            roundControl1.Dock = DockStyle.Fill;
            roundControl1.Location = new Point(5, 5);
            roundControl1.Margin = new Padding(1);
            roundControl1.Name = "roundControl1";
            roundControl1.Radius = 10;
            roundControl1.Size = new Size(793, 51);
            roundControl1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(roundButtonControl1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(52, 51);
            panel1.TabIndex = 1;
            // 
            // roundButtonControl1
            // 
            roundButtonControl1.ActiveBorderColor = SystemColors.ActiveBorder;
            roundButtonControl1.BackColor = Color.Transparent;
            roundButtonControl1.BackgroundColor = SystemColors.Control;
            roundButtonControl1.BorderColor = SystemColors.InactiveBorder;
            roundButtonControl1.BorderWidth = 1F;
            roundButtonControl1.ButtonBackgroundImage = Properties.Resources.plus;
            roundButtonControl1.ButtonBackgroundImageLayout = ImageLayout.None;
            roundButtonControl1.ButtonPadding = new Padding(10);
            roundButtonControl1.ButtonText = "";
            roundButtonControl1.ButtonTextColor = SystemColors.ControlText;
            roundButtonControl1.Dock = DockStyle.Fill;
            roundButtonControl1.Location = new Point(5, 5);
            roundButtonControl1.Margin = new Padding(1);
            roundButtonControl1.MouseOverBackColor = SystemColors.ButtonHighlight;
            roundButtonControl1.Name = "roundButtonControl1";
            roundButtonControl1.Radius = 10;
            roundButtonControl1.Size = new Size(42, 41);
            roundButtonControl1.TabIndex = 0;
            roundButtonControl1.UseMouseOverBackColor = true;
            roundButtonControl1.Click += roundButtonControl1_Click;
            // 
            // flwLytPnlAttachments
            // 
            flwLytPnlAttachments.AutoSize = true;
            flwLytPnlAttachments.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flwLytPnlAttachments.Dock = DockStyle.Bottom;
            flwLytPnlAttachments.Location = new Point(0, 418);
            flwLytPnlAttachments.Name = "flwLytPnlAttachments";
            flwLytPnlAttachments.Size = new Size(803, 0);
            flwLytPnlAttachments.TabIndex = 9;
            flwLytPnlAttachments.WrapContents = false;
            // 
            // smthFlwLytPnlMessages
            // 
            smthFlwLytPnlMessages.AutoScroll = true;
            smthFlwLytPnlMessages.BackColor = Color.Transparent;
            smthFlwLytPnlMessages.Dock = DockStyle.Fill;
            smthFlwLytPnlMessages.FlowDirection = FlowDirection.TopDown;
            smthFlwLytPnlMessages.Location = new Point(0, 0);
            smthFlwLytPnlMessages.Name = "smthFlwLytPnlMessages";
            smthFlwLytPnlMessages.ScrollSpeed = 10;
            smthFlwLytPnlMessages.Size = new Size(803, 418);
            smthFlwLytPnlMessages.TabIndex = 10;
            smthFlwLytPnlMessages.WrapContents = false;
            smthFlwLytPnlMessages.SizeChanged += smthFlwLytPnlMessages_SizeChanged;
            smthFlwLytPnlMessages.ControlAdded += smthFlwLytPnlMessages_ControlAdded;
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 245, 244);
            ClientSize = new Size(803, 479);
            Controls.Add(smthFlwLytPnlMessages);
            Controls.Add(flwLytPnlAttachments);
            Controls.Add(pnlChatPanel);
            Name = "ChatForm";
            Text = "ChatForm";
            FormClosing += ChatForm_FormClosing;
            Load += ChatForm_Load;
            Paint += ChatForm_Paint;
            pnlChatPanel.ResumeLayout(false);
            roundControl1.ResumeLayout(false);
            roundControl1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private TextBox txtbxMessage;
        private Panel pnlChatPanel;
        private FlowLayoutPanel flwLytPnlAttachments;
        private RoundControl roundControl1;
        private Panel panel1;
        private RoundButtonControl roundButtonControl1;
        private SmoothFlowLayoutPanel smthFlwLytPnlMessages;
    }
}