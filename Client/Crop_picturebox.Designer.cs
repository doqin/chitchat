namespace Client
{
    partial class Crop_picturebox
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Crop_picturebox));
            trackBar = new TrackBar();
            panel1 = new Panel();
            pictureBox = new PictureBox();
            roundButtonControl1 = new RoundButtonControl();
            ((System.ComponentModel.ISupportInitialize)trackBar).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // trackBar
            // 
            trackBar.Location = new Point(401, 353);
            trackBar.Maximum = 300;
            trackBar.Minimum = 100;
            trackBar.Name = "trackBar";
            trackBar.Size = new Size(210, 56);
            trackBar.TabIndex = 1;
            trackBar.Value = 100;
            trackBar.ValueChanged += trackBarZoom_ValueChanged;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(pictureBox);
            panel1.Location = new Point(251, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(310, 310);
            panel1.TabIndex = 2;
            // 
            // pictureBox
            // 
            pictureBox.Cursor = Cursors.SizeAll;
            pictureBox.Image = (Image)resources.GetObject("pictureBox.Image");
            pictureBox.Location = new Point(3, -2);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(300, 300);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // roundButtonControl1
            // 
            roundButtonControl1.ActiveBorderColor = SystemColors.ActiveBorder;
            roundButtonControl1.BackColor = Color.Transparent;
            roundButtonControl1.backgroundColor = Color.LightBlue;
            roundButtonControl1.BackgroundColor = Color.LightBlue;
            roundButtonControl1.BorderColor = SystemColors.InactiveBorder;
            roundButtonControl1.BorderWidth = 1F;
            roundButtonControl1.ButtonBackgroundImage = (Image)resources.GetObject("roundButtonControl1.ButtonBackgroundImage");
            roundButtonControl1.ButtonBackgroundImageLayout = ImageLayout.Zoom;
            roundButtonControl1.ButtonPadding = new Padding(20);
            roundButtonControl1.ButtonText = "";
            roundButtonControl1.ButtonTextColor = SystemColors.ControlText;
            roundButtonControl1.Location = new Point(209, 330);
            roundButtonControl1.Margin = new Padding(1);
            roundButtonControl1.MouseOverBackColor = SystemColors.ButtonHighlight;
            roundButtonControl1.Name = "roundButtonControl1";
            roundButtonControl1.Radius = 1000;
            roundButtonControl1.Size = new Size(76, 79);
            roundButtonControl1.TabIndex = 3;
            roundButtonControl1.UseMouseOverBackColor = true;
            roundButtonControl1.Click += btnCrop_Click;
            // 
            // Crop_picturebox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(roundButtonControl1);
            Controls.Add(panel1);
            Controls.Add(trackBar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Crop_picturebox";
            Text = "Crop Avatar";
            ((System.ComponentModel.ISupportInitialize)trackBar).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TrackBar trackBar;
        private Panel panel1;
        private PictureBox pictureBox;
        private RoundButtonControl roundButtonControl1;
    }
}