using TCC_App.Platforms.Android.Services;
using TCC_App.Services;

namespace TCC_App;

public static class MauiProgram
{
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

		builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();

        builder.Services.AddSingleton<MainPage>();

        return builder.Build();
	}
}