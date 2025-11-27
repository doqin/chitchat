using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ProfileControl : UserControl
    {
        public string txtPort = "9999";
        public string txtUsername = "";
        public string profileImagePath = "";

        public Color BackgroundColor { get => roundControl1.BackgroundColor; set => roundControl1.BackgroundColor = value; }
        public Color BorderColor { get => roundControl1.BorderColor; set => roundControl1.BorderColor = value; }

        public Padding ProfilePicturePadding { get { return pnlProfilePicture.Padding; } set { pnlProfilePicture.Padding = value; } }
        public ProfileControl()
        {
            InitializeComponent();
        }

        public Color ActiveBorderColor { get; set; } = Color.FromKnownColor(KnownColor.ActiveBorder);

        private Color borderColor;

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void ProfileControl_Load(object sender, EventArgs e)
        {
            lblUser.Visible = false;
            lblStatus.Visible = false;
            crclrPctrBxProfile.Visible = false;
            borderColor = roundControl1.BorderColor;
            if (DesignMode) return;
            if (string.IsNullOrEmpty(ConfigManager.Current?.Username))
            {
                try
                {
                    using var loginForm = new LoginForm();

                    // debug helpers: ensure visible and centered
                    loginForm.StartPosition = FormStartPosition.CenterParent;
                    // temporarily make it top-most while debugging to ensure it's not hidden
                    // loginForm.TopMost = true;

                    // Try without owner first — sometimes passing a UserControl as owner causes issues
                    var result = loginForm.ShowDialog(); // ← try ShowDialog(this) after verifying it appears

                    if (result == DialogResult.OK)
                    {
                        txtUsername = loginForm.Username;
                        txtPort = Convert.ToString(loginForm.ServerPort);
                        ConfigManager.Current!.Username = txtUsername;
                        ConfigManager.Current!.UdpPort = txtPort;
                        if (loginForm.file != null)
                        {
                            crclrPctrBxProfile.Image = Image.FromFile(loginForm.file);
                            profileImagePath = loginForm.file;
                            crclrPctrBxProfile.DrawOutline = false;
                            crclrPctrBxProfile.Visible = true;
                            ConfigManager.Current!.ProfileImagePath = profileImagePath;
                        }
                        ConfigManager.Save();

                        lblUser.Text = txtUsername;
                        lblUser.Visible = true;

                        lblStatus.Text = "Online";
                        lblStatus.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    // show any exception so you see design/runtime errors
                    MessageBox.Show(this, $"Failed to open LoginForm: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                txtUsername = ConfigManager.Current!.Username;
                txtPort = ConfigManager.Current!.UdpPort;
                profileImagePath = ConfigManager.Current!.ProfileImagePath;
                lblUser.Text = txtUsername;
                lblUser.Visible = true;
                lblStatus.Text = "Online";
                lblStatus.Visible = true;
                if (!string.IsNullOrEmpty(profileImagePath))
                {
                    if (System.IO.File.Exists(Path.Combine("Cached", profileImagePath)))
                    {
                        crclrPctrBxProfile.Image = Image.FromFile(Path.Combine("Cached", profileImagePath));
                        crclrPctrBxProfile.DrawOutline = false;
                        crclrPctrBxProfile.Visible = true;
                    }
                }
            }
        }

        private void ProfileControl_Resize(object sender, EventArgs e)
        {
            pnlProfilePicture.Width = crclrPctrBxProfile.Width + pnlProfilePicture.Padding.Left + pnlProfilePicture.Padding.Right;
        }

        private void ProfileControl_MouseEnter(object sender, EventArgs e)
        {
            roundControl1.BorderColor = ActiveBorderColor;
        }

        private void ProfileControl_MouseLeave(object sender, EventArgs e)
        {
            roundControl1.BorderColor = borderColor;
        }
    }

}
