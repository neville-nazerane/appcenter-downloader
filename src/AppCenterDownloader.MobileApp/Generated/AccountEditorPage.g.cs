using AppCenterDownloader.MobileApp.Pages;
using AppCenterDownloader.MobileApp.ViewModels;

namespace AppCenterDownloader.MobileApp.Pages;

public partial class AccountEditorPage 
{
    
    private AccountEditorViewModel viewModel = null;

    public AccountEditorViewModel ViewModel
    {
        get
        {
            SetupViewModelIfNotAlready();
            return viewModel;
        }
    }

    private void SetupViewModelIfNotAlready()
    {
        if (viewModel is null)
        {
            viewModel = Shell.Current.Handler.MauiContext.Services.GetService<AccountEditorViewModel>();
            BindingContext = viewModel;
        }
    }


    protected override async bool OnBackButtonPressed()
    {
        OnBackButtonPressedInternal();
        var res1 =  ViewModel.OnBack();
        if (!res1) return false;
        var res2 = await ViewModel.OnBackAsync();
        if (!res2) return false;

        return base.OnBackButtonPressed();
    }

    partial void OnBackButtonPressedInternal();


    protected override async void OnNavigatedTo(Microsoft.Maui.Controls.NavigatedToEventArgs args)
    {
        OnNavigatedToInternal();
         ViewModel.OnNavigatedTo();
        await ViewModel.OnNavigatedToAsync();

        base.OnNavigatedTo(args);
    }

    partial void OnNavigatedToInternal();


    protected override void OnAppearing()
    {
        SetupViewModelIfNotAlready();
        OnAppearingInternal();

        base.OnAppearing();
    }

    partial void OnAppearingInternal();


}