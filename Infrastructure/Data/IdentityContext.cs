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

            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "c7b013f0-5201-4317-abd8-c211f91b7330",
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    Email = "Admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Admin1234!"),
                    SecurityStamp = string.Empty
                }
            );
            
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "fab4fac1-c546-41de-aebc-a14da6895711",
                    UserId = "c7b013f0-5201-4317-abd8-c211f91b7330"
                }
            );
        }
    }
}
