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
    public partial class LoginForm : Form
    {
        public string Username;
        public int ServerPort;
        public string file = "";
        public EventHandler? eventHandler;

        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            txtUsername.Text = ConfigManager.Current!.Username;
            if (string.IsNullOrEmpty(ConfigManager.Current!.ProfileImagePath))
            {
                picAvatar.Image = null;
            }
            else
            {
                try
                {
                    picAvatar.Image = Image.FromFile(ConfigManager.Current!.ProfileImagePath);
                }
                catch
                {
                    picAvatar.Image = null;
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Username = string.IsNullOrWhiteSpace(txtUsername?.Text) ? "username" : txtUsername.Text.Trim();
            DialogResult = DialogResult.OK;
            ConfigManager.Current!.Username = Username;
            if (!string.IsNullOrEmpty(file))
            {
                ConfigManager.Current!.ProfileImagePath = file;
            }
            ConfigManager.Save();
            eventHandler?.Invoke(this, e);
        }

        private void EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSubmit.PerformClick();
            }
        }

        private void circularPictureBox1_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                file = openFileDialog1.FileName;
                picAvatar.Image = Image.FromFile(file);
            }
        }
    }
}
