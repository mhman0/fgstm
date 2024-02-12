using Microsoft.Data.Sqlite;
using System;
using System.IO;
using Xamarin.Essentials;

public partial class MainPage : ContentPage
{
    private const string DatabaseFileName = "FAMGUARD.db"; // Name of your SQLite database file
    private readonly string DatabasePath = Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName); // Full path to the database file

    private bool AuthenticateUserFromDatabase(string username, string password)
    {
        try
        {
            // Construct connection string
            string connectionString = $"Data Source={DatabasePath}";

            // Open connection and execute query
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                // Execute SQL command to query user data
                var command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                // Execute the command and check if the user exists
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error accessing database: {ex.Message}");
            return false;
        }
    }
}
