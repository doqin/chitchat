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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchControl));
            roundControl1 = new RoundControl();
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            roundControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // roundControl1
            // 
            roundControl1.backgroundColor = SystemColors.Control;
            roundControl1.BorderColor = SystemColors.Control;
            roundControl1.BorderWidth = 1F;
            roundControl1.Controls.Add(pictureBox1);
            roundControl1.Controls.Add(textBox1);
            roundControl1.Location = new Point(3, 2);
            roundControl1.Margin = new Padding(3, 2, 3, 2);
            roundControl1.Name = "roundControl1";
            roundControl1.Radius = 10;
            roundControl1.Size = new Size(297, 79);
            roundControl1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(19, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 34);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Control;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(60, 32);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Search for conversations...";
            textBox1.Size = new Size(225, 16);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // SearchControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(roundControl1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "SearchControl";
            Size = new Size(303, 83);
            roundControl1.ResumeLayout(false);
            roundControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private RoundControl roundControl1;
        private TextBox textBox1;
        private PictureBox pictureBox1;
    }
}
