using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Protocol;

namespace Client
{
    public partial class ReactionRowControl : FlowLayoutPanel
    {

        private string? currentUserId;

        public void SetCurrentUserId(string userId)
        {
            currentUserId = userId;
        }

        // Event để báo ChatMessageControl khi reaction được click
        public event Action<string> ReactionClicked = _ => { };

        // Build UI dựa trên ReactionState
        public void SetState(ReactionState state)
        {
            if (currentUserId == null)
                throw new InvalidOperationException("CurrentUserId must be set before setting state.");

            System.Diagnostics.Debug.WriteLine($"Setting state");
            this.Invoke(() =>
            {
                Controls.Clear();
                foreach (var kvp in state.GetEmojiCounts())
                {
                    string emoji = kvp.Key;
                    int count = kvp.Value;
                    System.Diagnostics.Debug.WriteLine($"Adding reaction button: {emoji} with count {count}");

                    var btn = new Button
                    {
                        Text = $"{emoji} {count}",
                        Font = new Font(FontFamily.GenericSerif, 12),
                        AutoSize = true,
                        BackColor = state.HasUserReacted(emoji, currentUserId) ? Color.LightBlue : Color.White,
                        //FlatStyle = FlatStyle.Flat,
                        Padding = new Padding(3),
                        Margin = new Padding(2)
                    };

                    btn.Click += (s, e) =>
                    {
                        ReactionClicked?.Invoke(emoji); // báo ChatMessageControl toggle
                    };

                    Controls.Add(btn);
                }

                //Visible = state.GetEmojiCounts().Count > 0;
            });
        }
    }
}
