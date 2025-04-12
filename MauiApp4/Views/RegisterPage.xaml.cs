namespace MauiApp4.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}
    private void OnRegisterClicked(object sender, EventArgs e)
    {
        // For now, just to test it works:
        DisplayAlert("Registro", "Botón de registro clickeado", "OK");
    }

}