namespace Client
{
    partial class RoundTextBoxControl
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
            txtbox = new TextBox();
            SuspendLayout();
            // 
            // txtbox
            // 
            txtbox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtbox.BackColor = SystemColors.Control;
            txtbox.BorderStyle = BorderStyle.None;
            txtbox.Location = new Point(14, 12);
            txtbox.Name = "txtbox";
            txtbox.Size = new Size(192, 16);
            txtbox.TabIndex = 0;
            // 
            // RoundTextBoxControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtbox);
            Name = "RoundTextBoxControl";
            Size = new Size(220, 39);
            Load += RoundTextBoxControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox txtbox;
    }
}
