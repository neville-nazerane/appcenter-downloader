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
    public partial class AccountEditorViewModel(CentralService service)
    {
        private readonly CentralService _service = service;

        public AddAccountModel Model { get; set; }

        [RelayCommand]
        async Task SaveAsync()
        {
            await _service.AddAsync(Model);
        }

    }
}
