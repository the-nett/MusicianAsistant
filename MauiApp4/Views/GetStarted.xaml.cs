
namespace MauiApp4.Views;

public partial class GetStarted : ContentPage
{
	public GetStarted()
	{
		InitializeComponent();
	}
	private void OnGetStartedClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}