using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using DotnetBucket.AutoUpdater.Models;

namespace DotnetBucket.AutoUpdater
{
    class Program
    {
        private static List<string> RIDs = new List<string>
        {
            "win-x64",
            "win-x86"
        };
        
        static void Main(string[] args)
        {
            var wc = new WebClient();
            var releasesRaw =
                wc.DownloadString(
                    "https://dotnetcli.blob.core.windows.net/dotnet/release-metadata/releases-index.json");

            var release = JsonSerializer.Deserialize<Releases>(releasesRaw);

            if (release == null)
            {
                return;
            }
            
            foreach (var rls in release.ReleasesIndex)
            {
                var releaseInfoRaw = wc.DownloadString(rls.ReleasesJson);
                var releaseInfo = JsonSerializer.Deserialize<ReleaseInfo>(releaseInfoRaw);

            }
            
            Console.WriteLine(releasesRaw);

            Console.Read();
        }
    }
}