using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    public partial class ReactionControl : UserControl
    {
        public event Action<string>? EmojiClicked; // nullable event

        public ReactionControl()
        {
            InitializeComponent();

            // Gán Click event cho tất cả button emoji trong FlowLayoutPanel
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c is Button btn)
                {
                    btn.Click += btnEmoji_Click;
                }
            }
        }

        private void btnEmoji_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                string emoji = btn.Text;
                EmojiClicked?.Invoke(emoji);

                // Highlight button đã chọn
                btn.BackColor = Color.LightBlue;
            }
        }
    }
}
