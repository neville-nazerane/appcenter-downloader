using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCenterDownloader.MobileApp.Services
{
    public class AppCenterClientProvider(HttpClient httpClient)
    {

        private readonly HttpClient _httpClient = httpClient;

        public AppCenterClient GetClient(string key) => new AppCenterClient(_httpClient, key);

    }
}
