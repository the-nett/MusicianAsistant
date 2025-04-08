namespace MauiApp4.Views;

public partial class WelcomePage : ContentPage
{
	public WelcomePage(string nombrePersona)
	{
		InitializeComponent();
        WelcomeLabel.Text = $"Bienvenido, {nombrePersona}";
    }
}