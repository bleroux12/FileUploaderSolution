using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Infrastructure.DbContext
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Seed Roles (Admin, SuperUser, User)
            var userRoleId = "B400F176-E03A-4073-995B-07B608FF0807";
            var superUserRoleId = "890427BA-44DA-46FD-92CE-9060A905E19E";
            var adminRoleId = "96C16DC2-229A-4636-AE19-1942497640E6";
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole
                {
                    Name = "SuperUser",
                    NormalizedName = "SuperUser",
                    Id = superUserRoleId,
                    ConcurrencyStamp = superUserRoleId
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);

            //Seed AdminUser
            var adminId = "F3627278-B70D-4519-910C-D2A0572D68DE";
            var adminUser = new IdentityUser
            {
                UserName = "admin",
                Email = "admin@fileuploder.com",
                NormalizedEmail = "admin@fileuploder.com".ToUpper(),
                NormalizedUserName = "admin".ToUpper(),
                Id = adminId
            };
            adminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(adminUser, "Admin123$");
            builder.Entity<IdentityUser>().HasData(adminUser);

            //Add All roles to Admin
            var adminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = adminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = superUserRoleId,
                    UserId = adminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = adminId
                }
            };
            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
        }
    }
}
