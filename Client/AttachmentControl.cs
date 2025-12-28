using Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class AttachmentControl : UserControl
    {
        private IPAddress _address;
        private int _port;
        private string _fileName;

        public AttachmentControl(IPAddress address, int port, string fileName)
        {
            InitializeComponent();
            _address = address;
            _port = port;
            _fileName = fileName;
            toolTip1.ToolTipTitle = _fileName;
            lblFileName.Text = Path.GetFileName(fileName);
        }

        private void lblFileName_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = Path.GetFileName(_fileName);
            var result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Fetch the file from the server
                System.Diagnostics.Debug.WriteLine($"Saving File: {saveFileDialog1.FileName}");
                var request = new Wrapper
                {
                    Type = Types.GetFile,
                    Payload = _fileName
                };
                string requestJson = JsonSerializer.Serialize(request);
                var filePath = Protocol.File.FetchFile(_address, _port, _fileName, saveFileDialog1.FileName);
                if (string.IsNullOrEmpty(filePath) || (!string.IsNullOrEmpty(filePath) && filePath == "Not found"))
                {
                    MessageBox.Show("File not found on server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("File saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
