using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EmbedIO;
using EmbedIO.Actions;
using EmbedIO.Utilities;
using EmbedIO.WebApi;
using System.Data.SQLite;
using Note_Tote.Classes;
using System.Diagnostics;
using Swan;

namespace Note_Tote.DB
{
    public class SQLServer 
    {
        enum NoteTemplate
        {
            Id,
            Title,
            Content,
            StartDate,
            DueDate
        }

        //source is in the string. all notes will be saved in Notes.db
        static string connectionString = "Data Source=Notes.db;" +
            "Mode=ReadWriteCreate;Cache=Shared;" +
            "Recursive Triggers=False;Pooling=True";
        public SQLServer()
        {
            Debug.WriteLine("SQLServer initialized");
            CheckForNotesTable();
            Debug.WriteLine("batteries initialized");
            dbTest();
        }

        private static void CreateTable()
        {
            using(var connection = new SQLiteConnection(connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"CREATE TABLE if NOT EXISTS notes(
                            Id TEXT NOT NULL PRIMARY KEY,
                            NoteName TEXT NOT NULL,
                            StartDate TEXT,
                            DueDate TEXT,
                            NoteDesc TEXT);";

                    cmd.ExecuteNonQuery();

                    Debug.WriteLine("Table Was Created");
                }
            }
            
        }

        /// <summary>
        /// Opens a connection to the database
        /// checks if the notes table exists
        /// creates the table if it dosent
        /// provides feedback
        /// </summary>
        private static void CheckForNotesTable()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                bool tableExists;
                using (var checkCmd = connection.CreateCommand())
                {
                    checkCmd.CommandText = @"SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name='notes'";
                    var result = checkCmd.ExecuteScalar();
                    
                    tableExists = Convert.ToInt32(result) > 0;
                    if (!tableExists)
                    {
                        CreateTable();
                    }
                    else
                    {
                        Debug.WriteLine("Table Exists");
                    }
                }
            }
        }
        
        public static void dbTest()
        {
            try
            {
                var conn = new SQLiteConnection("Data Source=Notes.db");
                Debug.WriteLine("Constructed successfully.");
                conn.Open();
                Debug.WriteLine("Opened successfully.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("❌ Exception: " + ex.ToString());
            }

        }
        public static void RunQuery()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"PRAGMA table_info(notes)";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cid = reader.GetInt32(0);
                            var name = reader.GetString(1);
                            var type = reader.GetString(2);
                            var notNull = reader.GetInt32(3);
                            var defaultValue = reader.IsDBNull(4) ? "NULL" : reader.GetString(4);
                            var isPrimaryKey = reader.GetInt32(5);

                            Console.WriteLine($"Column: {name}, Type: {type}, NotNull: {notNull}, Default: {defaultValue}, PrimaryKey: {isPrimaryKey}");
                        }
                    }
                }
            }
        }

        public static void ListTables()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT name FROM sqlite_master WHERE type='table';";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tableName = reader.GetString(0);
                            Console.WriteLine($"Table: {tableName}");
                        }
                    }
                }
            }
        }
        public static void CreateRow(Note newNote)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"INSERT INTO notes (Id, NoteName, StartDate, DueDate, NoteDesc)
                            VALUES ($id, $noteName, $startDate, $dueDate, $noteDesc)";
                        cmd.Parameters.AddWithValue("$id", newNote.Id);
                        cmd.Parameters.AddWithValue("$noteName", newNote.NoteName);
                        cmd.Parameters.AddWithValue("$startDate", newNote.StartDate);
                        cmd.Parameters.AddWithValue("$dueDate", newNote.DueDate);
                        cmd.Parameters.AddWithValue("$noteDesc", newNote.NoteDesc);

                        int rows = cmd.ExecuteNonQuery();
                        Debug.WriteLine($"{rows} rows added to the table");
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ErrorHandling.CatchException(ex));
                throw;
            }
        }

        public static List<Note> ReadDb()
        {
            List<Note> noteList = new List<Note>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, NoteName, StartDate, DueDate, NoteDesc FROM notes";
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string id = reader.GetString(0);
                        string noteName = reader.GetString(1);
                        DateTime startDate;
                        DateTime dueDate;
                        string noteDesc = reader.GetString(4);

                        if (!reader.IsDBNull(2))
                        {
                            startDate = reader.GetDateTime(2);
                        }
                        else
                        {
                            startDate = DateTime.MinValue;
                        }

                        if (!reader.IsDBNull(3))
                        {
                            dueDate = reader.GetDateTime(3);
                        }
                        else
                        {
                            dueDate = DateTime.MinValue;
                        }

                        var note = new Note
                        {
                            Id = id,
                            NoteName = noteName,
                            StartDate = startDate,
                            DueDate = dueDate,
                            NoteDesc = noteDesc
                        };
                        noteList.Add(note);
                    }
                }
            }
            return noteList ?? throw new ArgumentException();
        }

        public static void UpdateRow(string rowId, Note newNote)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using(var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = $@"UPDATE notes 
                            SET NoteName={newNote.NoteName} 
                            StartDate={newNote.StartDate}
                            DueDate={newNote.DueDate}
                            NoteDesc={newNote.NoteDesc}";
                        try
                        {
                            cmd.ExecuteNonQuery();
                            Debug.WriteLine("Successfully Updated");
                        }catch(Exception e)
                        {
                            Debug.WriteLine(e.Message.ToString());
                        }
                    }
                }
            }catch(Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }

        public static void DeleteRow(string rowId)
        {
            using(var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using(var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = $@"DELETE FROM notes WHERE Id = '{rowId}'";

                    try
                    {
                        cmd.ExecuteNonQuery();
                        Debug.WriteLine("Delete Successful!");
                    }
                    catch(Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
            }
        }
    }
}
