using Compendia.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Compendia.Database
{

    public class DatabaseContext : DbContext
    {
            public DbSet<DbLogIn> LogIn { get; set; }
            public DbSet<DBMask> Mask { get; set; }
            public DbSet<DbItem> Item { get; set; }

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

                 modelBuilder.Entity<DbLogIn>();


               /* modelBuilder.Entity<DBMask>()
                    .HasMany(i => i.DbItem)
                    .WithOne(m => m.DbMask)
                    .OnDelete(DeleteBehavior.Cascade);

                 modelBuilder.Entity<DbItem>()
                    .HasOne(m => m.DbMask)
                    .WithMany(i => i.DbItem)
                    .HasForeignKey(k => k.Maskid)
                    .OnDelete(DeleteBehavior.Cascade);



               /* Entry titel = new Entry();
                titel.Placeholder = "Titel";
                Editor text = new Editor();
                

                 var stdmask = new DBMask(
                "Standardmaske");

                stdmask.AddItem(titel);
                stdmask.AddItem(text);

                 modelBuilder.Entity<DBMask>().HasData( stdmask);*/





        }
    }
    
    
}
