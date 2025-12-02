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
    public partial class SettingsForm : Form
    {
        private LoginForm loginForm;
        private EventHandler eventHandler;
        public SettingsForm(EventHandler eventHandler)
        {
            InitializeComponent();
            this.eventHandler = eventHandler;
        }

        private void btnOther_MouseHover(object sender, EventArgs e)
        {
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            splctnSettings.Panel2.Controls.Clear();
            loginForm = new LoginForm();
            loginForm.TopLevel = false;
            loginForm.FormBorderStyle = FormBorderStyle.None;
            loginForm.Dock = DockStyle.Fill;
            loginForm.eventHandler = eventHandler;
            splctnSettings.Panel2.Controls.Add(loginForm);
            loginForm.Show();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            btnUser.PerformClick();

        }

        private void btnOther_Click(object sender, EventArgs e)
        {
            splctnSettings.Panel2.Controls.Clear();
            OtherForm otherForm = new OtherForm();
            otherForm.TopLevel = false;
            otherForm.FormBorderStyle = FormBorderStyle.None;
            otherForm.Dock = DockStyle.Fill;
            splctnSettings.Panel2.Controls.Add(otherForm);
            otherForm.Show();
        }
    }
}
