using AppCenterDownloader.MobileApp.Pages;
using AppCenterDownloader.MobileApp.ViewModels;

namespace AppCenterDownloader.MobileApp.Generated;

public static class GenerationUtils
{
    
   public static IServiceCollection AddGeneratedInjections(this IServiceCollection services)
        => services.AddTransient<AccountEditorPage>()
                   .AddTransient<AppsPage>()
                   .AddTransient<AccountEditorViewModel>()
                   .AddTransient<AppsViewModel>();

}