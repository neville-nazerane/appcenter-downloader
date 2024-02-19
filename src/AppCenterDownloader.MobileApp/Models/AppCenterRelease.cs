using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppCenterDownloader.MobileApp.Models
{
    public class AppCenterRelease
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("origin")]
        public string Origin { get; set; }

        [JsonPropertyName("short_version")]
        public string ShortVersion { get; set; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        [JsonPropertyName("uploaded_at")]
        public string UploadedAt { get; set; }

        [JsonPropertyName("destination_type")]
        public string DestinationType { get; set; }

        [JsonPropertyName("distribution_groups")]
        public IEnumerable<DistributionGroup> DistributionGroups { get; set; }

        [JsonPropertyName("is_external_build")]
        public bool IsExternalBuild { get; set; }

        [JsonPropertyName("file_extension")]
        public string FileExtension { get; set; }
    }

}
