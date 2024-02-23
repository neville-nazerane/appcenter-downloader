using AppCenterDownloader.MobileApp.Services;
using AppCenterDownloader.MobileApp.ViewModels;

namespace AppCenterDownloader.MobileApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            var current = Current.CurrentState.Location.OriginalString.Replace("//", string.Empty);
            if (current != SourceWall.LastLocation)
            {
                Current.GoToAsync($"//{SourceWall.LastLocation}");
                return true;
            }
            return base.OnBackButtonPressed();
        }

    }
}
