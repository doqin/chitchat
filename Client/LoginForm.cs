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
        private AlertForm alertForm;

        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            rndTxtBxCtrlUsername.Text = ConfigManager.Current!.Username;
            SetPreviewMessages(ConfigManager.Current!.ProfileImagePath);
        }

        private void SetPreviewMessages(string profileImagePath)
        {
            try
            {
                chatMessageControl1.SetPreview(profileImagePath, ConfigManager.Current!.Username, "Xin chào", DateTime.Now);
                chatMessageControl2.SetPreview(profileImagePath, ConfigManager.Current!.Username, "Đây là một preview", DateTime.Now);
                chatMessageControl3.SetPreview(profileImagePath, ConfigManager.Current!.Username, "Thay Avatar để cập nhật preview!", DateTime.Now);
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("Failed to set preview message");
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Username = string.IsNullOrWhiteSpace(rndTxtBxCtrlUsername?.Text) ? "username" : rndTxtBxCtrlUsername.Text.Trim();
            DialogResult = DialogResult.OK;
            ConfigManager.Current!.Username = Username;
            if (!string.IsNullOrEmpty(file))
            {
                ConfigManager.Current!.ProfileImagePath = file;
            }
            else
                quickAlert("Bạn chưa chọn avatar!", AlertForm.enmAlertType.Warning);
                ConfigManager.Save();
            eventHandler?.Invoke(this, e);
        }

        private void EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSubmit_Click(sender, e);
            }
        }

        private void rndBtnCtrlChangeAvatar_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                file = openFileDialog1.FileName;
                SetPreviewMessages(file);
            }
        }

        private void rndBtnCtrlRemoveAvatar_Click(object sender, EventArgs e)
        {
            file = "";
            SetPreviewMessages(file);
        }

        void quickAlert(string msg, AlertForm.enmAlertType type)
        {
            alertForm = new AlertForm();
            alertForm.showAlert(msg, type);
        }
    }
}
