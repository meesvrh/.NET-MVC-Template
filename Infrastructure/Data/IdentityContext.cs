using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class IdentityContext : IdentityDbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "fab4fac1-c546-41de-aebc-a14da6895711",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            );

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "c7b013f0-5201-4317-abd8-c211f91b7330",
                    FirstName = "Admin",
                    LastName = "Admin",
                    UserName = "Admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    Email = "Admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Admin1234!"),
                    SecurityStamp = string.Empty
                }
            );
        }
    }
}
