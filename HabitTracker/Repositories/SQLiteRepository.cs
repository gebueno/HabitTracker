using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker.Repositories
{


    public class SQLiteRepository
    {
        private readonly string connectionString = @"Data Source=habits.db";

        public void CreateTable()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var tableCmd = connection.CreateCommand())
                {
                    tableCmd.CommandText =
                        @"CREATE TABLE IF NOT EXISTS yourHabit (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Date TEXT,
                            Quantity INTEGER,
                            Description	TEXT
                            )";

                    tableCmd.ExecuteNonQuery();
                };
            }
        }

        public void Insert(string date, int quantity, string description)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var tableCmd = connection.CreateCommand())
                {
                    tableCmd.CommandText =
                        @"INSERT INTO yourHabit 
                            (Date, Quantity, Description)
                            VALUES 
                            (@date, @quantity, @description)";                    

                    tableCmd.Parameters.AddWithValue("@date", date);
                    tableCmd.Parameters.AddWithValue("@quantity", quantity);
                    tableCmd.Parameters.AddWithValue("@description", description);

                    tableCmd.ExecuteNonQuery();
                };
            }
        }
    }
}
