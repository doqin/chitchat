using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ReactionManager
    {
        // Dictionary to hold reaction states per message
        private Dictionary<string, ReactionState> _reactionStates = new();

        public ReactionManager()
        {
        }

        /// <summary>
        /// Occurs when a reaction is updated, providing the identifier of the updated reaction.
        /// </summary>
        /// <remarks> Subscribers are notified with the reaction identifier whenever a reaction is
        /// modified. This event is invoked even if the update does not change the reaction's value. Handlers should be
        /// thread-safe if updates may occur concurrently.
        /// </remarks>
        public event Action<string> On_Reaction_Updated = _ => { };

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
