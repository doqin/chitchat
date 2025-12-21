namespace Client
{
    partial class AddServerForm
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
            rndTxtBxName = new RoundTextBoxControl();
            rndTxtBxIP = new RoundTextBoxControl();
            rndTxtBxPort = new RoundTextBoxControl();
            lblName = new Label();
            lblIP = new Label();
            lblPort = new Label();
            rndBtnCtrlAdd = new RoundButtonControl();
            SuspendLayout();
            // 
            // rndTxtBxName
            // 
            rndTxtBxName.BackColor = Color.Transparent;
            rndTxtBxName.BackgroundColor = Color.White;
            rndTxtBxName.BorderColor = SystemColors.ActiveBorder;
            rndTxtBxName.BorderWidth = 1F;
            rndTxtBxName.Location = new Point(36, 62);
            rndTxtBxName.Margin = new Padding(1);
            rndTxtBxName.Name = "rndTxtBxName";
            rndTxtBxName.Radius = 10;
            rndTxtBxName.Size = new Size(346, 39);
            rndTxtBxName.TabIndex = 0;
            rndTxtBxName.TextBoxBackgroundColor = Color.White;
            // 
            // rndTxtBxIP
            // 
            rndTxtBxIP.BackColor = Color.Transparent;
            rndTxtBxIP.BackgroundColor = Color.White;
            rndTxtBxIP.BorderColor = SystemColors.ActiveBorder;
            rndTxtBxIP.BorderWidth = 1F;
            rndTxtBxIP.Location = new Point(36, 147);
            rndTxtBxIP.Margin = new Padding(1);
            rndTxtBxIP.Name = "rndTxtBxIP";
            rndTxtBxIP.Radius = 10;
            rndTxtBxIP.Size = new Size(235, 39);
            rndTxtBxIP.TabIndex = 1;
            rndTxtBxIP.TextBoxBackgroundColor = Color.White;
            // 
            // rndTxtBxPort
            // 
            rndTxtBxPort.BackColor = Color.Transparent;
            rndTxtBxPort.BackgroundColor = Color.White;
            rndTxtBxPort.BorderColor = SystemColors.ActiveBorder;
            rndTxtBxPort.BorderWidth = 1F;
            rndTxtBxPort.Location = new Point(286, 147);
            rndTxtBxPort.Margin = new Padding(1);
            rndTxtBxPort.Name = "rndTxtBxPort";
            rndTxtBxPort.Radius = 10;
            rndTxtBxPort.Size = new Size(96, 39);
            rndTxtBxPort.TabIndex = 2;
            rndTxtBxPort.TextBoxBackgroundColor = Color.White;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblName.ForeColor = SystemColors.ControlText;
            lblName.Location = new Point(36, 37);
            lblName.Name = "lblName";
            lblName.Size = new Size(76, 15);
            lblName.TabIndex = 2;
            lblName.Text = "Tên máy chủ";
            // 
            // lblIP
            // 
            lblIP.AutoSize = true;
            lblIP.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblIP.ForeColor = SystemColors.ControlText;
            lblIP.Location = new Point(36, 122);
            lblIP.Name = "lblIP";
            lblIP.Size = new Size(58, 15);
            lblIP.TabIndex = 3;
            lblIP.Text = "Địa chỉ IP";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPort.ForeColor = SystemColors.ControlText;
            lblPort.Location = new Point(286, 122);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(62, 15);
            lblPort.TabIndex = 4;
            lblPort.Text = "Cổng Port";
            // 
            // rndBtnCtrlAdd
            // 
            rndBtnCtrlAdd.ActiveBorderColor = SystemColors.ActiveBorder;
            rndBtnCtrlAdd.BackColor = Color.Transparent;
            rndBtnCtrlAdd.backgroundColor = Color.FromArgb(12, 192, 66);
            rndBtnCtrlAdd.BackgroundColor = Color.FromArgb(12, 192, 66);
            rndBtnCtrlAdd.BorderColor = SystemColors.InactiveBorder;
            rndBtnCtrlAdd.BorderWidth = 1F;
            rndBtnCtrlAdd.ButtonBackgroundImage = null;
            rndBtnCtrlAdd.ButtonBackgroundImageLayout = ImageLayout.Tile;
            rndBtnCtrlAdd.ButtonPadding = new Padding(0);
            rndBtnCtrlAdd.ButtonText = "Thêm";
            rndBtnCtrlAdd.ButtonTextColor = Color.White;
            rndBtnCtrlAdd.Location = new Point(322, 217);
            rndBtnCtrlAdd.Margin = new Padding(1);
            rndBtnCtrlAdd.MouseOverBackColor = SystemColors.ControlDark;
            rndBtnCtrlAdd.Name = "rndBtnCtrlAdd";
            rndBtnCtrlAdd.Radius = 10;
            rndBtnCtrlAdd.Size = new Size(60, 42);
            rndBtnCtrlAdd.TabIndex = 3;
            rndBtnCtrlAdd.UseMouseOverBackColor = true;
            rndBtnCtrlAdd.Click += rndBtnCtrlAdd_Click;
            // 
            // AddServerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 245, 243);
            ClientSize = new Size(424, 295);
            Controls.Add(rndBtnCtrlAdd);
            Controls.Add(lblPort);
            Controls.Add(lblIP);
            Controls.Add(lblName);
            Controls.Add(rndTxtBxPort);
            Controls.Add(rndTxtBxIP);
            Controls.Add(rndTxtBxName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "AddServerForm";
            Text = "Thêm máy chủ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RoundTextBoxControl rndTxtBxName;
        private RoundTextBoxControl rndTxtBxIP;
        private RoundTextBoxControl rndTxtBxPort;
        private Label lblName;
        private Label lblIP;
        private Label lblPort;
        private RoundButtonControl rndBtnCtrlAdd;
    }
}