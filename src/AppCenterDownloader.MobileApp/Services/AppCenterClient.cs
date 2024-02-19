using AppCenterDownloader.MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppCenterDownloader.MobileApp.Services
{
    public partial class AppCenterClient(HttpClient httpClient, string apiKey)
    {

        [GeneratedRegex(@"^v\d+\.\d+\/")]
        private static partial Regex VersionedRegex();

        private readonly HttpClient _httpClient = httpClient;
        private readonly string _apiKey = apiKey;

        public Task<IEnumerable<Organization>> GetOrganizationsAsync(CancellationToken cancellationToken = default) => GetFromJsonAsync<IEnumerable<Organization>>("orgs", cancellationToken);

        public Task<IEnumerable<AppCenterApp>> GetAppsAsync(CancellationToken cancellationToken = default) => GetFromJsonAsync<IEnumerable<AppCenterApp>>("apps?orderBy=display_name", cancellationToken);

        public Task<IEnumerable<AppCenterRelease>> GetReleasesAsync(string owner_name,
                                                                   string app_name,
                                                                   int limit,
                                                                   CancellationToken cancellationToken = default) 
            => GetFromJsonAsync<IEnumerable<AppCenterRelease>>($"apps/{owner_name}/{app_name}/releases?top={limit}", cancellationToken);

        public Task<ReleaseInfo> GetReleaseInfoAsync(string owner_name,
                                                     string app_name, 
                                                     int releaseId, 
                                                     CancellationToken cancellationToken = default)
            => GetFromJsonAsync<ReleaseInfo>($"apps/{owner_name}/{app_name}/releases/{releaseId}", cancellationToken);

        public Task<ReleaseInfo> GetLatestReleaseInfoAsync(string owner_name,
                                                           string app_name,
                                                           CancellationToken cancellationToken = default)
            => GetFromJsonAsync<ReleaseInfo>($"apps/{owner_name}/{app_name}/releases/latest", cancellationToken);

        private async Task<TResult> GetFromJsonAsync<TResult>(string path, CancellationToken cancellationToken = default)
        {
            if (!VersionedRegex().IsMatch(path))
                path = $"v0.1/{path}";

            var request = new HttpRequestMessage(HttpMethod.Get, path);
            request.Headers.Add("X-API-Token", _apiKey);

            using var res = await _httpClient.SendAsync(request, cancellationToken);
            res.EnsureSuccessStatusCode();
            return await res.Content.ReadFromJsonAsync<TResult>(cancellationToken: cancellationToken);
        }


    }

}
