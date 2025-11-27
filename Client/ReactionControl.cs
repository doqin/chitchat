using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    public partial class ReactionControl : UserControl
    {
        public event Action<string>? EmojiClicked;

        public ReactionControl()
        {
            InitializeComponent();

            // Khi ReactionControl được hiển thị, bật flowLayoutPanel và tất cả button
            this.VisibleChanged += ReactionControl_VisibleChanged;

            // Gán Click event cho tất cả button emoji
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c is Button btn)
                    btn.Click += btnEmoji_Click;
            }
        }

        private void ReactionControl_VisibleChanged(object? sender, EventArgs e)
        {
            if (this.Visible)
            {
                flowLayoutPanel1.Visible = true;

                foreach (Control c in flowLayoutPanel1.Controls)
                    if (c is Button btn)
                        btn.Visible = true;
            }
            else
            {
                flowLayoutPanel1.Visible = false;
            }
        }

        private void btnEmoji_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                string emoji = btn.Text;
                EmojiClicked?.Invoke(emoji);
                btn.BackColor = Color.LightBlue;
            }
        }

        // Method gọi từ ChatMessageControl
        public void ShowEmojis()
        {
            this.Visible = true;
        }
    }
}
