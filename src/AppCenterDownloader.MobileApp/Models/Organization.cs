using System.Text.Json.Serialization;

namespace AppCenterDownloader.MobileApp.Models
{
    public class Organization
    {

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("origin")]
        public string Origin { get; set; }

    }

}
