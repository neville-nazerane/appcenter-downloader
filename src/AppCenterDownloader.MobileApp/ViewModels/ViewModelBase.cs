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


        public Task NavigateToAsync(string path)
            => Shell.Current.GoToAsync($"//{path}");

    }
}
