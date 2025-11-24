namespace Client
{
    partial class ReactionRowControl
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
            flowLayoutPanelReactions = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanelReactions.AutoSize = true;
            flowLayoutPanelReactions.Dock = DockStyle.Fill;
            flowLayoutPanelReactions.Location = new Point(0, 0);
            flowLayoutPanelReactions.Name = "flowLayoutPanel1";
            flowLayoutPanelReactions.Size = new Size(150, 150);
            flowLayoutPanelReactions.TabIndex = 0;
            flowLayoutPanelReactions.WrapContents = false;
            // 
            // ReactionRowControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowLayoutPanelReactions);
            Name = "ReactionRowControl";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanelReactions;
    }
}
