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
        private string originalFilePath = "";

        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            if (ConfigManager.Current == null) ConfigManager.Load();

            rndTxtBxCtrlUsername.Text = ConfigManager.Current!.Username;

            if (!string.IsNullOrEmpty(ConfigManager.Current.ProfileImagePath))
            {
                this.file = ConfigManager.Current.ProfileImagePath;
            }

            if (!string.IsNullOrEmpty(ConfigManager.Current.OriginalProfileImagePath))
            {
                this.originalFilePath = ConfigManager.Current.OriginalProfileImagePath;
            }

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
            ConfigManager.Save();
            eventHandler?.Invoke(this, e);
        }

        private void rndBtnCtrlChangeAvatar_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                originalFilePath = openFileDialog1.FileName;

                file = originalFilePath;

                SetPreviewMessages(file);
            }
        }

        private void rndBtnCtrlRemoveAvatar_Click(object sender, EventArgs e)
        {
            file = "";
            SetPreviewMessages(file);
        }

        private void btnEditAvatar_Click(object sender, EventArgs e)
        {
            string pathHeaderToLoad = "";
            if (!string.IsNullOrEmpty(originalFilePath) && File.Exists(originalFilePath))
            {
                pathHeaderToLoad = originalFilePath; 
            }
            else if (!string.IsNullOrEmpty(file) && File.Exists(file))
            {
                pathHeaderToLoad = file; 
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ảnh mới trước khi chỉnh sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {

                using (Image sourceImg = Image.FromFile(pathHeaderToLoad))
                {

                    Crop_picturebox cropForm = new Crop_picturebox(sourceImg);

                    if (cropForm.ShowDialog() == DialogResult.OK)
                    {

                        Image newAvatar = cropForm.FinalAvatar;

                        string newFileName = $"avatar_cropped_{DateTime.Now.Ticks}.png";
                        string savePath = Path.Combine(Application.StartupPath, newFileName);

                        newAvatar.Save(savePath, System.Drawing.Imaging.ImageFormat.Png);

                        file = savePath;
                        SetPreviewMessages(file);

                        MessageBox.Show("Đã cập nhật ảnh đại diện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chỉnh sửa ảnh: " + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            ConfigManager.Current.ProfileImagePath = this.file; 
            ConfigManager.Current.OriginalProfileImagePath = this.originalFilePath; 

            ConfigManager.Save();
        }
    }
}
