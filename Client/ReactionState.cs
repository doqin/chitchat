using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ReactionState
    {
        public string MessageId { get; set; }
        public Dictionary<string, HashSet<string>> Emoji_To_Users { get; set; } = new();

        public ReactionState()
        {
            MessageId = string.Empty;
        }

        // Lấy số lượng react cho mỗi emoji
        public Dictionary<string, int> GetEmojiCounts()
        {
            return Emoji_To_Users.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Count);
        }

        public bool HasUserReacted(string emoji, string username)
        {
            return Emoji_To_Users.ContainsKey(emoji) && Emoji_To_Users[emoji].Contains(username);
        }
    }
}
