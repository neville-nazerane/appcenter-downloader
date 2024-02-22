using AppCenterDownloader.MobileApp.Models;
using AppCenterDownloader.MobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCenterDownloader.MobileApp.ViewModels
{
    public partial class AppsViewModel(CentralService service, SourceWall sourceWall) : ViewModelBase
    {
        private readonly CentralService _service = service;
        private readonly SourceWall _sourceWall = sourceWall;
        [ObservableProperty]
        private ObservableCollection<AccountDisplay> accounts;

        public override async Task OnNavigatedToAsync()
        {
            ViewModelBase.SetLastLocation();
            Accounts = [];

            var res = _service.GetAccountDisplaysAsync();

            await foreach (var account in res)
                Accounts.Add(account);
        }

        [RelayCommand]
        Task AddAsync()
        {
            _sourceWall.EditingAccountId = null;
            return NavigateToAsync("account");
        }

    }
}
