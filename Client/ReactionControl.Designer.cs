namespace Client
{
    partial class ReactionControl
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(button1);
            flowLayoutPanel1.Controls.Add(button2);
            flowLayoutPanel1.Controls.Add(button3);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(150, 150);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.Visible = false;
            // 
            // button1
            // 
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(43, 29);
            button1.TabIndex = 0;
            button1.Text = "😀";
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            // 
            // button2
            // 
            button2.Location = new Point(52, 3);
            button2.Name = "button2";
            button2.Size = new Size(45, 29);
            button2.TabIndex = 1;
            button2.Text = "\U0001f923";
            button2.UseVisualStyleBackColor = true;
            button2.Visible = false;
            // 
            // button3
            // 
            button3.Location = new Point(103, 3);
            button3.Name = "button3";
            button3.Size = new Size(43, 29);
            button3.TabIndex = 2;
            button3.Text = "😍";
            button3.UseVisualStyleBackColor = false;
            button3.Visible = false;
            // 
            // ReactionControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowLayoutPanel1);
            Name = "ReactionControl";
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}
