using Microsoft.Data.Sqlite;

namespace fgstm
{
    public partial class MainPage : ContentPage
    {
        private const string DatabasePath = "UserData.db"; // Path to your SQLite database file

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            // Authenticate user against SQLite database
            bool isAuthenticated = AuthenticateUserFromDatabase(username, password);

            if (isAuthenticated)
            {
                await DisplayAlert("Success", "Login successful!", "OK");
                // Navigate to the next page or perform other actions
            }
            else
            {
                await DisplayAlert("Error", "Invalid username or password", "OK");
            }
        }

        private bool AuthenticateUserFromDatabase(string username, string password)
        {
            // Construct connection string
            string connectionString = $"Data Source={DatabasePath}";

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
    }
}
