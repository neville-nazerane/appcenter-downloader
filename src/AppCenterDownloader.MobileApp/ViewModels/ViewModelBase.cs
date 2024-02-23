using AppCenterDownloader.MobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCenterDownloader.MobileApp.ViewModels
{
    public abstract class ViewModelBase : ObservableObject
    {

        public virtual void OnNavigatedTo() { }

        public virtual Task OnNavigatedToAsync() => Task.CompletedTask;

        public virtual bool OnBack() => false;

        public static void SetLastLocation() => SourceWall.LastLocation = Shell.Current.CurrentState.Location.OriginalString.Replace("//", string.Empty);

        public static Task GoToLastLocationAsync() => NavigateToAsync(SourceWall.LastLocation);

        public static Task NavigateToAsync(string path) => Shell.Current.GoToAsync($"//{path}");

        public static Task DisplayMessageAsync(string title, string message)
            => Shell.Current.DisplayAlert(title, message, "OK");

    }
}
