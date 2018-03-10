using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CheckLinkConsole
{
    public class Config
    {
        public Config(string[] args)
        {
            // default settings held in a memory dictionary
            var inMemory = new Dictionary<string, string>
            {
                { "site", "https://g0t4.github.io/pluralsight-dotnet-core-xplat-apps" },
                { "output:folder", "reports" }
            };

            // order of Add matters, 
            var configBuilder = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemory)
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("checksettings.json", true)
                .AddCommandLine(args)
                .AddEnvironmentVariables();
            
            var configuration = configBuilder.Build();
            ConfigurationRoot = configuration;
            Site = configuration["site"];
            Output = configuration.GetSection("output").Get<OutputSettings>();
        }

        public string Site { get; set; }
        public OutputSettings Output{ get; set; }
        public IConfigurationRoot ConfigurationRoot { get; set; }
    }
}
