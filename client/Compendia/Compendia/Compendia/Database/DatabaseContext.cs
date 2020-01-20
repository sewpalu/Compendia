using Compendia.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compendia.Database
{
        public class DatabaseContext : DbContext
        {
            //public DbSet<DbObjects> Ojects { get; set; }
            //public DbSet<DbKategorie> Kategorie { get; set; }
            //public DbSet<DbObjectKategorie> ObjectKategories { get; set; }
            public DbSet<DbLogIn> LogIn { get; private set; }

            private readonly string _databasePath;

            public DatabaseContext(string databasePath)
            {
                try
                {
                    _databasePath = databasePath;
                    Database.EnsureCreated();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite($"Filename={_databasePath}");
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                //modelBuilder.Entity<DbObjectKategorie>()
                //   .HasKey(ok => new { ok.ObjectId, ok.KategorieId });

            }
        }
    
}
