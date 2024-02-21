using System.Text.Json.Serialization;

namespace AppCenterDownloader.MobileApp.Models.AppCenter
{
    public class AppCenterOrganization
    {

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("origin")]
        public string Origin { get; set; }

    }

}
