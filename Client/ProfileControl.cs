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
        public ProfileControl()
        {
            InitializeComponent();

            lblUser.Visible = false;
            lblStatus.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
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
                    if (loginForm.file != null)
                    {
                        pictureBox1.Image = Image.FromFile(loginForm.file);
                        profileImagePath = loginForm.file;
                    }

                    lblUser.Text = txtUsername;
                    lblUser.Visible = true;

                    lblStatus.Text = "Online";
                    lblStatus.Visible = true;

                    btnLogin.Visible = false;
                }
            }
            catch (Exception ex)
            {
                // show any exception so you see design/runtime errors
                MessageBox.Show(this, $"Failed to open LoginForm: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
