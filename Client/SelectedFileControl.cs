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
    public partial class SelectedFileControl : UserControl
    {
        public string FilePath { get; set; }
        private string _fileName;

        public SelectedFileControl(string FilePath)
        {
            this.FilePath = FilePath;
            _fileName = Path.GetFileName(FilePath);
            InitializeComponent();
            lblFileName.Text = _fileName;
            toolTip1.ToolTipTitle = _fileName;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            this.Parent?.Controls.Remove(this);
        }
    }
}
