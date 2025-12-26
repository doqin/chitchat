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
            rndCtrlChatbox = new RoundControl();
            pnlAddButton = new Panel();
            addfile_roundbutton = new RoundButtonControl();
            pnlSendButton = new Panel();
            send_roundbutton = new RoundButtonControl();
            flwLytPnlAttachments = new FlowLayoutPanel();
            smthFlwLytPnlMessages = new SmoothFlowLayoutPanel();
            pnlTop = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lblServer = new Label();
            flwLytPnlUsers = new FlowLayoutPanel();
            panel1 = new Panel();
            rndBtnCtrlClose = new RoundButtonControl();
            loadingAnimationControl1 = new LoadingAnimationControl();
            pnlChatPanel.SuspendLayout();
            rndCtrlChatbox.SuspendLayout();
            pnlAddButton.SuspendLayout();
            pnlSendButton.SuspendLayout();
            pnlTop.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
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
            txtbxMessage.PlaceholderText = "Gửi tin nhắn";
            txtbxMessage.Size = new Size(639, 16);
            txtbxMessage.TabIndex = 1;
            txtbxMessage.Click += txtbxMessage_Click;
            txtbxMessage.TextChanged += txtbxMessage_TextChanged;
            txtbxMessage.KeyDown += txtbxMessage_KeyDown;
            // 
            // pnlChatPanel
            // 
            pnlChatPanel.BackColor = Color.Transparent;
            pnlChatPanel.Controls.Add(rndCtrlChatbox);
            pnlChatPanel.Controls.Add(pnlSendButton);
            pnlChatPanel.Dock = DockStyle.Bottom;
            pnlChatPanel.Location = new Point(0, 408);
            pnlChatPanel.Name = "pnlChatPanel";
            pnlChatPanel.Padding = new Padding(10, 5, 10, 15);
            pnlChatPanel.Size = new Size(803, 71);
            pnlChatPanel.TabIndex = 7;
            // 
            // rndCtrlChatbox
            // 
            rndCtrlChatbox.BackColor = Color.Transparent;
            rndCtrlChatbox.BackgroundColor = SystemColors.ButtonHighlight;
            rndCtrlChatbox.BorderColor = SystemColors.InactiveBorder;
            rndCtrlChatbox.BorderWidth = 1F;
            rndCtrlChatbox.Controls.Add(txtbxMessage);
            rndCtrlChatbox.Controls.Add(pnlAddButton);
            rndCtrlChatbox.Dock = DockStyle.Fill;
            rndCtrlChatbox.Location = new Point(10, 5);
            rndCtrlChatbox.Margin = new Padding(1);
            rndCtrlChatbox.Name = "rndCtrlChatbox";
            rndCtrlChatbox.Radius = 20;
            rndCtrlChatbox.Size = new Size(722, 51);
            rndCtrlChatbox.TabIndex = 0;
            rndCtrlChatbox.Click += rndCtrlChatbox_Click;
            rndCtrlChatbox.MouseEnter += rndCtrlChatbox_MouseEnter;
            rndCtrlChatbox.MouseLeave += rndCtrlChatbox_MouseLeave;
            // 
            // pnlAddButton
            // 
            pnlAddButton.Controls.Add(addfile_roundbutton);
            pnlAddButton.Dock = DockStyle.Left;
            pnlAddButton.Location = new Point(0, 0);
            pnlAddButton.Name = "pnlAddButton";
            pnlAddButton.Padding = new Padding(5);
            pnlAddButton.Size = new Size(51, 51);
            pnlAddButton.TabIndex = 1;
            // 
            // addfile_roundbutton
            // 
            addfile_roundbutton.ActiveBorderColor = SystemColors.ActiveBorder;
            addfile_roundbutton.BackColor = Color.Transparent;
            addfile_roundbutton.backgroundColor = SystemColors.Control;
            addfile_roundbutton.BackgroundColor = SystemColors.Control;
            addfile_roundbutton.BorderColor = SystemColors.InactiveBorder;
            addfile_roundbutton.BorderWidth = 1F;
            addfile_roundbutton.ButtonBackgroundImage = Properties.Resources.plus;
            addfile_roundbutton.ButtonBackgroundImageLayout = ImageLayout.Zoom;
            addfile_roundbutton.ButtonPadding = new Padding(7);
            addfile_roundbutton.ButtonText = "";
            addfile_roundbutton.ButtonTextColor = SystemColors.ControlText;
            addfile_roundbutton.Dock = DockStyle.Fill;
            addfile_roundbutton.Location = new Point(5, 5);
            addfile_roundbutton.Margin = new Padding(1);
            addfile_roundbutton.MouseOverBackColor = SystemColors.ButtonHighlight;
            addfile_roundbutton.Name = "addfile_roundbutton";
            addfile_roundbutton.Radius = 999;
            addfile_roundbutton.Size = new Size(41, 41);
            addfile_roundbutton.TabIndex = 0;
            addfile_roundbutton.UseMouseOverBackColor = true;
            addfile_roundbutton.Click += roundButtonControl1_Click;
            // 
            // pnlSendButton
            // 
            pnlSendButton.Controls.Add(send_roundbutton);
            pnlSendButton.Dock = DockStyle.Right;
            pnlSendButton.Location = new Point(732, 5);
            pnlSendButton.Name = "pnlSendButton";
            pnlSendButton.Padding = new Padding(5, 0, 5, 0);
            pnlSendButton.Size = new Size(61, 51);
            pnlSendButton.TabIndex = 2;
            // 
            // send_roundbutton
            // 
            send_roundbutton.ActiveBorderColor = SystemColors.ActiveBorder;
            send_roundbutton.BackColor = Color.Transparent;
            send_roundbutton.backgroundColor = Color.White;
            send_roundbutton.BackgroundColor = Color.White;
            send_roundbutton.BackgroundImageLayout = ImageLayout.Zoom;
            send_roundbutton.BorderColor = Color.White;
            send_roundbutton.BorderWidth = 1F;
            send_roundbutton.ButtonBackgroundImage = Properties.Resources.send_gray;
            send_roundbutton.ButtonBackgroundImageLayout = ImageLayout.Zoom;
            send_roundbutton.ButtonPadding = new Padding(10);
            send_roundbutton.ButtonText = "";
            send_roundbutton.ButtonTextColor = SystemColors.ControlText;
            send_roundbutton.Dock = DockStyle.Fill;
            send_roundbutton.Location = new Point(5, 0);
            send_roundbutton.Margin = new Padding(1);
            send_roundbutton.MouseOverBackColor = Color.White;
            send_roundbutton.Name = "send_roundbutton";
            send_roundbutton.Radius = 9999;
            send_roundbutton.Size = new Size(51, 51);
            send_roundbutton.TabIndex = 2;
            send_roundbutton.UseMouseOverBackColor = true;
            send_roundbutton.Click += sendbutton_Click;
            // 
            // flwLytPnlAttachments
            // 
            flwLytPnlAttachments.AutoSize = true;
            flwLytPnlAttachments.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flwLytPnlAttachments.Dock = DockStyle.Bottom;
            flwLytPnlAttachments.Location = new Point(0, 479);
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
            smthFlwLytPnlMessages.Location = new Point(0, 47);
            smthFlwLytPnlMessages.Name = "smthFlwLytPnlMessages";
            smthFlwLytPnlMessages.ScrollSpeed = 10;
            smthFlwLytPnlMessages.Size = new Size(803, 361);
            smthFlwLytPnlMessages.TabIndex = 10;
            smthFlwLytPnlMessages.WrapContents = false;
            smthFlwLytPnlMessages.SizeChanged += smthFlwLytPnlMessages_SizeChanged;
            smthFlwLytPnlMessages.ControlAdded += smthFlwLytPnlMessages_ControlAdded;
            // 
            // pnlTop
            // 
            pnlTop.BackColor = SystemColors.Window;
            pnlTop.Controls.Add(flowLayoutPanel1);
            pnlTop.Controls.Add(panel1);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(803, 47);
            pnlTop.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(lblServer);
            flowLayoutPanel1.Controls.Add(flwLytPnlUsers);
            flowLayoutPanel1.Location = new Point(10, 9);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(740, 28);
            flowLayoutPanel1.TabIndex = 4;
            flowLayoutPanel1.WrapContents = false;
            // 
            // lblServer
            // 
            lblServer.AutoSize = true;
            lblServer.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblServer.Location = new Point(3, 0);
            lblServer.Name = "lblServer";
            lblServer.Padding = new Padding(8);
            lblServer.Size = new Size(67, 29);
            lblServer.TabIndex = 1;
            lblServer.Text = "lblServer";
            lblServer.TextAlign = ContentAlignment.MiddleCenter;
            lblServer.Click += label1_Click;
            // 
            // flwLytPnlUsers
            // 
            flwLytPnlUsers.AutoSize = true;
            flwLytPnlUsers.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flwLytPnlUsers.Location = new Point(76, 3);
            flwLytPnlUsers.Name = "flwLytPnlUsers";
            flwLytPnlUsers.Size = new Size(0, 0);
            flwLytPnlUsers.TabIndex = 2;
            flwLytPnlUsers.WrapContents = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(rndBtnCtrlClose);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(756, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(47, 47);
            panel1.TabIndex = 3;
            // 
            // rndBtnCtrlClose
            // 
            rndBtnCtrlClose.ActiveBorderColor = SystemColors.ActiveBorder;
            rndBtnCtrlClose.BackColor = Color.Transparent;
            rndBtnCtrlClose.backgroundColor = Color.White;
            rndBtnCtrlClose.BackgroundColor = Color.White;
            rndBtnCtrlClose.BorderColor = Color.White;
            rndBtnCtrlClose.BorderWidth = 1F;
            rndBtnCtrlClose.ButtonBackgroundImage = Properties.Resources.close;
            rndBtnCtrlClose.ButtonBackgroundImageLayout = ImageLayout.Zoom;
            rndBtnCtrlClose.ButtonPadding = new Padding(5);
            rndBtnCtrlClose.ButtonText = "";
            rndBtnCtrlClose.ButtonTextColor = SystemColors.ControlText;
            rndBtnCtrlClose.Dock = DockStyle.Fill;
            rndBtnCtrlClose.Location = new Point(5, 5);
            rndBtnCtrlClose.Margin = new Padding(1);
            rndBtnCtrlClose.MouseOverBackColor = SystemColors.ButtonHighlight;
            rndBtnCtrlClose.Name = "rndBtnCtrlClose";
            rndBtnCtrlClose.Radius = 999;
            rndBtnCtrlClose.Size = new Size(37, 37);
            rndBtnCtrlClose.TabIndex = 0;
            rndBtnCtrlClose.UseMouseOverBackColor = true;
            rndBtnCtrlClose.Click += rndBtnCtrlClose_Click;
            // 
            // loadingAnimationControl1
            // 
            loadingAnimationControl1.Anchor = AnchorStyles.None;
            loadingAnimationControl1.BackColor = Color.Transparent;
            loadingAnimationControl1.BrushColor = Color.Gray;
            loadingAnimationControl1.DotHeight = 5;
            loadingAnimationControl1.DotPadding = 5;
            loadingAnimationControl1.DotWidth = 5;
            loadingAnimationControl1.Location = new Point(391, 212);
            loadingAnimationControl1.Name = "loadingAnimationControl1";
            loadingAnimationControl1.Size = new Size(30, 30);
            loadingAnimationControl1.TabIndex = 0;
            loadingAnimationControl1.TickRate = 4E-07D;
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(803, 479);
            Controls.Add(loadingAnimationControl1);
            Controls.Add(smthFlwLytPnlMessages);
            Controls.Add(pnlChatPanel);
            Controls.Add(pnlTop);
            Controls.Add(flwLytPnlAttachments);
            DoubleBuffered = true;
            Name = "ChatForm";
            Text = "ChatForm";
            FormClosing += ChatForm_FormClosing;
            FormClosed += ChatForm_FormClosed;
            Load += ChatForm_Load;
            Paint += ChatForm_Paint;
            pnlChatPanel.ResumeLayout(false);
            rndCtrlChatbox.ResumeLayout(false);
            rndCtrlChatbox.PerformLayout();
            pnlAddButton.ResumeLayout(false);
            pnlSendButton.ResumeLayout(false);
            pnlTop.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private TextBox txtbxMessage;
        private Panel pnlChatPanel;
        private FlowLayoutPanel flwLytPnlAttachments;
        private RoundControl rndCtrlChatbox;
        private Panel pnlAddButton;
        private RoundButtonControl addfile_roundbutton;
        private SmoothFlowLayoutPanel smthFlwLytPnlMessages;
        private Panel pnlTop;
        private RoundButtonControl send_roundbutton;
        private Panel pnlSendButton;
        private Label lblServer;
        private FlowLayoutPanel flwLytPnlUsers;
        private Panel panel1;
        private RoundButtonControl rndBtnCtrlClose;
        private LoadingAnimationControl loadingAnimationControl1;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}