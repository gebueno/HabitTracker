using HabitTracker.Business;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using HabitTracker.Models;
using System.Globalization;
using System.Threading.Tasks;

namespace HabitTracker.Repositories
{
    public class HabitRepository
    {
        public static SqliteConnection GetConnection()
        {
            string connectionString = @"Data Source=habits.db";

            SqliteConnection connection = new SqliteConnection(connectionString);
            connection.Open();
            return connection;
        }

        public void CreateTable()
        {
            using (SqliteConnection connection  = GetConnection())
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
            using (SqliteConnection connection = GetConnection())
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

        public void UpdateQuantity(int habitId, int quantity)
        {
            using (SqliteConnection connection = GetConnection())
            {
                using (var tableCmd = connection.CreateCommand())
                {
                    tableCmd.CommandText =
                        @"UPDATE yourHabit 
                            SET Quantity = @quantity
                            WHERE Id = @id";

                    tableCmd.Parameters.AddWithValue("@id", habitId);
                    tableCmd.Parameters.AddWithValue("@quantity", quantity);

                    tableCmd.ExecuteNonQuery();
                };
            }
        }

        public void UpdateDescription(int habitId, string description)
        {
            using (SqliteConnection connection = GetConnection())
            {
                using (var tableCmd = connection.CreateCommand())
                {
                    tableCmd.CommandText =
                        @"UPDATE yourHabit 
                            SET Description = @description
                            WHERE Id = @id";

                    tableCmd.Parameters.AddWithValue("@id", habitId);
                    tableCmd.Parameters.AddWithValue("@description", description);

                    tableCmd.ExecuteNonQuery();
                };
            }
        }

        public void Delete(int habitId)
        {
            using (SqliteConnection connection = GetConnection())
            {
                using (var tableCmd = connection.CreateCommand())
                {
                    tableCmd.CommandText =
                        @"DELETE FROM yourHabit                            
                            WHERE Id = @id";

                    tableCmd.Parameters.AddWithValue("@id", habitId);

                    tableCmd.ExecuteNonQuery();
                };
            }
        }

        public void Get(int habitId)
        {
            using (SqliteConnection connection = GetConnection())
            {
                using (var tableCmd = connection.CreateCommand())
                {
                    tableCmd.CommandText =
                        @"SELECT Date, Quantity, Description
                            FROM yourHabit
                            WHERE Id = @id";

                    tableCmd.Parameters.AddWithValue("@id", habitId);

                    tableCmd.ExecuteNonQuery();
                };
            }
        }

        public List<Habit> GetList()
        {
            SqliteConnection connection = GetConnection();
            var tableCmd = connection.CreateCommand();
            
            List<Habit> tableData = new List<Habit>();
            tableCmd.CommandText = @" SELECT * FROM yourHabit";
            tableCmd.CommandType = CommandType.Text;
            SqliteDataReader sqlReader = tableCmd.ExecuteReader();

            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    tableData.Add(
                        new Habit()
                        {
                            Id = sqlReader.GetInt32(0),
                            Date = DateTime.Now.ToString("MM/dd/yyyy"),
                            Quantity = sqlReader.GetInt32(2),
                            Description = sqlReader.GetString(3)
                        });
                }
            }            
            return tableData;
        }
    }
}
