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
    public partial class ReleasesViewModel(SourceWall sourceWall, CentralService service) : ViewModelBase
    {

        private readonly SourceWall _sourceWall = sourceWall;
        private readonly CentralService _service = service;

        [ObservableProperty]
        ObservableCollection<ReleaseDisplay> releases;

        public override Task OnNavigatedToAsync() => RefreshAsync();

        private async Task RefreshAsync()
        {
            var app = await _sourceWall.GetSelectedAppAsync();

            Releases = [];

            var res = _service.GetReleasesAsync(_sourceWall.SelectedAccountKey, app);

            await foreach (var release in res)
                Releases.Add(release);
        }

        [RelayCommand]
        async Task DownloadAsync(int releaseId, CancellationToken cancellationToken = default)
        {
            var app = await _sourceWall.GetSelectedAppAsync();

            string url = await _service.GetDownloadableUrlAsync(_sourceWall.SelectedAccountKey, app, releaseId, cancellationToken);
            await Browser.OpenAsync(url);
        }

        public override bool OnBack()
        {
            _ = NavigateToLastLocationAsync();
            return false;
        }

    }
}
