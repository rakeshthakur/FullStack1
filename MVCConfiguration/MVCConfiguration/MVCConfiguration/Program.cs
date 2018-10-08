using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MVCConfiguration
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
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory())
                .AddInMemoryCollection(configDict)
                .AddXmlFile("config.xml")
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();
            })
                .UseStartup<Startup>()
                .Build();
    }
}
