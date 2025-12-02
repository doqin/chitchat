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
            components = new System.ComponentModel.Container();
            btnRoundButton = new Button();
            pnlButton = new Panel();
            toolTip1 = new ToolTip(components);
            pnlButton.SuspendLayout();
            SuspendLayout();
            // 
            // btnRoundButton
            // 
            btnRoundButton.Dock = DockStyle.Fill;
            btnRoundButton.FlatAppearance.BorderSize = 0;
            btnRoundButton.FlatStyle = FlatStyle.Flat;
            btnRoundButton.Location = new Point(0, 0);
            btnRoundButton.Margin = new Padding(3, 4, 3, 4);
            btnRoundButton.Name = "btnRoundButton";
            btnRoundButton.Size = new Size(167, 87);
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
            pnlButton.Margin = new Padding(3, 4, 3, 4);
            pnlButton.Name = "pnlButton";
            pnlButton.Size = new Size(167, 87);
            pnlButton.TabIndex = 1;
            // 
            // tooltip1
            //
            toolTip1.SetToolTip(btnRoundButton, "Add files");
            // 
            // RoundButtonControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderColor = SystemColors.InactiveBorder;
            Controls.Add(pnlButton);
            Name = "RoundButtonControl";
            Size = new Size(167, 87);
            Load += RoundButtonControl_Load;
            MouseEnter += RoundButton_MouseEnter;
            MouseLeave += RoundButton_MouseLeave;
            pnlButton.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlButton;
        internal Button btnRoundButton;
        private ToolTip toolTip1;
    }
}
