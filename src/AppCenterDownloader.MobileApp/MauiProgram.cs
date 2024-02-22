using AppCenterDownloader.MobileApp.Generated;
using AppCenterDownloader.MobileApp.Services;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using Microsoft.Extensions.Logging;

namespace AppCenterDownloader.MobileApp
{
    public static class MauiProgram
    {

        public static readonly HttpClient _httpClient = new()
        {
            BaseAddress = new("https://api.appcenter.ms")
        };

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()

                .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitMarkup()

                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            builder.Services
                
                    .AddTransient(p => new AppCenterClientProvider(_httpClient))
                    .AddSingleton<SourceWallService>()
                    .AddSingleton<LocalRepository>()
                    .AddTransient<CentralService>()

                    .AddGeneratedInjections();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
