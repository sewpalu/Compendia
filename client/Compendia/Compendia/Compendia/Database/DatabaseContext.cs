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
           // public DbSet<DBMask> Mask { get; set; }

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

                 modelBuilder.Entity<DbLogIn>(entity =>
                 {
                    entity.Property(e => e.name).IsRequired();
                 });


                /*modelBuilder.Entity<DBMask>(entity =>
                {
                    entity.Property(e => e.name).IsRequired();
                });
                Entry titel = new Entry();
                titel.Placeholder = "Titel";
                Editor text = new Editor();
                List<View> list = new List<View>();
                list.Add(titel);
                list.Add(text);


            var stdmask = new DBMask(
                "Standardmaske", list);
            modelBuilder.Entity<DBMask>().HasData( stdmask);*/





        }
    }
    
    
}
