using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ReactionManager
    {
        private Dictionary<string, ReactionState> _reactionStates = new();

        public ReactionManager()
        {
            // Initialize the event with an empty delegate to satisfy the non-nullable requirement
            On_Reaction_Updated = _ => { };
        }

        // Event để UI subcribe
        public event Action<string> On_Reaction_Updated;

        // Toggle reaction local
        public void ToggleReaction(string messageId, string emoji, string userId)
        {
            if (!_reactionStates.ContainsKey(messageId))
                _reactionStates[messageId] = new ReactionState { MessageId = messageId };

            var state = _reactionStates[messageId];

            if (!state.Emoji_To_Users.ContainsKey(emoji))
                state.Emoji_To_Users[emoji] = new HashSet<string>();

            if (!state.Emoji_To_Users[emoji].Contains(userId))
                state.Emoji_To_Users[emoji].Add(userId); // thả reaction
            else
                state.Emoji_To_Users[emoji].Remove(userId); // gỡ reaction

            if (state.Emoji_To_Users[emoji].Count == 0)
                state.Emoji_To_Users.Remove(emoji);

            // Notify UI rebuild
            On_Reaction_Updated?.Invoke(messageId);
        }

        // Lấy state để UI render
        public ReactionState GetState(string messageId)
        {
            return _reactionStates.ContainsKey(messageId) ? _reactionStates[messageId] : new ReactionState { MessageId = messageId };
        }
    }
}
