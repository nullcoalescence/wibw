using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;

using wibw_api.Models;

namespace wibw_api.Db
{
    public class SupperContext : DbContext
    {
        private string dbName;

        public DbSet<Supper> Suppers { get; set; }

        public string DbPath { get; }

        public SupperContext()
        {
            this.dbName = "wibw.db";

            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, this.dbName);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
    }
}
