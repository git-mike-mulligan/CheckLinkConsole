using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace CheckLinkConsole
{
    public class CheckLinkJob
    {
        public void Execute( string site, OutputSettings output )
        {
            var logger = Logs.Factory.CreateLogger<Program>();
            Directory.CreateDirectory(output.GetReportDirectory());
            logger.LogInformation(200, $"Saving report to {output.GetReportFilePath()}");

            var client = new HttpClient();
            var body = client.GetStringAsync(site);
            logger.LogDebug(body.Result);

            var links = LinkChecker.GetLinks(site, body.Result);

            var checkedLikns = LinkChecker.CheckLink(links);
            using (var file = File.CreateText(output.GetReportFilePath()))
            using (var linksDb = new LinksDb())
            {
                foreach (var link in checkedLikns.OrderBy(l => l.Exists))
                {
                    var status = link.IsMissing ? "missing" : "OK";
                    file.WriteLine($"{status} - { link.Link}");
                    linksDb.Links.Add(link);
                }
                linksDb.SaveChanges();
            }
        }
    }
}
