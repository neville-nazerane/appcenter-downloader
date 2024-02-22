using AppCenterDownloader.MobileApp.Models;
using AppCenterDownloader.MobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCenterDownloader.MobileApp.ViewModels
{
    public partial class AppsViewModel(CentralService service) : ViewModelBase
    {
        private readonly CentralService _service = service;

        [ObservableProperty]
        private ObservableCollection<AccountDisplay> accounts;

        public override async Task OnNavigatedToAsync()
        {
            Accounts = [];

            var res = _service.GetAccountDisplaysAsync();

            await foreach (var account in res)
                Accounts.Add(account);
        }



    }
}
