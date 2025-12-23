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
    public partial class AddServerForm : Form
    {
        public AddServerForm()
        {
            InitializeComponent();
        }

        private void rndBtnCtrlAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rndTxtBxName.Text))
            {
                MessageBox.Show("Please enter a server name.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(rndTxtBxIP.Text))
            {
                MessageBox.Show("Please enter a valid server address.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var addr = System.Net.IPAddress.Parse(rndTxtBxIP.Text);
            }
            catch
            {
                MessageBox.Show("Please enter a valid IP address.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(rndTxtBxPort.Text, out int port) || port < 1 || port > 65535)
            {
                MessageBox.Show("Please enter a valid port number (1-65535).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ConfigManager.Current!.SavedServers = ConfigManager.Current!.SavedServers.Append(new Protocol.Server
            {
                Name = rndTxtBxName.Text,
                IPAddress = rndTxtBxIP.Text,
                Port = port
            }).ToArray();
            ConfigManager.Save();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
