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

        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Username = string.IsNullOrWhiteSpace(txtUsername?.Text) ? "username" : txtUsername.Text.Trim();
            ServerPort = int.TryParse(txtPort?.Text, out var p) ? p : 0;
            DialogResult = DialogResult.OK;
            ActiveForm?.Close();
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
                circularPictureBox1.Image = Image.FromFile(file);
            }
        }
    }
}
