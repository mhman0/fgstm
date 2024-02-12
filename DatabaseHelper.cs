using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace fgstm
{
    internal class DatabaseHelper
    {
        private readonly string connectionString = "Data Source=famguard.db";

        public void InsertTestUsers()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var insertCommand = connection.CreateCommand();
                insertCommand.CommandText = @"
                    INSERT INTO Users (FirstName, LastName, Username, Password, DateOfBirth)
                    VALUES ('John', 'Doe', 'johndoe', 'password123', '1990-01-01');

                    INSERT INTO Users (FirstName, LastName, Username, Password, DateOfBirth)
                    VALUES ('Jane', 'Smith', 'janesmith', 'abc123', '1985-05-15');

                    -- Add more INSERT commands for additional test users...
                ";

                insertCommand.ExecuteNonQuery();
            }
        }
    }
}
