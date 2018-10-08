using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using System.Diagnostics;

namespace MVCConfig1
{
    public class Program
    {
        private static Dictionary<string, string> configDict = new Dictionary<string, string>()
        {
            {"key1", "value1" },
            {"key2", "value2" }
        };
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().RunAsService();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var exePath = Process.GetCurrentProcess().MainModule.FileName;
            var contentPath = Path.GetDirectoryName(exePath);


            return WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(contentPath)
                //.ConfigureAppConfiguration((context, config) =>
                //{
                //    config.SetBasePath(Directory.GetCurrentDirectory())
                //    .AddInMemoryCollection(configDict)
                //    .AddJsonFile("settings.json")
                //    .AddEnvironmentVariables()
                //    .AddCommandLine(args)
                //    .Build();
                //})
                .UseStartup<Startup>();
        }
    }
}
