namespace Client
{
    partial class SelectedFileControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectedFileControl));
            roundControl1 = new RoundControl();
            btnRemove = new Button();
            lblFileName = new Label();
            pictureBox1 = new PictureBox();
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
            roundControl1.Controls.Add(btnRemove);
            roundControl1.Controls.Add(lblFileName);
            roundControl1.Controls.Add(pictureBox1);
            roundControl1.Location = new Point(0, 2);
            roundControl1.Margin = new Padding(3, 2, 3, 2);
            roundControl1.Name = "roundControl1";
            roundControl1.Radius = 10;
            roundControl1.Size = new Size(94, 123);
            roundControl1.TabIndex = 0;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(66, 3);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(25, 23);
            btnRemove.TabIndex = 1;
            btnRemove.Text = "X";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // lblFileName
            // 
            lblFileName.AutoEllipsis = true;
            lblFileName.Location = new Point(19, 81);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(58, 15);
            lblFileName.TabIndex = 1;
            lblFileName.Text = "file_name";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(28, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 42);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // SelectedFileControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(roundControl1);
            Name = "SelectedFileControl";
            Size = new Size(96, 126);
            roundControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private RoundControl roundControl1;
        private PictureBox pictureBox1;
        private Label lblFileName;
        private Button btnRemove;
        private ToolTip toolTip1;
    }
}
