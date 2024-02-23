using AppCenterDownloader.MobileApp.Generated;
using AppCenterDownloader.MobileApp.Services;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using LiteDB;
using Microsoft.Extensions.Logging;

namespace AppCenterDownloader.MobileApp
{
    public static class MauiProgram
    {

        public static readonly HttpClient _httpClient = new()
        {
            BaseAddress = new("https://api.appcenter.ms")
        };

        private static IServiceProvider services;

        public static IServiceProvider Services => services;

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

            string dbLocation = Path.Combine(FileSystem.AppDataDirectory, "data.db");

            builder.Services
                
                    .AddTransient(p => new AppCenterClientProvider(_httpClient))
                    .AddSingleton<SourceWall>()
                    .AddTransient<LocalRepository>()
                    .AddSingleton<ILiteDatabase>(p => new LiteDatabase(dbLocation))
                    .AddTransient<CentralService>()

                    .AddGeneratedInjections();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            var built = builder.Build();
            services = built.Services;
            return built;
        }
    }
}
