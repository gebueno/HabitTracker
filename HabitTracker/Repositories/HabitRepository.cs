﻿using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;

namespace HabitTracker.Repositories
{
    public class HabitRepository
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

        public void UpdateQuantity(int habitId, int quantity)
        {
            using (var connection = new SqliteConnection(connectionString))
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
            using (var connection = new SqliteConnection(connectionString))
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
            using (var connection = new SqliteConnection(connectionString))
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
            using (var connection = new SqliteConnection(connectionString))
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
        public List<string> GetList()
        {
            List<string> habits = new List<string>();

            using (var connection = new SqliteConnection(connectionString))
            {
                using (var tableCmd = connection.CreateCommand())
                {
                    tableCmd.CommandText = @" SELECT * FROM yourHabit";
                    tableCmd.CommandType = CommandType.Text;
                    SqliteDataReader sqlReader = tableCmd.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        habits.Add(Convert.ToString(sqlReader["records"]));
                    }
                };
            }
            return habits;
        }
    }
}