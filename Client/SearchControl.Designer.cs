namespace Client
{
    partial class SearchControl
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
            roundControl1 = new RoundControl();
            pnlSearch = new Panel();
            textBox1 = new TextBox();
            pnlIcon = new Panel();
            pictureBox1 = new PictureBox();
            roundControl1.SuspendLayout();
            pnlSearch.SuspendLayout();
            pnlIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // roundControl1
            // 
            roundControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roundControl1.BackColor = Color.Transparent;
            roundControl1.BackgroundColor = SystemColors.Control;
            roundControl1.BorderColor = SystemColors.InactiveBorder;
            roundControl1.BorderWidth = 1F;
            roundControl1.Controls.Add(pnlSearch);
            roundControl1.Controls.Add(pnlIcon);
            roundControl1.Location = new Point(0, 1);
            roundControl1.Margin = new Padding(2, 1, 2, 1);
            roundControl1.Name = "roundControl1";
            roundControl1.Radius = 10;
            roundControl1.Size = new Size(235, 43);
            roundControl1.TabIndex = 0;
            roundControl1.Load += roundControl1_Load;
            // 
            // pnlSearch
            // 
            pnlSearch.Controls.Add(textBox1);
            pnlSearch.Dock = DockStyle.Fill;
            pnlSearch.Location = new Point(52, 0);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Padding = new Padding(5);
            pnlSearch.Size = new Size(183, 43);
            pnlSearch.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Left;
            textBox1.BackColor = SystemColors.Control;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.ForeColor = SystemColors.Window;
            textBox1.Location = new Point(2, 14);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Tìm kiếm";
            textBox1.Size = new Size(150, 16);
            textBox1.TabIndex = 0;
            textBox1.Enter += textBox1_Enter;
            textBox1.Leave += textBox1_Leave;
            // 
            // pnlIcon
            // 
            pnlIcon.Controls.Add(pictureBox1);
            pnlIcon.Dock = DockStyle.Left;
            pnlIcon.Location = new Point(0, 0);
            pnlIcon.Name = "pnlIcon";
            pnlIcon.Padding = new Padding(5);
            pnlIcon.Size = new Size(52, 43);
            pnlIcon.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.search;
            pictureBox1.Location = new Point(5, 5);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(42, 33);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // SearchControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(roundControl1);
            Margin = new Padding(1);
            Name = "SearchControl";
            Size = new Size(237, 44);
            roundControl1.ResumeLayout(false);
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private RoundControl roundControl1;
        private TextBox textBox1;
        private PictureBox pictureBox1;
        private Panel pnlSearch;
        private Panel pnlIcon;
    }
}
