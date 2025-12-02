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
            components = new System.ComponentModel.Container();
            openFileDialog1 = new OpenFileDialog();
            txtbxMessage = new TextBox();
            pnlChatPanel = new Panel();
            btn_send = new Button();
            roundControl1 = new RoundControl();
            panel1 = new Panel();
            roundButtonControl1 = new RoundButtonControl();
            flwLytPnlAttachments = new FlowLayoutPanel();
            smthFlwLytPnlMessages = new SmoothFlowLayoutPanel();
            pnlTop = new Panel();
            lblUserInfo = new Label();
            tooltip_btn = new ToolTip(components);
            pnlChatPanel.SuspendLayout();
            roundControl1.SuspendLayout();
            panel1.SuspendLayout();
            pnlTop.SuspendLayout();
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
            txtbxMessage.Size = new Size(720, 20);
            txtbxMessage.TabIndex = 1;
            txtbxMessage.KeyDown += txtbxMessage_KeyDown;
            // 
            // pnlChatPanel
            // 
            pnlChatPanel.BackColor = Color.Transparent;
            pnlChatPanel.Controls.Add(btn_send);
            pnlChatPanel.Controls.Add(roundControl1);
            pnlChatPanel.Dock = DockStyle.Bottom;
            pnlChatPanel.Location = new Point(0, 558);
            pnlChatPanel.Margin = new Padding(3, 4, 3, 4);
            pnlChatPanel.Name = "pnlChatPanel";
            pnlChatPanel.Padding = new Padding(6, 7, 6, 7);
            pnlChatPanel.Size = new Size(918, 81);
            pnlChatPanel.TabIndex = 7;
            // 
            // btn_send
            // 
            btn_send.Dock = DockStyle.Right;
            btn_send.Location = new Point(842, 7);
            btn_send.Name = "btn_send";
            btn_send.Size = new Size(70, 67);
            btn_send.TabIndex = 2;
            btn_send.Text = "->";
            tooltip_btn.SetToolTip(btn_send, "Send Message");
            btn_send.UseVisualStyleBackColor = true;
            btn_send.Click += btn_send_Click;
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
            roundControl1.Location = new Point(6, 7);
            roundControl1.Margin = new Padding(1);
            roundControl1.Name = "roundControl1";
            roundControl1.Radius = 10;
            roundControl1.Size = new Size(906, 67);
            roundControl1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(roundButtonControl1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(52, 67);
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
            roundButtonControl1.Size = new Size(42, 57);
            roundButtonControl1.TabIndex = 0;
            tooltip_btn.SetToolTip(roundButtonControl1, "Add Attachment");
            roundButtonControl1.UseMouseOverBackColor = true;
            roundButtonControl1.Click += roundButtonControl1_Click;
            // 
            // flwLytPnlAttachments
            // 
            flwLytPnlAttachments.AutoSize = true;
            flwLytPnlAttachments.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flwLytPnlAttachments.Dock = DockStyle.Bottom;
            flwLytPnlAttachments.Location = new Point(0, 558);
            flwLytPnlAttachments.Margin = new Padding(3, 4, 3, 4);
            flwLytPnlAttachments.Name = "flwLytPnlAttachments";
            flwLytPnlAttachments.Size = new Size(918, 0);
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
            smthFlwLytPnlMessages.Margin = new Padding(3, 4, 3, 4);
            smthFlwLytPnlMessages.Name = "smthFlwLytPnlMessages";
            smthFlwLytPnlMessages.ScrollSpeed = 10;
            smthFlwLytPnlMessages.Size = new Size(918, 558);
            smthFlwLytPnlMessages.TabIndex = 10;
            smthFlwLytPnlMessages.WrapContents = false;
            smthFlwLytPnlMessages.SizeChanged += smthFlwLytPnlMessages_SizeChanged;
            smthFlwLytPnlMessages.ControlAdded += smthFlwLytPnlMessages_ControlAdded;
            // 
            // pnlTop
            // 
            pnlTop.BackColor = SystemColors.Window;
            pnlTop.Controls.Add(lblUserInfo);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Margin = new Padding(3, 4, 3, 4);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(918, 63);
            pnlTop.TabIndex = 0;
            // 
            // lblUserInfo
            // 
            lblUserInfo.AutoSize = true;
            lblUserInfo.Location = new Point(22, 21);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(50, 20);
            lblUserInfo.TabIndex = 0;
            lblUserInfo.Text = "label1";
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 245, 244);
            ClientSize = new Size(918, 639);
            Controls.Add(pnlTop);
            Controls.Add(smthFlwLytPnlMessages);
            Controls.Add(flwLytPnlAttachments);
            Controls.Add(pnlChatPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ChatForm";
            Text = "ChatForm";
            FormClosing += ChatForm_FormClosing;
            Load += ChatForm_Load;
            Paint += ChatForm_Paint;
            pnlChatPanel.ResumeLayout(false);
            roundControl1.ResumeLayout(false);
            roundControl1.PerformLayout();
            panel1.ResumeLayout(false);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
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
        private Panel pnlTop;
        private Label lblUserInfo;
        private Button btn_send;
        private ToolTip tooltip_btn;
    }
}