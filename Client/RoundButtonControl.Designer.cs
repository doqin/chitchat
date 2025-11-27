namespace Client
{
    partial class RoundButtonControl
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
            btnRoundButton = new Button();
            pnlButton = new Panel();
            pnlButton.SuspendLayout();
            SuspendLayout();
            // 
            // btnRoundButton
            // 
            btnRoundButton.Dock = DockStyle.Fill;
            btnRoundButton.FlatAppearance.BorderSize = 0;
            btnRoundButton.FlatStyle = FlatStyle.Flat;
            btnRoundButton.Location = new Point(0, 0);
            btnRoundButton.Name = "btnRoundButton";
            btnRoundButton.Size = new Size(146, 65);
            btnRoundButton.TabIndex = 0;
            btnRoundButton.Text = "btnRoundButton";
            btnRoundButton.UseVisualStyleBackColor = true;
            btnRoundButton.Click += btnRoundButton_Click;
            btnRoundButton.MouseEnter += btnRoundButton_MouseEnter;
            btnRoundButton.MouseLeave += btnRoundButton_MouseLeave;
            // 
            // pnlButton
            // 
            pnlButton.Controls.Add(btnRoundButton);
            pnlButton.Dock = DockStyle.Fill;
            pnlButton.Location = new Point(0, 0);
            pnlButton.Name = "pnlButton";
            pnlButton.Size = new Size(146, 65);
            pnlButton.TabIndex = 1;
            // 
            // RoundButtonControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderColor = SystemColors.InactiveBorder;
            Controls.Add(pnlButton);
            Name = "RoundButtonControl";
            Size = new Size(146, 65);
            Load += RoundButtonControl_Load;
            MouseEnter += RoundButton_MouseEnter;
            MouseLeave += RoundButton_MouseLeave;
            pnlButton.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlButton;
        internal Button btnRoundButton;
    }
}
