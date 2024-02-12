using Microsoft.Data.SqlClient;
using Security;
using Xamarin.Forms;

namespace fgstm
{
    public partial class MainPage : ContentPage
    {
        private const string ConnectionString = "Your_SQL_Connection_String_Here";

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            // Authenticate user against SQL database
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
            using (var connection = new SqlConnection(ConnectionString))


