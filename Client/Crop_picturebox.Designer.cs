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
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)trackBar).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // trackBar
            // 
            trackBar.Anchor = AnchorStyles.Bottom;
            trackBar.Location = new Point(293, 18);
            trackBar.Margin = new Padding(3, 2, 3, 2);
            trackBar.Maximum = 300;
            trackBar.Minimum = 100;
            trackBar.Name = "trackBar";
            trackBar.Size = new Size(184, 45);
            trackBar.TabIndex = 1;
            trackBar.Value = 100;
            trackBar.ValueChanged += trackBarZoom_ValueChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(700, 273);
            panel1.TabIndex = 2;
            // 
            // pictureBox
            // 
            pictureBox.Cursor = Cursors.SizeAll;
            pictureBox.Image = (Image)resources.GetObject("pictureBox.Image");
            pictureBox.Location = new Point(0, 0);
            pictureBox.Margin = new Padding(3, 2, 3, 2);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(700, 273);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // roundButtonControl1
            // 
            roundButtonControl1.ActiveBorderColor = SystemColors.ActiveBorder;
            roundButtonControl1.Anchor = AnchorStyles.Bottom;
            roundButtonControl1.BackColor = Color.Transparent;
            roundButtonControl1.backgroundColor = Color.LightBlue;
            roundButtonControl1.BackgroundColor = Color.LightBlue;
            roundButtonControl1.BorderColor = SystemColors.InactiveBorder;
            roundButtonControl1.BorderWidth = 1F;
            roundButtonControl1.ButtonBackgroundImage = (Image)resources.GetObject("roundButtonControl1.ButtonBackgroundImage");
            roundButtonControl1.ButtonBackgroundImageLayout = ImageLayout.Zoom;
            roundButtonControl1.ButtonPadding = new Padding(15);
            roundButtonControl1.ButtonText = "";
            roundButtonControl1.ButtonTextColor = SystemColors.ControlText;
            roundButtonControl1.Location = new Point(239, 10);
            roundButtonControl1.Margin = new Padding(1);
            roundButtonControl1.MouseOverBackColor = SystemColors.ButtonHighlight;
            roundButtonControl1.Name = "roundButtonControl1";
            roundButtonControl1.Radius = 1000;
            roundButtonControl1.Size = new Size(50, 45);
            roundButtonControl1.TabIndex = 3;
            roundButtonControl1.UseMouseOverBackColor = true;
            roundButtonControl1.Click += btnCrop_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(roundButtonControl1);
            panel2.Controls.Add(trackBar);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 273);
            panel2.Name = "panel2";
            panel2.Size = new Size(700, 65);
            panel2.TabIndex = 4;
            // 
            // Crop_picturebox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Crop_picturebox";
            Text = "Crop Avatar";
            Resize += Crop_picturebox_Resize;
            ((System.ComponentModel.ISupportInitialize)trackBar).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TrackBar trackBar;
        private Panel panel1;
        private PictureBox pictureBox;
        private RoundButtonControl roundButtonControl1;
        private Panel panel2;
    }
}