using AppCenterDownloader.MobileApp.Models;
using AppCenterDownloader.MobileApp.Models.AppCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
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

        public Task<IEnumerable<AppCenterOrganization>> GetOrganizationsAsync(CancellationToken cancellationToken = default) => GetFromJsonAsync<IEnumerable<AppCenterOrganization>>("orgs", cancellationToken);

        public Task<IEnumerable<AppCenterApp>> GetAppsAsync(CancellationToken cancellationToken = default) => GetFromJsonAsync<IEnumerable<AppCenterApp>>("apps?orderBy=display_name", cancellationToken);

        public IAsyncEnumerable<AppCenterRelease> GetReleasesAsync(string owner_name,
                                                                   string app_name,
                                                                   int limit,
                                                                   CancellationToken cancellationToken = default)
            => GetAsAsyncEnumerable<AppCenterRelease>($"apps/{owner_name}/{app_name}/releases?top={limit}", cancellationToken);

        public Task<AppCenterReleaseInfo> GetReleaseInfoAsync(string owner_name,
                                                     string app_name, 
                                                     int releaseId, 
                                                     CancellationToken cancellationToken = default)
            => GetFromJsonAsync<AppCenterReleaseInfo>($"apps/{owner_name}/{app_name}/releases/{releaseId}", cancellationToken);

        public Task<AppCenterReleaseInfo> GetLatestReleaseInfoAsync(string owner_name,
                                                           string app_name,
                                                           CancellationToken cancellationToken = default)
            => GetFromJsonAsync<AppCenterReleaseInfo>($"apps/{owner_name}/{app_name}/releases/latest", cancellationToken);

        private async IAsyncEnumerable<TResult> GetAsAsyncEnumerable<TResult>(string path, [EnumeratorCancellation]CancellationToken cancellationToken = default)
        {
            using HttpResponseMessage res = await GetAsync(path, cancellationToken);
            await foreach (var r in res.Content.ReadFromJsonAsAsyncEnumerable<TResult>(cancellationToken: cancellationToken))
                yield return r;
        }

        private async Task<TResult> GetFromJsonAsync<TResult>(string path, CancellationToken cancellationToken = default)
        {
            using HttpResponseMessage res = await GetAsync(path, cancellationToken);
            return await res.Content.ReadFromJsonAsync<TResult>(cancellationToken: cancellationToken);
        }

        private async Task<HttpResponseMessage> GetAsync(string path, CancellationToken cancellationToken)
        {
            if (!VersionedRegex().IsMatch(path))
                path = $"v0.1/{path}";

            var request = new HttpRequestMessage(HttpMethod.Get, path);
            request.Headers.Add("X-API-Token", _apiKey);
            var res = await _httpClient.SendAsync(request, cancellationToken);
            res.EnsureSuccessStatusCode();
            return res;
        }
    }

}
