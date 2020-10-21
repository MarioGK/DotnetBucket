using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DotnetBucket.AutoUpdater.Models
{
    public class ReleaseInfo
    {
        [JsonPropertyName("channel-version")]
        public string ChannelVersion { get; set; }

        [JsonPropertyName("latest-release")]
        public string LatestRelease { get; set; }

        [JsonPropertyName("latest-release-date")]
        public DateTimeOffset LatestReleaseDate { get; set; }

        [JsonPropertyName("latest-runtime")]
        public string LatestRuntime { get; set; }

        [JsonPropertyName("latest-sdk")]
        public string LatestSdk { get; set; }

        [JsonPropertyName("support-phase")]
        public string SupportPhase { get; set; }

        [JsonPropertyName("lifecycle-policy")]
        public Uri LifecyclePolicy { get; set; }

        [JsonPropertyName("releases")]
        public List<Release> Releases { get; set; }

        [JsonPropertyName("intellisense")]
        public Intellisense Intellisense { get; set; }
    }

    public class Intellisense
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("version-display")]
        public string VersionDisplay { get; set; }

        [JsonPropertyName("files")]
        public List<DotnetFile> Files { get; set; }
    }

    public class DotnetFile
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("rid")]
        public string Rid { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("akams")]
        public Uri Akams { get; set; }
    }

    public class Release
    {
        [JsonPropertyName("release-date")]
        public DateTimeOffset ReleaseDate { get; set; }

        [JsonPropertyName("release-version")]
        public string ReleaseVersion { get; set; }

        [JsonPropertyName("security")]
        public bool Security { get; set; }

        [JsonPropertyName("release-notes")]
        public Uri ReleaseNotes { get; set; }

        [JsonPropertyName("runtime")]
        public FilesInfo Runtime { get; set; }

        [JsonPropertyName("sdk")]
        public FilesInfo Sdk { get; set; }

        [JsonPropertyName("aspnetcore-runtime")]
        public FilesInfo AspnetcoreRuntime { get; set; }

        [JsonPropertyName("windowsdesktop")]
        public Intellisense Windowsdesktop { get; set; }

        [JsonPropertyName("symbols")]
        public Symbols Symbols { get; set; }
    }

    public class FilesInfo
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }
        

        [JsonPropertyName("files")]
        public List<DotnetFile> Files { get; set; }
    }

    public class Symbols
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("files")]
        public List<object> Files { get; set; }
    }
}
