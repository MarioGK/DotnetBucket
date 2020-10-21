using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DotnetBucket.AutoUpdater.Models
{
    public class Releases
    {
        [JsonPropertyName("releases-index")]
        public List<ReleasesIndex> ReleasesIndex { get; set; }
    }

    public class ReleasesIndex
    {
        [JsonPropertyName("channel-version")]
        public string ChannelVersion { get; set; }

        [JsonPropertyName("latest-release")]
        public string LatestRelease { get; set; }

        [JsonPropertyName("latest-release-date")]
        public DateTimeOffset LatestReleaseDate { get; set; }

        [JsonPropertyName("security")]
        public bool Security { get; set; }

        [JsonPropertyName("latest-runtime")]
        public string LatestRuntime { get; set; }

        [JsonPropertyName("latest-sdk")]
        public string LatestSdk { get; set; }

        [JsonPropertyName("product")]
        public string Product { get; set; }

        [JsonPropertyName("support-phase")]
        public string SupportPhase { get; set; }

        [JsonPropertyName("releases.json")]
        public Uri ReleasesJson { get; set; }
    }
}