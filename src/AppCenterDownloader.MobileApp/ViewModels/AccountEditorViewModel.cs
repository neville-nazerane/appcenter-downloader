using AppCenterDownloader.MobileApp.Models;
using AppCenterDownloader.MobileApp.Services;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCenterDownloader.MobileApp.ViewModels
{
    public partial class AccountEditorViewModel(CentralService service, SourceWallService sourceWall) : ViewModelBase
    {
        private readonly CentralService _service = service;
        private readonly SourceWallService _sourceWall = sourceWall;

        public AddAccountModel Model { get; set; }

        public override void OnNavigatedTo()
        {
            Model.DisplayName = _sourceWall.EditingAccountId;
        }

        [RelayCommand]
        async Task SaveAsync()
        {
            if (Model.DisplayName is not null && Model.ApiKey is not null)
            {
                await _service.AddAsync(Model);

            }
        }

    }
}
