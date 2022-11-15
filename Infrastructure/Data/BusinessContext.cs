using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class BusinessContext : DbContext
    {
        public DbSet<UserData> UserData { get; set; }

        public BusinessContext(DbContextOptions<BusinessContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserData>().HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<UserData>().HasData(
                new UserData
                {
                    Email = "admin@localhost.com"
                }
            );
        }
    }
}
