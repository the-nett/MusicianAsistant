using System;
using Microsoft.Maui.Controls;

namespace MauiApp4
{
    public partial class MainPage : ContentPage
    {
        private readonly AuthService _authService;
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            _authService = new AuthService();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            // Intentar logear con Google
            bool success = await _authService.SignInWithGoogle();

            if (success)
            {
                await DisplayAlert("Alert", "Inicio de sesión exitoso", "OK");
            }
            else
            {
                await DisplayAlert("Alert", "error en inicio de sesion", "OK");
            }

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
        private async void OnLogoutClicked(object sender, EventArgs e)
        {

            // Intentar logear con Google
            bool success = await _authService.LogOutWithGoogle();

            if (success)
            {
                await DisplayAlert("Alert", "You have been logged out", "OK");
            }
            else
            {
                await DisplayAlert("Alert", "Error logging out", "OK");
            }
        }
    }
}
