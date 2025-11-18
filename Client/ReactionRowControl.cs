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
    public partial class ReactionRowControl : UserControl
    {
        private string currentUserId;
        public ReactionRowControl()
        {
            InitializeComponent();
        }

        public void SetCurrentUserId(string userId)
        {
            currentUserId = userId;
        }

        // Event để báo ChatMessageControl khi reaction được click
        public event Action<string> ReactionClicked;

        // Build UI dựa trên ReactionState
        public void SetState(ReactionState state)
        {
            flowLayoutPanelReactions.Controls.Clear();

            foreach (var kvp in state.GetEmojiCounts())
            {
                string emoji = kvp.Key;
                int count = kvp.Value;

                var btn = new Button
                {
                    Text = $"{emoji} {count}",
                    AutoSize = true,
                    BackColor = state.HasUserReacted(emoji, currentUserId) ? Color.LightBlue : Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Padding = new Padding(3),
                    Margin = new Padding(2)
                };

                btn.Click += (s, e) =>
                {
                    ReactionClicked?.Invoke(emoji); // báo ChatMessageControl toggle
                };

                flowLayoutPanelReactions.Controls.Add(btn);
            }

            this.Visible = state.GetEmojiCounts().Count > 0;
        }
    }
}
