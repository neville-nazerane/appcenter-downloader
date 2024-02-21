using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppCenterDownloader.MobileApp.Models.AppCenter
{

    public class AppCenterDistributionGroup
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("is_latest")]
        public bool IsLatest { get; set; }
    }

}
