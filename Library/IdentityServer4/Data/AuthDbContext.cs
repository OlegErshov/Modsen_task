using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Data
{
    public class AuthDbContext : IdentityDbContext<AppUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) 
            : base(options) { }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>(entity => entity.ToTable(name: "User"));
            builder.Entity<IdentityRole>(entity => entity.ToTable(name: "Role"));
            builder.Entity<IdentityUserRole<string>>(entity => entity.ToTable(name: "UserRole"));
            builder.Entity<IdentityUserLogin<string>>(entity => entity.ToTable(name: "UserLogin"));
            builder.Entity<IdentityUserToken<string>>(entity => entity.ToTable(name: "UserToken"));
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.ToTable(name: "RoleClaim"));

            builder.Entity<AppUser>().HasData(
                    new AppUser 
                    {
                        Id = "e0dd19cf-ab64-40cf-adb3-2ea3bf5cb9cf",
                        FirstName = "Tomas",
                        Surname = "Shelby",
                        UserName = "ostrieKozerok",
                        NormalizedUserName = "OSTRIEKOZEROK",
                        PasswordHash = "AQAAAAEAACcQAAAAEPW/RDjSyUSGj5CVaa3nKdnb+fQBUoDeIwN5higGf8JMl7ik9pqyat3v60PTYzND8w==",
                        SecurityStamp = "MBWOCQLR2CMJH63BYU6SDWSAPXMTEYIC",
                        ConcurrencyStamp = "2edbdd23-b51f-4a36-a5c3-f046e3d068ab",
                        // Password : 7777
                    },
                    new AppUser
                    {
                        Id = "b391dd4d-fbda-46ed-a300-44d14facac99",
                        FirstName = "Oleg",
                        Surname = "Ershov",
                        UserName = "oleza",
                        NormalizedUserName = "OLEZA",
                        PasswordHash = "AQAAAAEAACcQAAAAEOE5cQyJEFkp2C9mip40Sp1Xv6oWmw5lS/DanG84dgbFvE198QvnpERv3B1K1v1C8g==",
                        SecurityStamp = "TQ437PFELCMX76YQL7XX66KHZUS2MRYG",
                        ConcurrencyStamp = "f90a708f-f555-42b1-9b23-bd10f13980f7",
                        // Password : 1111
                    }
                );

            builder.Entity<IdentityRole>().HasData(
                    new IdentityRole
                    {
                        Id = "1",
                        Name = "Admin",
                        NormalizedName = "ADMIN",
                        ConcurrencyStamp = "testStamp"
                        
                    },

                    new IdentityRole
                    {
                        Id = "2",
                        Name = "User",
                        NormalizedName = "USER",
                        ConcurrencyStamp = "testStamp2"
                    });

            builder.Entity<IdentityUserRole<string>>().HasData(

                new IdentityUserRole<string> { UserId = "e0dd19cf-ab64-40cf-adb3-2ea3bf5cb9cf", RoleId = "1" },

                new IdentityUserRole<string> { UserId = "b391dd4d-fbda-46ed-a300-44d14facac99", RoleId = "2" }

                );

            builder.ApplyConfiguration(new AppUserConfiguration());
        }
    }
}
