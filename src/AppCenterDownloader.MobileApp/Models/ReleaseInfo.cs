using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppCenterDownloader.MobileApp.Models
{
    public class ReleaseInfo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("app_name")]
        public string AppName { get; set; }

        [JsonPropertyName("app_display_name")]
        public string AppDisplayName { get; set; }

        [JsonPropertyName("app_os")]
        public string AppOs { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("origin")]
        public string Origin { get; set; }

        [JsonPropertyName("short_version")]
        public string ShortVersion { get; set; }

        [JsonPropertyName("release_notes")]
        public string ReleaseNotes { get; set; }

        [JsonPropertyName("provisioning_profile_name")]
        public string ProvisioningProfileName { get; set; }

        [JsonPropertyName("provisioning_profile_type")]
        public string ProvisioningProfileType { get; set; }

        [JsonPropertyName("provisioning_profile_expiry_date")]
        public string ProvisioningProfileExpiryDate { get; set; }

        [JsonPropertyName("is_provisioning_profile_syncing")]
        public bool IsProvisioningProfileSyncing { get; set; }

        [JsonPropertyName("size")]
        public long Size { get; set; }

        [JsonPropertyName("min_os")]
        public string MinOs { get; set; }

        [JsonPropertyName("device_family")]
        public string DeviceFamily { get; set; }

        [JsonPropertyName("android_min_api_level")]
        public string AndroidMinApiLevel { get; set; }

        [JsonPropertyName("bundle_identifier")]
        public string BundleIdentifier { get; set; }

        [JsonPropertyName("package_hashes")]
        public IEnumerable<string> PackageHashes { get; set; }

        [JsonPropertyName("fingerprint")]
        public string Fingerprint { get; set; }

        [JsonPropertyName("uploaded_at")]
        public string UploadedAt { get; set; }

        [JsonPropertyName("download_url")]
        public string DownloadUrl { get; set; }

        [JsonPropertyName("secondary_download_url")]
        public string SecondaryDownloadUrl { get; set; }

        [JsonPropertyName("app_icon_url")]
        public string AppIconUrl { get; set; }

        [JsonPropertyName("install_url")]
        public string InstallUrl { get; set; }

        [JsonPropertyName("destination_type")]
        public string DestinationType { get; set; }

        [JsonPropertyName("distribution_groups")]
        public IEnumerable<DistributionGroup> DistributionGroups { get; set; }

        [JsonPropertyName("is_udid_provisioned")]
        public bool IsUdidProvisioned { get; set; }

        [JsonPropertyName("can_resign")]
        public bool CanResign { get; set; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("is_external_build")]
        public bool IsExternalBuild { get; set; }
    }
}
