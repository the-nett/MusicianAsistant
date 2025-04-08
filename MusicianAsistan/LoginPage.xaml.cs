
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

            // Aqu� implementar�as la l�gica de autenticaci�n
            // Por ejemplo:
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "Por favor, ingresa tu email y contrase�a", "OK");
                return;
            }

            // Llamada al servicio de autenticaci�n
            // var result = await _authService.LoginAsync(email, password);

            // if (result)
            // {
            //     // Navegar a la p�gina principal
            //     await Shell.Current.GoToAsync("//main");
            // }
            // else
            // {
            //     await DisplayAlert("Error", "Credenciales inv�lidas", "OK");
            // }
        }
    }
}