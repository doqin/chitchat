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
            pnlIcon = new Panel();
            pictureBox1 = new PictureBox();
            pnlSearch = new Panel();
            textBox1 = new TextBox();
            pnlIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlSearch.SuspendLayout();
            SuspendLayout();
            // 
            // pnlIcon
            // 
            pnlIcon.Controls.Add(pictureBox1);
            pnlIcon.Dock = DockStyle.Left;
            pnlIcon.Location = new Point(0, 0);
            pnlIcon.Name = "pnlIcon";
            pnlIcon.Padding = new Padding(5);
            pnlIcon.Size = new Size(52, 33);
            pnlIcon.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.search;
            pictureBox1.Location = new Point(5, 5);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(42, 23);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pnlSearch
            // 
            pnlSearch.Controls.Add(textBox1);
            pnlSearch.Dock = DockStyle.Fill;
            pnlSearch.Location = new Point(52, 0);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Padding = new Padding(5);
            pnlSearch.Size = new Size(155, 33);
            pnlSearch.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Left;
            textBox1.BackColor = SystemColors.Control;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.ForeColor = Color.Black;
            textBox1.Location = new Point(2, 8);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Tìm kiếm";
            textBox1.Size = new Size(131, 16);
            textBox1.TabIndex = 0;
            textBox1.Enter += textBox1_Enter;
            textBox1.Leave += textBox1_Leave;
            // 
            // SearchControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(pnlSearch);
            Controls.Add(pnlIcon);
            Name = "SearchControl";
            Size = new Size(207, 33);
            Load += SearchControl_Load;
            pnlIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlIcon;
        private PictureBox pictureBox1;
        private Panel pnlSearch;
        private TextBox textBox1;
    }
}
