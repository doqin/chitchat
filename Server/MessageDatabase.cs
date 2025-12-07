using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Server
{
    internal class MessageDatabase
    {
        static private string connectionString = "Data Source=messages.sqlite;Version=3;";

        public static void CreateIfNotExist()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                Console.WriteLine("Creating or opening messages table...");
                connection.Open();
                string tableSql = @"
                CREATE TABLE IF NOT EXISTS Messages (
                    Id STRING PRIMARY KEY,
                    Username TEXT NOT NULL,
                    Message TEXT,
                    Address TEXT NOT NULL,
                    ProfileImagePath TEXT,
                    TimeSent DATETIME DEFAULT CURRENT_TIMESTAMP
                );
                
                CREATE TABLE IF NOT EXISTS Attachments (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    MessageId STRING NOT NULL,
                    FileName TEXT NOT NULL,
                    IsImage BOOLEAN NOT NULL,
                    FOREIGN KEY(MessageId) REFERENCES Messages(Id)
                );

                CREATE TABLE IF NOT EXISTS Reactions (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    MessageId STRING NOT NULL,
                    Emoji TEXT NOT NULL,
                    UserId TEXT NOT NULL,
                    FOREIGN KEY(MessageId) REFERENCES Messages(Id)
                );
                ";
                using (var command = new SQLiteCommand(tableSql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void InsertMessage(Protocol.ChatMessage chatMessage)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        string insertMessageSql = @"
                        INSERT INTO Messages (Id, Username, Message, Address, ProfileImagePath, TimeSent)
                        VALUES (@Id, @Username, @Message, @Address, @ProfileImagePath, @TimeSent);
                        ";
                        using (var command = new SQLiteCommand(insertMessageSql, connection))
                        {
                            command.Parameters.AddWithValue("@Id", chatMessage.Id);
                            command.Parameters.AddWithValue("@Username", chatMessage.Username);
                            command.Parameters.AddWithValue("@Message", chatMessage.Message);
                            command.Parameters.AddWithValue("@Address", chatMessage.Address);
                            command.Parameters.AddWithValue("@ProfileImagePath", chatMessage.ProfileImagePath);
                            command.Parameters.AddWithValue("@TimeSent", chatMessage.TimeSent);
                            command.ExecuteNonQuery();
                        }
                        string insertAttachmentSql = @"
                        INSERT INTO Attachments (MessageId, FileName, IsImage)
                        VALUES (@MessageId, @FileName, @IsImage);
                        ";
                        foreach (var attachment in chatMessage.Attachments)
                        {
                            using (var command = new SQLiteCommand(insertAttachmentSql, connection))
                            {
                                command.Parameters.AddWithValue("@MessageId", chatMessage.Id);
                                command.Parameters.AddWithValue("@FileName", attachment.FileName);
                                command.Parameters.AddWithValue("@IsImage", attachment.IsImage);
                                command.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting message to database: {ex.Message}");
                // Consider logging or retrying
            }
        }

        public static Protocol.ChatMessage[] GetMessagesSince(int n, DateTime before)
        {
            List<Protocol.ChatMessage> messages = new List<Protocol.ChatMessage>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectMessagesSql = @"
                SELECT Id, Username, Message, Address, ProfileImagePath, TimeSent
                FROM Messages
                WHERE TimeSent < @Before
                ORDER BY TimeSent DESC
                LIMIT @Limit;
                ";
                using (var command = new SQLiteCommand(selectMessagesSql, connection))
                {
                    command.Parameters.AddWithValue("@Before", before);
                    command.Parameters.AddWithValue("@Limit", n);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var chatMessage = new Protocol.ChatMessage
                            {
                                Id = reader.GetString(0),
                                Username = reader.GetString(1),
                                Message = reader.GetString(2),
                                Address = reader.GetString(3),
                                ProfileImagePath = reader.IsDBNull(4) ? null : reader.GetString(4),
                                TimeSent = reader.GetDateTime(5),
                                Attachments = new Protocol.Attachment[] { }
                            };
                            // Fetch attachments
                            string selectAttachmentsSql = @"
                            SELECT FileName, IsImage
                            FROM Attachments
                            WHERE MessageId = @MessageId;
                            ";
                            using (var attachmentCommand = new SQLiteCommand(selectAttachmentsSql, connection))
                            {
                                attachmentCommand.Parameters.AddWithValue("@MessageId", chatMessage.Id);
                                using (var attachmentReader = attachmentCommand.ExecuteReader())
                                {
                                    List<Protocol.Attachment> attachments = new List<Protocol.Attachment>();
                                    while (attachmentReader.Read())
                                    {
                                        var attachment = new Protocol.Attachment
                                        {
                                            FileName = attachmentReader.GetString(0),
                                            IsImage = attachmentReader.GetBoolean(1)
                                        };
                                        attachments.Add(attachment);
                                    }
                                    chatMessage.Attachments = attachments.ToArray();
                                }
                            }

                            // Fetch reactions
                            string selectReactionsSql = @"
                            SELECT Emoji, UserId
                            FROM Reactions
                            WHERE MessageId = @MessageId;
                            ";
                            using (var reactionCommand = new SQLiteCommand(selectReactionsSql, connection))
                            {
                                reactionCommand.Parameters.AddWithValue("@MessageId", chatMessage.Id);
                                using (var reactionReader = reactionCommand.ExecuteReader())
                                {
                                    Protocol.ReactionState reactionState = new Protocol.ReactionState(chatMessage.Id);
                                    while (reactionReader.Read())
                                    {
                                        if (reactionState.Emoji_To_Users == null)
                                        {
                                            reactionState.Emoji_To_Users = new Dictionary<string, HashSet<string>>();
                                        }
                                        string emoji = reactionReader.GetString(0);
                                        string userId = reactionReader.GetString(1);
                                        if (!reactionState.Emoji_To_Users.ContainsKey(emoji))
                                        {
                                            reactionState.Emoji_To_Users[emoji] = new HashSet<string>();
                                        }
                                        reactionState.Emoji_To_Users[emoji].Add(userId);
                                    }
                                    chatMessage.ReactionState = reactionState;
                                }
                            }
                            messages.Add(chatMessage);
                        }
                    }
                }
            }
            return messages.ToArray();
        }

        public static void InsertOrRemoveReaction(string messageId, string emoji, string userId)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                // Check if reaction exists
                string checkSql = @"
                SELECT COUNT(*) FROM Reactions
                WHERE MessageId = @MessageId AND Emoji = @Emoji AND UserId = @UserId;
                ";
                using (var checkCommand = new SQLiteCommand(checkSql, connection))
                {
                    checkCommand.Parameters.AddWithValue("@MessageId", messageId);
                    checkCommand.Parameters.AddWithValue("@Emoji", emoji);
                    checkCommand.Parameters.AddWithValue("@UserId", userId);
                    long count = (long)checkCommand.ExecuteScalar();
                    if (count > 0)
                    {
                        // Reaction exists, remove it
                        string deleteSql = @"
                        DELETE FROM Reactions
                        WHERE MessageId = @MessageId AND Emoji = @Emoji AND UserId = @UserId;
                        ";
                        using (var deleteCommand = new SQLiteCommand(deleteSql, connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@MessageId", messageId);
                            deleteCommand.Parameters.AddWithValue("@Emoji", emoji);
                            deleteCommand.Parameters.AddWithValue("@UserId", userId);
                            deleteCommand.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Reaction does not exist, insert it
                        string insertSql = @"
                        INSERT INTO Reactions (MessageId, Emoji, UserId)
                        VALUES (@MessageId, @Emoji, @UserId);
                        ";
                        using (var insertCommand = new SQLiteCommand(insertSql, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@MessageId", messageId);
                            insertCommand.Parameters.AddWithValue("@Emoji", emoji);
                            insertCommand.Parameters.AddWithValue("@UserId", userId);
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}
