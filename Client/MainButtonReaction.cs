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
    public partial class MainButtonReaction : UserControl
    {
        public event EventHandler MainEmojiClick;

        public MainButtonReaction()
        {
            InitializeComponent();
            button1.Click += InnerButton_Click; // innerButton là Button thật bên trong
        }

        private void InnerButton_Click(object sender, EventArgs e)
        {
            // Forward sự kiện ra ngoài
            MainEmojiClick?.Invoke(this, e);
        }
    }
}
