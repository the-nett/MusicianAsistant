using Supabase.Gotrue;
using MauiApp4;
using System.Diagnostics;
using MauiApp4.Models;

public class AuthService
{
    private readonly Supabase.Client _supabaseClient;

    public AuthService()
    {
        _supabaseClient = MauiProgram.SupabaseClient;
    }

    public async Task<bool> SignInWithGoogle()
    {
        try {
            await _supabaseClient.Auth.SignOut();
            // Obtener la URL de autenticación con Google
            var providerAuthState = await _supabaseClient.Auth.SignIn(Constants.Provider.Google);

            if (providerAuthState?.Uri == null)
                return false;

            var authUrl = providerAuthState.Uri.ToString();

            // Iniciar el proceso de autenticación en el navegador
            WebAuthenticatorResult authResult = await WebAuthenticator.Default.AuthenticateAsync(
                new Uri(authUrl),
                new Uri("com.tuapp://") // Debe coincidir con Supabase
            );
            string accessToken = authResult?.AccessToken;

            if (string.IsNullOrEmpty(accessToken))
                return false;

            // Guardamos el token si quieres persistir sesión
            await SecureStorage.SetAsync("accessToken", accessToken);

            // Llamamos a la API para verificar el usuario
            var apiService = new ApiService();
            var response = await apiService.GetAsync<ProfileResponse>("api/Profiles/verify-user", accessToken);


            if (response != null && response.Exists)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new MauiApp4.Views.WelcomePage(response.FullName));
                return true;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Usuario no encontrado", "No se encontró un perfil asociado.", "OK");
                return false;
            }

        }
        catch (Exception ex)
        {
            // Manejo de errores
            Debug.WriteLine($"Error al iniciar sesión: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> LogOutWithGoogle()
    {
        try
        {
            await _supabaseClient.Auth.SignOut();
            return true;
        }
        catch (Exception ex)
        {
            // Manejo de errores
            Debug.WriteLine($"Error al cerrar sesión: {ex.Message}");
            return false;
        }
    }
}
