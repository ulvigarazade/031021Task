using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(new List<Book>
            {
                new Book {Id = 1, Name = "Abc", Category = "JKL"},
                new Book {Id = 2, Name = "DEF", Category = "MNO"},
                new Book { Id = 3, Name = "GHI", Category = "PQR" }
            });
        }
    }
}
