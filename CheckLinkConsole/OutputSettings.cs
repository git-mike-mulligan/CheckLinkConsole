using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CheckLinkConsole
{
    public class OutputSettings
    {
        public OutputSettings()
        {
            File = "reports.txt";
        }
        public string Folder { get; set; }
        public string File { get; set; }

        public string GetReportFilePath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), Folder, File);
        }

        public string GetReportDirectory()
        {
            return Path.GetDirectoryName(GetReportFilePath());
        }
    }
}
