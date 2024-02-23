using AppCenterDownloader.MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppCenterDownloader.MobileApp.Services
{
    public class SourceWall
    {
        private AppDisplay selectedApp;

        public string SelectedAccountKey { get; set; }

        public Task<AppDisplay> GetSelectedAppAsync() => CloneAsync(selectedApp);

        public async Task SetSelectedAppAsync(AppDisplay value)
        {
            selectedApp = await CloneAsync(value);
        }

        public static async Task<TResult> CloneAsync<TResult>(TResult input)
        {
            await using var memoryStream = new MemoryStream();
            await JsonSerializer.SerializeAsync(memoryStream, input);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return await JsonSerializer.DeserializeAsync<TResult>(memoryStream);
        }


        public static string LastLocation 
        { 
            get => Preferences.Get(nameof(LastLocation), "apps");
            set => Preferences.Set(nameof(LastLocation), value);
        }

    }
}
