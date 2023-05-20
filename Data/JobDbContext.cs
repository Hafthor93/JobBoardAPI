using JobBoardAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JobboardAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }



        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=JobDatabse;Trusted_Connection=True");
        }
    }
}