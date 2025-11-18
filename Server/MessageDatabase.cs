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
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL,
                    Message TEXT,
                    Address TEXT NOT NULL,
                    Port TEXT NOT NULL,
                    ProfileImagePath TEXT,
                    TimeSent DATETIME DEFAULT CURRENT_TIMESTAMP
                );
                
                CREATE TABLE IF NOT EXISTS Attachments (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    MessageId INTEGER NOT NULL,
                    FileName TEXT NOT NULL,
                    IsImage BOOLEAN NOT NULL,
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
                        INSERT INTO Messages (Username, Message, Address, Port, ProfileImagePath, TimeSent)
                        VALUES (@Username, @Message, @Address, @Port, @ProfileImagePath, @TimeSent);
                        SELECT last_insert_rowid();
                        ";
                        long messageId;
                        using (var command = new SQLiteCommand(insertMessageSql, connection))
                        {
                            command.Parameters.AddWithValue("@Username", chatMessage.Username);
                            command.Parameters.AddWithValue("@Message", chatMessage.Message);
                            command.Parameters.AddWithValue("@Address", chatMessage.Address);
                            command.Parameters.AddWithValue("@Port", chatMessage.Port);
                            command.Parameters.AddWithValue("@ProfileImagePath", chatMessage.ProfileImagePath);
                            command.Parameters.AddWithValue("@TimeSent", chatMessage.TimeSent);
                            messageId = (long)command.ExecuteScalar();
                        }
                        string insertAttachmentSql = @"
                        INSERT INTO Attachments (MessageId, FileName, IsImage)
                        VALUES (@MessageId, @FileName, @IsImage);
                        ";
                        foreach (var attachment in chatMessage.Attachments)
                        {
                            using (var command = new SQLiteCommand(insertAttachmentSql, connection))
                            {
                                command.Parameters.AddWithValue("@MessageId", messageId);
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
                SELECT Id, Username, Message, Address, Port, ProfileImagePath, TimeSent
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
                                Username = reader.GetString(1),
                                Message = reader.GetString(2),
                                Address = reader.GetString(3),
                                Port = reader.GetString(4),
                                ProfileImagePath = reader.IsDBNull(5) ? null : reader.GetString(5),
                                TimeSent = reader.GetDateTime(6),
                                Attachments = new Protocol.Attachment[] { }
                            };
                            long messageId = reader.GetInt64(0);
                            // Fetch attachments
                            string selectAttachmentsSql = @"
                            SELECT FileName, IsImage
                            FROM Attachments
                            WHERE MessageId = @MessageId;
                            ";
                            using (var attachmentCommand = new SQLiteCommand(selectAttachmentsSql, connection))
                            {
                                attachmentCommand.Parameters.AddWithValue("@MessageId", messageId);
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
                        messages.Add(chatMessage);
                        }
                    }
                }
            }
            return messages.ToArray();
        }
    }
}
