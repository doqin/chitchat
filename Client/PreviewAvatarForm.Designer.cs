namespace Client
{
    partial class PreviewAvatarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreviewAvatarForm));
            pictureBoxPreview = new PictureBox();
            btnBack = new RoundButtonControl();
            btnSave = new RoundButtonControl();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxPreview
            // 
            pictureBoxPreview.Image = (Image)resources.GetObject("pictureBoxPreview.Image");
            pictureBoxPreview.Location = new Point(124, 39);
            pictureBoxPreview.Name = "pictureBoxPreview";
            pictureBoxPreview.Size = new Size(555, 222);
            pictureBoxPreview.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPreview.TabIndex = 0;
            pictureBoxPreview.TabStop = false;
            // 
            // btnBack
            // 
            btnBack.ActiveBorderColor = SystemColors.ActiveBorder;
            btnBack.BackColor = Color.Transparent;
            btnBack.backgroundColor = SystemColors.ActiveCaption;
            btnBack.BackgroundColor = SystemColors.ActiveCaption;
            btnBack.BorderColor = SystemColors.InactiveBorder;
            btnBack.BorderWidth = 1F;
            btnBack.ButtonBackgroundImage = null;
            btnBack.ButtonBackgroundImageLayout = ImageLayout.Tile;
            btnBack.ButtonPadding = new Padding(0);
            btnBack.ButtonText = "Back";
            btnBack.ButtonTextColor = SystemColors.ControlText;
            btnBack.Location = new Point(124, 289);
            btnBack.Margin = new Padding(1);
            btnBack.MouseOverBackColor = SystemColors.ButtonHighlight;
            btnBack.Name = "btnBack";
            btnBack.Radius = 1000;
            btnBack.Size = new Size(209, 109);
            btnBack.TabIndex = 1;
            btnBack.UseMouseOverBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnSave
            // 
            btnSave.ActiveBorderColor = SystemColors.ActiveBorder;
            btnSave.BackColor = Color.Transparent;
            btnSave.backgroundColor = SystemColors.ActiveCaption;
            btnSave.BackgroundColor = SystemColors.ActiveCaption;
            btnSave.BorderColor = SystemColors.InactiveBorder;
            btnSave.BorderWidth = 1F;
            btnSave.ButtonBackgroundImage = null;
            btnSave.ButtonBackgroundImageLayout = ImageLayout.Tile;
            btnSave.ButtonPadding = new Padding(0);
            btnSave.ButtonText = "Save";
            btnSave.ButtonTextColor = SystemColors.ControlText;
            btnSave.Location = new Point(470, 289);
            btnSave.Margin = new Padding(1);
            btnSave.MouseOverBackColor = SystemColors.ButtonHighlight;
            btnSave.Name = "btnSave";
            btnSave.Radius = 1000;
            btnSave.Size = new Size(209, 109);
            btnSave.TabIndex = 2;
            btnSave.UseMouseOverBackColor = true;
            // 
            // PreviewAvatarForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(btnBack);
            Controls.Add(pictureBoxPreview);
            Name = "PreviewAvatarForm";
            Text = "PreviewAvatarForm";
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxPreview;
        private RoundButtonControl btnBack;
        private RoundButtonControl btnSave;
    }
}