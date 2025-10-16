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
            flowLayoutPanel1 = new FlowLayoutPanel();
            lsbxMessages = new ListBox();
            txtbxMessage = new TextBox();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(lsbxMessages);
            flowLayoutPanel1.Controls.Add(txtbxMessage);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(12, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(776, 426);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // lsbxMessages
            // 
            lsbxMessages.FormattingEnabled = true;
            lsbxMessages.ItemHeight = 15;
            lsbxMessages.Location = new Point(3, 3);
            lsbxMessages.Name = "lsbxMessages";
            lsbxMessages.Size = new Size(762, 379);
            lsbxMessages.TabIndex = 0;
            // 
            // txtbxMessage
            // 
            txtbxMessage.Location = new Point(3, 388);
            txtbxMessage.Name = "txtbxMessage";
            txtbxMessage.Size = new Size(762, 23);
            txtbxMessage.TabIndex = 1;
            txtbxMessage.KeyDown += txtbxMessage_KeyDown;
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flowLayoutPanel1);
            Name = "ChatForm";
            Text = "ChatForm";
            FormClosing += ChatForm_FormClosing;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private ListBox lsbxMessages;
        private TextBox txtbxMessage;
    }
}