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
    public partial class AccountEditorViewModel(CentralService service, SourceWall sourceWall) : ViewModelBase
    {
        private readonly CentralService _service = service;
        private readonly SourceWall _sourceWall = sourceWall;

        public AddAccountModel Model { get; set; }

        public override void OnNavigatedTo()
        {
            var str = Shell.Current.CurrentState.Location;
            if (_sourceWall.EditingAccountId is not null)
            {
                Model.Key = _sourceWall.EditingAccountId;
                Model.DisplayName = _service.GetAccountDisplayName(_sourceWall.EditingAccountId);
            }
            else
            {
                Model = new();
            }
        }

        [RelayCommand]
        async Task SaveAsync()
        {
            if (!string.IsNullOrEmpty(Model.DisplayName) && !string.IsNullOrEmpty(Model.ApiKey))
                await _service.Upsert(Model);
        }

    }
}
