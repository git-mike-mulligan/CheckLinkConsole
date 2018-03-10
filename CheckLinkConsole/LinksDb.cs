using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CheckLinkConsole
{
    public class LinksDb : DbContext
    {
        public DbSet<LinkCheckResult> Links { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBiulder)
        {
            // MS SQL Server
            // var connection = @"Server=localhost;Database=Links;User Id=sa;Password=Password/1";
            // optionsBiulder.UseSqlServer(connection);

            // SQLite
            var databaseLocation = Path.Combine(Directory.GetCurrentDirectory(), "links.db");
            optionsBiulder.UseSqlite($"Filename={databaseLocation}");
        }


    }
}
