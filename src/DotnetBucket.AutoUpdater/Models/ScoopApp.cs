using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DotnetBucket.AutoUpdater.Models
{
    public class ScoopApp
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("homepage")]
        public Uri Homepage { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("license")]
        public string License { get; set; }

        [JsonPropertyName("architecture")]
        public Dictionary<string, Architecture> Architecture { get; set; }

        [JsonPropertyName("bin")]
        public string Bin { get; set; }

        [JsonPropertyName("env_add_path")]
        public string EnvAddPath { get; set; }

        [JsonPropertyName("env_set")]
        public EnvSet EnvSet { get; set; }

        [JsonPropertyName("checkver")]
        public Checkver Checkver { get; set; }

        [JsonPropertyName("autoupdate")]
        public Autoupdate Autoupdate { get; set; }
    }

    public class Architecture
    {
        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        [JsonPropertyName("hash")]
        public string Hash { get; set; }
    }

    public class Autoupdate
    {
        [JsonPropertyName("architecture")]
        public Dictionary<string, Hash> Architecture { get; set; }

        [JsonPropertyName("hash")]
        public Hash Hash { get; set; }
    }

    public class Hash
    {
        [JsonPropertyName("url")]
        public Uri Url { get; set; }
    }

    public class Checkver
    {
        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        [JsonPropertyName("jsonpath")]
        public string Jsonpath { get; set; }
    }

    public class EnvSet
    {
        [JsonPropertyName("DOTNET_ROOT")]
        public string DotnetRoot { get; set; }

        [JsonPropertyName("MSBuildSDKsPath")]
        public string MsBuildSdKsPath { get; set; }
    }
}
