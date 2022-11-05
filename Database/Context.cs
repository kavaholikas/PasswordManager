using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PManager.Models;

namespace PManager.Database
{
    public class Context : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public string DbPath { get; }

        public Context()
        {
            Environment.SpecialFolder folder = Environment.SpecialFolder.MyDocuments;
            string path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "PManager.sqlite");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}