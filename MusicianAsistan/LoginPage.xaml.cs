
namespace MusicianAsistan
{

    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            // Aquí implementarías la lógica de autenticación
            // Por ejemplo:
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "Por favor, ingresa tu email y contraseña", "OK");
                return;
            }

            // Llamada al servicio de autenticación
            // var result = await _authService.LoginAsync(email, password);

            // if (result)
            // {
            //     // Navegar a la página principal
            //     await Shell.Current.GoToAsync("//main");
            // }
            // else
            // {
            //     await DisplayAlert("Error", "Credenciales inválidas", "OK");
            // }
        }
    }
}