using Microsoft.Extensions.Logging;
using Supabase.Interfaces;
using Supabase;

namespace MauiApp4;

public static class MauiProgram
{
    public static Client SupabaseClient { get; private set; }
    public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
        // Inicializar Supabase
        SupabaseClient = new Client("https://lemprocedtuvnvxbjoiy.supabase.co", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImxlbXByb2NlZHR1dm52eGJqb2l5Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDMwODY2NzQsImV4cCI6MjA1ODY2MjY3NH0.UBEfQtAUxTXNUpl9cR1B6OMq4Y5QKiRXzjueoa9UvLo");
        return builder.Build();
	}
}
