﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DotnetBucket.AutoUpdater.Models
{
    public class ScoopApp
    {
        [JsonIgnore]
        public string Type { get; set; }
        
        [JsonIgnore]
        public string OverrideVersioName { get; set; }
        
        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("homepage")]
        public string Homepage { get; set; }

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
        public Dictionary<string, string> EnvSet { get; set; }

        [JsonPropertyName("extract_to")]
        public string ExtractTo { get; set; }

        [JsonPropertyName("post_install")]
        public List<string> PostInstall { get; set; }
        
        [JsonPropertyName("post_uninstall")]
        public List<string> PostUninstall { get; set; }
        
        [JsonPropertyName("depends")]
        public List<string> Depends { get; set; }

        [JsonPropertyName("installer")]
        public Installer Installer { get; set; }
        
        [JsonPropertyName("uninstaller")]
        public Installer Uninstaller { get; set; }
    }

    public class Installer
    {
        [JsonPropertyName("script")]
        public List<string> Script { get; set; }
    }

    public class Architecture
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("hash")]
        public string Hash { get; set; }
    }

    public class Hash
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
