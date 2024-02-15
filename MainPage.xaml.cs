namespace fgstm
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnLoginClicked(object sender, EventArgs e)
        {
            // Hardcoded username and password for demonstration
            string hardcodedUsername = "demo";
            string hardcodedPassword = "password";

            // Get the username and password entered by the user
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            // Check if the entered credentials match the hardcoded values
            if (username == hardcodedUsername && password == hardcodedPassword)
            {
                // Authentication successful
                DisplayAlert("Success", "Login successful!", "OK");
            }
            else
            {
                // Authentication failed
                DisplayAlert("Error", "Invalid username or password", "OK");
            }
        }
    }
}