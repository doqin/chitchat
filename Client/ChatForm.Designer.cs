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
            lblSelectedFilesPrompt = new Label();
            lblSelectedFiles = new Label();
            flowPanelMessages = new FlowLayoutPanel();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
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
            txtbxMessage.Location = new Point(152, 62);
            txtbxMessage.Margin = new Padding(4, 5, 4, 5);
            txtbxMessage.Name = "txtbxMessage";
            txtbxMessage.Size = new Size(974, 31);
            txtbxMessage.TabIndex = 1;
            txtbxMessage.KeyDown += txtbxMessage_KeyDown;
            // 
            // btnPickFiles
            // 
            btnPickFiles.Location = new Point(15, 60);
            btnPickFiles.Margin = new Padding(4, 4, 4, 4);
            btnPickFiles.Name = "btnPickFiles";
            btnPickFiles.Size = new Size(118, 36);
            btnPickFiles.TabIndex = 2;
            btnPickFiles.Text = "Pick files";
            btnPickFiles.UseVisualStyleBackColor = true;
            btnPickFiles.Click += btnPickFiles_Click;
            // 
            // lblSelectedFilesPrompt
            // 
            lblSelectedFilesPrompt.AutoSize = true;
            lblSelectedFilesPrompt.ForeColor = SystemColors.Window;
            lblSelectedFilesPrompt.Location = new Point(15, 29);
            lblSelectedFilesPrompt.Margin = new Padding(4, 0, 4, 0);
            lblSelectedFilesPrompt.Name = "lblSelectedFilesPrompt";
            lblSelectedFilesPrompt.Size = new Size(123, 25);
            lblSelectedFilesPrompt.TabIndex = 3;
            lblSelectedFilesPrompt.Text = "Selected files: ";
            // 
            // lblSelectedFiles
            // 
            lblSelectedFiles.AutoSize = true;
            lblSelectedFiles.ForeColor = SystemColors.Window;
            lblSelectedFiles.Location = new Point(152, 29);
            lblSelectedFiles.Margin = new Padding(4, 0, 4, 0);
            lblSelectedFiles.Name = "lblSelectedFiles";
            lblSelectedFiles.Size = new Size(62, 25);
            lblSelectedFiles.TabIndex = 4;
            lblSelectedFiles.Text = "(none)";
            // 
            // flowPanelMessages
            // 
            flowPanelMessages.AutoScroll = true;
            flowPanelMessages.BackColor = Color.FromArgb(34, 34, 34);
            flowPanelMessages.Dock = DockStyle.Fill;
            flowPanelMessages.FlowDirection = FlowDirection.TopDown;
            flowPanelMessages.Location = new Point(0, 0);
            flowPanelMessages.Margin = new Padding(4, 4, 4, 4);
            flowPanelMessages.Name = "flowPanelMessages";
            flowPanelMessages.Size = new Size(1142, 622);
            flowPanelMessages.TabIndex = 5;
            flowPanelMessages.WrapContents = false;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(45, 45, 45);
            groupBox1.Controls.Add(lblSelectedFilesPrompt);
            groupBox1.Controls.Add(lblSelectedFiles);
            groupBox1.Controls.Add(txtbxMessage);
            groupBox1.Controls.Add(btnPickFiles);
            groupBox1.Dock = DockStyle.Bottom;
            groupBox1.Location = new Point(0, 506);
            groupBox1.Margin = new Padding(4, 4, 4, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 4, 4, 4);
            groupBox1.Size = new Size(1142, 116);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(23, 21, 32);
            ClientSize = new Size(1142, 622);
            Controls.Add(groupBox1);
            Controls.Add(flowPanelMessages);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ChatForm";
            Text = "ChatForm";
            FormClosing += ChatForm_FormClosing;
            Load += ChatForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private TextBox txtbxMessage;
        private Button btnPickFiles;
        private Label lblSelectedFilesPrompt;
        private Label lblSelectedFiles;
        private FlowLayoutPanel flowPanelMessages;
        private GroupBox groupBox1;
    }
}