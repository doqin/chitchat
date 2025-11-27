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
            System.Diagnostics.Debug.WriteLine($"Toggling {emoji} at {messageId} by {userId}");
            if (!_reactionStates.ContainsKey(messageId))
            {
                System.Diagnostics.Debug.WriteLine($"Creating new reaction state for {messageId}");
                _reactionStates[messageId] = new ReactionState { MessageId = messageId };
            }    

            var state = _reactionStates[messageId];

            // Add reaction if not present
            if (!state.Emoji_To_Users.ContainsKey(emoji))
            {
                System.Diagnostics.Debug.WriteLine($"Adding new emoji entry for {emoji}");
                state.Emoji_To_Users[emoji] = new HashSet<string>();
            }

            // If user hasn't reacted with this emoji, add them; otherwise, remove them
            if (!state.Emoji_To_Users[emoji].Contains(userId))
            {
                System.Diagnostics.Debug.WriteLine($"Adding user {userId} to emoji {emoji}");
                state.Emoji_To_Users[emoji].Add(userId);
            } else
            {
                System.Diagnostics.Debug.WriteLine($"Removing user {userId} from emoji {emoji}");
                state.Emoji_To_Users[emoji].Remove(userId);
            }

            // Clean up if no users left for this emoji
            if (state.Emoji_To_Users[emoji].Count == 0)
            {
                System.Diagnostics.Debug.WriteLine($"No users left for emoji {emoji}, removing entry");
                state.Emoji_To_Users.Remove(emoji);
            }

            // Notify UI rebuild
            System.Diagnostics.Debug.WriteLine($"Invoking On_Reaction_Updated for {messageId}");
            On_Reaction_Updated?.Invoke(messageId);
        }

        // Lấy state để UI render
        public ReactionState GetState(string messageId)
        {
            return _reactionStates.ContainsKey(messageId) ? _reactionStates[messageId] : new ReactionState { MessageId = messageId };
        }
    }
}
