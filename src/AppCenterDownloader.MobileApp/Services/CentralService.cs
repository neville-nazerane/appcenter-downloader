using AppCenterDownloader.MobileApp.Models;
using AppCenterDownloader.MobileApp.Models.LocalDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppCenterDownloader.MobileApp.Services
{
    public class CentralService(AppCenterClientProvider appCenterClientProvider, LocalRepository repository)
    {
        
        private readonly AppCenterClientProvider _appCenterClientProvider = appCenterClientProvider;
        private readonly LocalRepository _repository = repository;


        public async Task AddAsync(AddAccountModel account)
        {
            var key = Guid.NewGuid().ToString("N");

            await SecureStorage.SetAsync(key.ToString(), account.ApiKey);

            var dbModel = new DbAccount
            {
                Key = key,
                DisplayName = account.DisplayName,
            };
            _repository.Accounts.Insert(dbModel);

        }

        //private async IAsyncEnumerable<AccountModel> GetAccountsAsync()
        //{
        //    var dbAccounts = _repository.Accounts.FindAll();

        //    foreach (var dbAccount in dbAccounts)
        //    {
        //        var apiKey = await SecureStorage.GetAsync(dbAccount.Key);
        //        yield return new()
        //        {
        //            Key = apiKey,
        //            DisplayName = dbAccount.DisplayName,
        //        };
        //    }
        //}

        public bool SetAsFavorite(AppDisplay app) => _repository.FavoriteApps.Upsert(app);

        public bool UnSetAsFavorite(AppDisplay app) => _repository.FavoriteApps.Delete(app.Id);

        public IEnumerable<AppDisplay> GetFavorites() => _repository.FavoriteApps.FindAll();

        public async IAsyncEnumerable<AccountDisplay> GetAccountDisplaysAsync([EnumeratorCancellation]CancellationToken cancellationToken = default)
        {
            var dbAccounts = _repository.Accounts.FindAll();
            var favs = _repository.FavoriteApps.FindAll();

            foreach (var account in dbAccounts)
            {
                var apiKey = await SecureStorage.GetAsync(account.Key);

                var client = _appCenterClientProvider.GetClient(apiKey);
                
                var apps = await client.GetAppsAsync(cancellationToken);

                yield return new()
                {
                    Key = account.Key,
                    DisplayName = account.DisplayName,
                    Apps = apps.Select(a => new AppDisplay()
                    {
                        Id = a.Id,
                        DisplayName = a.DisplayName,
                        IconUrl = a.IconUrl,
                        AppName = a.Name,
                        OwnerName = a.Owner.Name,
                        IsFavorite = favs.Any(f => f.Id == a.Id)
                    }).ToList()
                };
            }
        }

    }
}
