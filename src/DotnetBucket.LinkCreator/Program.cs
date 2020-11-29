using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace DotnetBucket.LinkCreator
{
    class Program
    {
        public static string DotnetFolder = @"C:\Program Files\dotnet";
        
        public static Regex Regex = new Regex(@"\\\d+(?:\.\d+)+(?:-rc(?:\.\d+)+)?");

        private static void Main(string[] args)
        {
            switch (args[0])
            {
                case "install":
                    Install(args[1]);
                    break;
                case "uninstall":
                    Uninstall();
                    break;
            }
#if !DEBUG
            if (args.Length == 0)
            {
                return;
            }        
            
            var scoopInstallDir = args[0];
            #endif

            #if DEBUG
            var scoopInstallDir = @"C:\Scoop\apps\dotnet-sdk-latest\current";
            #endif


        }

        private static void Install(string scoopInstallDir)
        {
            //Checks if donet folder exists
            if (!Directory.Exists(DotnetFolder))
            {
                Directory.CreateDirectory(DotnetFolder);
            }
            
            Directory.SetCurrentDirectory(DotnetFolder);

            //Makes sure we have a dotnet.exe
            if (!File.Exists("dotnet.exe"))
            {
                File.Copy(Path.Combine(scoopInstallDir, "dotnet.exe"), "dotnet.exe");
            }
            
            //Searches for the folders to create symlink
            var dirs = Directory.EnumerateDirectories(scoopInstallDir, "*", SearchOption.AllDirectories).Select(x => x.Replace($"{scoopInstallDir}\\", "")).ToList();

            var gutDirs = dirs.Where(x =>
            {
                var match = Regex.Match(x);
                if (!match.Success || string.IsNullOrEmpty(match.Value))
                {
                    return false;
                }
                return x.EndsWith(match.Value);
            });
            
            foreach (var dir in gutDirs)
            {
                var from = Path.Combine(scoopInstallDir, dir);
                var to =Path.Combine(DotnetFolder, dir);

                var toParent = Directory.GetParent(to)!.FullName;
                if (!Directory.Exists(toParent))
                {
                    Directory.CreateDirectory(toParent);
                }
                
                var cmd = $"/C mklink /D \"{to}\" \"{from}\"";
                Process.Start("cmd.exe", cmd);
            }
        }

        public static void Uninstall()
        {
            
        }
    }
}