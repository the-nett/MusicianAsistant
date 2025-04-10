using MauiApp4.Services;

namespace MauiApp4.Views;

public partial class WelcomePage : ContentPage
{
    private readonly ApiDatabaseService _apiDatabaseService;
    private readonly DatabaseService _databaseService;

    public WelcomePage(string nombrePersona)
    {
        InitializeComponent();
        WelcomeLabel.Text = $"Bienvenido, {nombrePersona}";

        // Instantiate services manually
        var apiService = new ApiService();
        _databaseService = new DatabaseService();
        _apiDatabaseService = new ApiDatabaseService(apiService, _databaseService);
    }

    private async void OntraerGenerosClicked(object sender, EventArgs e)
    {
        try
        {
            // Get the token from SecureStorage
            var accessToken = await SecureStorage.GetAsync("accessToken");

            if (string.IsNullOrEmpty(accessToken))
            {
                await DisplayAlert("Error", "No se encontró el token de acceso. Por favor, inicia sesión.", "OK");
                return;
            }

            await _apiDatabaseService.SyncGendersAsync(accessToken);
            var genders = await _databaseService.GetGendersAsync();

            await DisplayAlert("Éxito", "Géneros sincronizados correctamente.", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
        }
    }
}
