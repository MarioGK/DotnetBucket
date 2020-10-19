using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DotnetBucket.AutoUpdater.Models
{
    public partial class ReleaseInfo
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

    public partial class Intellisense
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("version-display")]
        public string VersionDisplay { get; set; }

        [JsonPropertyName("files")]
        public List<File> Files { get; set; }
    }

    public partial class File
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("rid")]
        public string Rid { get; set; }

        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("akams")]
        public Uri Akams { get; set; }
    }

    public partial class Release
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
        public Runtime Runtime { get; set; }

        [JsonPropertyName("sdk")]
        public Sdk Sdk { get; set; }

        [JsonPropertyName("sdks")]
        public List<Sdk> Sdks { get; set; }

        [JsonPropertyName("aspnetcore-runtime")]
        public AspnetcoreRuntime AspnetcoreRuntime { get; set; }

        [JsonPropertyName("windowsdesktop")]
        public Intellisense Windowsdesktop { get; set; }

        [JsonPropertyName("symbols")]
        public Symbols Symbols { get; set; }
    }

    public partial class AspnetcoreRuntime
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("version-display")]
        public string VersionDisplay { get; set; }

        [JsonPropertyName("version-aspnetcoremodule")]
        public List<string> VersionAspnetcoremodule { get; set; }

        [JsonPropertyName("vs-version")]
        public string VsVersion { get; set; }

        [JsonPropertyName("files")]
        public List<File> Files { get; set; }
    }

    public partial class Runtime
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("version-display")]
        public string VersionDisplay { get; set; }

        [JsonPropertyName("vs-version")]
        public string VsVersion { get; set; }

        [JsonPropertyName("vs-mac-version")]
        public string VsMacVersion { get; set; }

        [JsonPropertyName("files")]
        public List<File> Files { get; set; }
    }

    public partial class Sdk
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("version-display")]
        public string VersionDisplay { get; set; }

        [JsonPropertyName("runtime-version")]
        public string RuntimeVersion { get; set; }

        [JsonPropertyName("vs-version")]
        public string VsVersion { get; set; }

        [JsonPropertyName("vs-mac-version")]
        public string VsMacVersion { get; set; }

        [JsonPropertyName("vs-support")]
        public string VsSupport { get; set; }

        [JsonPropertyName("vs-mac-support")]
        public string VsMacSupport { get; set; }

        [JsonPropertyName("csharp-version")]
        public string CSharpVersion { get; set; }

        [JsonPropertyName("fsharp-version")]
        public string FSharpVersion { get; set; }

        [JsonPropertyName("vb-version")]
        public string VbVersion { get; set; }

        [JsonPropertyName("files")]
        public List<File> Files { get; set; }
    }

    public partial class Symbols
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("files")]
        public List<object> Files { get; set; }
    }
}
