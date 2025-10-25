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
            lsbxMessages = new ListBox();
            btnPickFiles = new Button();
            lblSelectedFilesPrompt = new Label();
            lblSelectedFiles = new Label();
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
            txtbxMessage.Location = new Point(112, 458);
            txtbxMessage.Margin = new Padding(3, 4, 3, 4);
            txtbxMessage.Name = "txtbxMessage";
            txtbxMessage.Size = new Size(790, 27);
            txtbxMessage.TabIndex = 1;
            txtbxMessage.KeyDown += txtbxMessage_KeyDown;
            // 
            // lsbxMessages
            // 
            lsbxMessages.BackColor = Color.FromArgb(32, 30, 45);
            lsbxMessages.Font = new Font("Sans Serif Collection", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lsbxMessages.ForeColor = SystemColors.InactiveBorder;
            lsbxMessages.FormattingEnabled = true;
            lsbxMessages.ItemHeight = 78;
            lsbxMessages.Location = new Point(12, 13);
            lsbxMessages.Margin = new Padding(3, 4, 3, 4);
            lsbxMessages.Name = "lsbxMessages";
            lsbxMessages.Size = new Size(890, 394);
            lsbxMessages.TabIndex = 0;
            // 
            // btnPickFiles
            // 
            btnPickFiles.Location = new Point(12, 456);
            btnPickFiles.Name = "btnPickFiles";
            btnPickFiles.Size = new Size(94, 29);
            btnPickFiles.TabIndex = 2;
            btnPickFiles.Text = "Pick files";
            btnPickFiles.UseVisualStyleBackColor = true;
            btnPickFiles.Click += btnPickFiles_Click;
            // 
            // lblSelectedFilesPrompt
            // 
            lblSelectedFilesPrompt.AutoSize = true;
            lblSelectedFilesPrompt.ForeColor = SystemColors.Window;
            lblSelectedFilesPrompt.Location = new Point(12, 421);
            lblSelectedFilesPrompt.Name = "lblSelectedFilesPrompt";
            lblSelectedFilesPrompt.Size = new Size(104, 20);
            lblSelectedFilesPrompt.TabIndex = 3;
            lblSelectedFilesPrompt.Text = "Selected files: ";
            // 
            // lblSelectedFiles
            // 
            lblSelectedFiles.AutoSize = true;
            lblSelectedFiles.ForeColor = SystemColors.Window;
            lblSelectedFiles.Location = new Point(112, 421);
            lblSelectedFiles.Name = "lblSelectedFiles";
            lblSelectedFiles.Size = new Size(52, 20);
            lblSelectedFiles.TabIndex = 4;
            lblSelectedFiles.Text = "(none)";
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(23, 21, 32);
            ClientSize = new Size(914, 498);
            Controls.Add(lblSelectedFiles);
            Controls.Add(lblSelectedFilesPrompt);
            Controls.Add(btnPickFiles);
            Controls.Add(lsbxMessages);
            Controls.Add(txtbxMessage);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ChatForm";
            Text = "ChatForm";
            FormClosing += ChatForm_FormClosing;
            Load += ChatForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private TextBox txtbxMessage;
        private ListBox lsbxMessages;
        private Button btnPickFiles;
        private Label lblSelectedFilesPrompt;
        private Label lblSelectedFiles;
    }
}