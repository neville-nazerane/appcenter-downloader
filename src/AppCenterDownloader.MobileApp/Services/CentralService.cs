﻿using Android.Accounts;
using AppCenterDownloader.MobileApp.Models;
using AppCenterDownloader.MobileApp.Models.LocalDb;
using Java.Time;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppCenterDownloader.MobileApp.Services;

public class CentralService(AppCenterClientProvider appCenterClientProvider, LocalRepository repository)
{
    
    private readonly AppCenterClientProvider _appCenterClientProvider = appCenterClientProvider;
    private readonly LocalRepository _repository = repository;

    public async Task Upsert(AddAccountModel account)
    {
        await SecureStorage.SetAsync(account.Key, account.ApiKey);

        var dbModel = new DbAccount
        {
            Key = account.Key,
            DisplayName = account.DisplayName,
        };
        _repository.Accounts.Upsert(dbModel);
    }

    public string GetAccountDisplayName(string key) => _repository.Accounts.FindOne(key)?.Key;

    public async Task<string> GetLatestDownloadableUrlAsync(string accountKey, AppDisplay app, CancellationToken cancellationToken = default)
    {
        var client = await GetAppCenterClientAsync(accountKey);

        var res = await client.GetLatestReleaseInfoAsync(app.OwnerName, app.AppName, cancellationToken);
        return res?.DownloadUrl;
    }

    public async Task<string> GetDownloadableUrlAsync(string accountKey, AppDisplay app, int releaseId, CancellationToken cancellationToken = default)
    {
        var client = await GetAppCenterClientAsync(accountKey);

        var res = await client.GetReleaseInfoAsync(app.OwnerName, app.AppName, releaseId, cancellationToken);
        return res?.DownloadUrl;
    }

    public async Task<string> GetReleaseNotesAsync(string accountKey, AppDisplay app, int releaseId, CancellationToken cancellationToken = default)
    {
        var client = await GetAppCenterClientAsync(accountKey);

        var res = await client.GetReleaseInfoAsync(app.OwnerName, app.AppName, releaseId, cancellationToken);
        return res?.ReleaseNotes;
    }

    public async IAsyncEnumerable<ReleaseDisplay> GetReleasesAsync(string accountKey,
                                                                   AppDisplay app,
                                                                   [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var client = await GetAppCenterClientAsync(accountKey);
        var res = client.GetReleasesAsync(app.OwnerName, app.AppName, 10, cancellationToken);

        await foreach (var release in res)
        {
            yield return new()
            {
                Id = release.Id,
                Version = release.Version,
                CreatedOn = release.UploadedAt
            };
        }
    }

    public bool SetAsFavorite(AppDisplay app) => _repository.FavoriteApps.Upsert(app);

    public bool UnSetAsFavorite(AppDisplay app) => _repository.FavoriteApps.Delete(app.Id);

    public IEnumerable<AppDisplay> GetFavorites() => _repository.FavoriteApps.FindAll();



    public async IAsyncEnumerable<AccountDisplay> GetAccountDisplaysAsync([EnumeratorCancellation]CancellationToken cancellationToken = default)
    {
        var dbAccounts = _repository.Accounts.FindAll();
        var favs = _repository.FavoriteApps.FindAll();

        foreach (var account in dbAccounts)
        {
            var client = await GetAppCenterClientAsync(account.Key);
            
            var appCollection = new ObservableCollection<AppDisplay>();

            yield return new()
            {
                Key = account.Key,
                DisplayName = account.DisplayName,
                Apps = appCollection
            };

            var apps = client.GetAppsAsync(cancellationToken);

            await foreach (var app in apps)
            {
                if (app.Os == "Android")
                    appCollection.Add(new AppDisplay()
                    {
                        Id = app.Id,
                        DisplayName = app.DisplayName,
                        IconUrl = app.IconUrl,
                        AppName = app.Name,
                        OwnerName = app.Owner.Name,
                        IsFavorite = favs.Any(f => f.Id == app.Id)
                    });
            }

        }
    }

    async Task<AppCenterClient> GetAppCenterClientAsync(string appKey)
    {
        var apiKey = await SecureStorage.GetAsync(appKey);
        return _appCenterClientProvider.GetClient(apiKey);
    }

}
