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
            flowLayoutPanel1.Location = new Point(17, 20);
            flowLayoutPanel1.Margin = new Padding(4, 5, 4, 5);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1109, 710);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // lsbxMessages
            // 
            lsbxMessages.BackColor = Color.FromArgb(32, 30, 45);
            lsbxMessages.Font = new Font("Sans Serif Collection", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lsbxMessages.ForeColor = SystemColors.InactiveBorder;
            lsbxMessages.FormattingEnabled = true;
            lsbxMessages.ItemHeight = 95;
            lsbxMessages.Location = new Point(4, 5);
            lsbxMessages.Margin = new Padding(4, 5, 4, 5);
            lsbxMessages.Name = "lsbxMessages";
            lsbxMessages.Size = new Size(1087, 574);
            lsbxMessages.TabIndex = 0;
            // 
            // txtbxMessage
            // 
            txtbxMessage.Location = new Point(4, 589);
            txtbxMessage.Margin = new Padding(4, 5, 4, 5);
            txtbxMessage.Name = "txtbxMessage";
            txtbxMessage.Size = new Size(1087, 31);
            txtbxMessage.TabIndex = 1;
            txtbxMessage.KeyDown += txtbxMessage_KeyDown;
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(23, 21, 32);
            ClientSize = new Size(1143, 750);
            Controls.Add(flowLayoutPanel1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ChatForm";
            Text = "ChatForm";
            FormClosing += ChatForm_FormClosing;
            Load += ChatForm_Load;
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