namespace Client
{
    partial class AttachmentControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttachmentControl));
            roundControl1 = new RoundControl();
            pictureBox1 = new PictureBox();
            lblFileName = new Label();
            saveFileDialog1 = new SaveFileDialog();
            toolTip1 = new ToolTip(components);
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
            roundControl1.Controls.Add(lblFileName);
            roundControl1.Location = new Point(3, 2);
            roundControl1.Margin = new Padding(3, 2, 3, 2);
            roundControl1.Name = "roundControl1";
            roundControl1.Radius = 10;
            roundControl1.Size = new Size(162, 84);
            roundControl1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(25, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(36, 45);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // lblFileName
            // 
            lblFileName.AutoEllipsis = true;
            lblFileName.Location = new Point(67, 36);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(77, 15);
            lblFileName.TabIndex = 0;
            lblFileName.Text = "file_name";
            lblFileName.Click += lblFileName_Click;
            // 
            // AttachmentControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(roundControl1);
            Name = "AttachmentControl";
            Size = new Size(168, 88);
            roundControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private RoundControl roundControl1;
        private Label lblFileName;
        private SaveFileDialog saveFileDialog1;
        private PictureBox pictureBox1;
        private ToolTip toolTip1;
    }
}
