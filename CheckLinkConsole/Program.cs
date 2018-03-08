using System;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace CheckLinkConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var outputFolder = "reports";
            var outputFile = "report.txt";
            var outputPath = Path.Combine(currentDirectory, outputFolder, outputFile);
            var directory = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(directory);

            Console.WriteLine($"Saving report to {outputPath}");

            var site = "https://g0t4.github.io/pluralsight-dotnet-core-xplat-apps";
            var client = new HttpClient();

            var body = client.GetStringAsync(site);

            Console.WriteLine(body.Result);

            Console.WriteLine();
            Console.WriteLine("Links");
            var links = LinkChecker.GetLinks(body.Result);

            links.ToList().ForEach(Console.WriteLine);

            // write out links
            
            var checkedLikns = LinkChecker.CheckLink(links);
            using (var file = File.CreateText(outputPath))
            {
                foreach (var link in checkedLikns.OrderBy(l => l.Exists))
                {
                    var status = link.IsMissing ? "missing" : "OK";
                    file.WriteLine($"{status} - { link.Link}");
                }
            }
        }
    }
}
