using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using DotnetBucket.AutoUpdater.Models;

namespace DotnetBucket.AutoUpdater
{
    static class Program
    {
        private static List<string> RIDs = new List<string>
        {
            "win-x64",
            "win-x86"
        };

        private static List<string> Types = new List<string>
        {
            
        };

        private static readonly WebClient WebClient = new WebClient();

        static void Main(string[] args)
        {
            var releasesRaw =
                WebClient.DownloadString(
                    "https://dotnetcli.blob.core.windows.net/dotnet/release-metadata/releases-index.json");

            var release = JsonSerializer.Deserialize<Releases>(releasesRaw);

            if (release == null)
            {
                return;
            }
            
            var releasesIndexes = release.ReleasesIndex.Where(x => x.SupportPhase != "eol").ToList();

            var scoopAppList = new List<ScoopApp>();

            //All versions
            Console.WriteLine("Creating all versions");
            foreach (var releasesIndex in releasesIndexes)
            {
                scoopAppList.AddRange(CreateScoopApps(releasesIndex));
            }
            
            //Latest version

            Console.WriteLine("Creating latest version");
            var latestIndex = releasesIndexes.First();
            var latestReleaseInfo = GetReleaseInfo(latestIndex);
            var latestRelease = latestReleaseInfo.Releases.First();
            scoopAppList.Add(CreateScoopApp(latestRelease.Sdk, "sdk","latest"));
            scoopAppList.Add(CreateScoopApp(latestRelease.Runtime, "runtime","latest"));
            scoopAppList.Add(CreateScoopApp(latestRelease.AspnetcoreRuntime, "aspnetcore","latest"));

            //LTS version
            Console.WriteLine("Creating LTS version");
            var ltsIndex = releasesIndexes.Where(x => x.SupportPhase.Equals("lts")).OrderByDescending(x => new Version(x.ChannelVersion)).FirstOrDefault();
            var ltsReleaseInfo = GetReleaseInfo(ltsIndex);
            var ltsRelease = ltsReleaseInfo.Releases.First();
            scoopAppList.Add(CreateScoopApp(ltsRelease.Sdk, "sdk","lts"));
            scoopAppList.Add(CreateScoopApp(ltsRelease.Runtime, "runtime","lts"));
            scoopAppList.Add(CreateScoopApp(ltsRelease.AspnetcoreRuntime, "aspnetcore","lts"));
            
            Console.WriteLine("Saving apps...");
            
            foreach (var scoopApp in scoopAppList.Where(x => x != null))
            {
                var fileName = $"dotnet-{scoopApp.Type}-{(string.IsNullOrEmpty(scoopApp.OverrideVersioName) ? scoopApp.Version : scoopApp.OverrideVersioName)}.json";
                File.WriteAllText(Path.Combine(@"F:\Projects\DotnetBucket\bucket", fileName),
                    JsonSerializer.Serialize(scoopApp,
                        new JsonSerializerOptions {WriteIndented = true, IgnoreNullValues = true}));
            }

            Console.WriteLine("Finished");
        }

        private static ReleaseInfo GetReleaseInfo(ReleasesIndex releasesIndex)
        {
            var releaseInfoRaw = WebClient.DownloadString(releasesIndex.ReleasesJson);
            return JsonSerializer.Deserialize<ReleaseInfo>(releaseInfoRaw);
        }

        private static List<ScoopApp> CreateScoopApps(ReleasesIndex releasesIndex)
        {
            var releaseInfo = GetReleaseInfo(releasesIndex);

            if (releaseInfo == null)
            {
                return null;
            }
                
            var scoopApps = CreateScoopApps(releaseInfo);

            return scoopApps;
        }

        private static List<ScoopApp> CreateScoopApps(ReleaseInfo releaseInfo)
        {
            var returnList = new List<ScoopApp>();
            foreach (var release in releaseInfo.Releases)
            {
                returnList.Add(CreateScoopApp(release.Sdk, "sdk"));
                returnList.Add(CreateScoopApp(release.Runtime, "runtime"));
                returnList.Add(CreateScoopApp(release.AspnetcoreRuntime, "aspnetcore"));
            }
            return returnList;
        }

        private static ScoopApp CreateScoopApp(FilesInfo filesInfo, string type, string overrideVersionName = "")
        {
            if (filesInfo == null)
            {
                return null;
            }
            var x64 = filesInfo.Files.GetFile("win-x64");
            var x86 = filesInfo.Files.GetFile("win-x86");

            if (x64 == null || x86 == null)
            {
                return null;
            }
            
            var app = new ScoopApp
            {
                Type = type,
                Version = filesInfo.Version,
                Homepage =  "https://www.microsoft.com/net/",
                Description = ".NET is a free, cross-platform, open source developer platform for building many different types of applications.",
                License = "MIT",
                Architecture = new Dictionary<string, Architecture>
                {
                    {"64bit", new Architecture{Hash = x64.Hash, Url = x64.Url}},
                    {"32bit", new Architecture{Hash = x86.Hash, Url = x86.Url}},
                },
                /*Bin = "dotnet.exe",
                EnvAddPath = ".",
                EnvSet = new Dictionary<string, string>
                {
                    {"DOTNET_ROOT", "$dir"},
                    {"MSBuildSDKsPath", "$dir\\sdk\\$version\\Sdks"}
                },*/
                ExtractTo = @"F:\test"
            };

            if (!string.IsNullOrEmpty(overrideVersionName))
            {
                app.OverrideVersioName = overrideVersionName;
            }

            return app;
        }

        private static DotnetFile GetFile(this IEnumerable<DotnetFile> files, string rid)
        {
            return files.Where(x => x.Rid != null).FirstOrDefault(x => x.Rid.Equals(rid) && x.Name.Contains("zip"));
        }
    }
}