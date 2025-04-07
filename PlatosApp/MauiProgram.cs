using Microsoft.Extensions.Logging;
using PlatosApp.Helpers;
using PlatosApp.Pages;

namespace PlatosApp
{
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

            builder.Services.AddHttpClient<IRestClient, RestClient>();
            builder.Services.Decorate<IRestClient, RestClientDecorator>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<PlatoFormPage>();

            return builder.Build();
        }
    }
}
