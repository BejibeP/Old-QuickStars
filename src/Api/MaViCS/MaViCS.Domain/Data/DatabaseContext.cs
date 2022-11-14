using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuickStars.MaViCS.Domain.Auth;
using QuickStars.MaViCS.Domain.Data.Configuration;
using QuickStars.MaViCS.Domain.Data.Entities;

namespace QuickStars.MaViCS.Domain.Data
{
    public class DatabaseContext : IdentityDbContext<IdentityUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Talent> Talents { get; set; }
        public DbSet<Show> Shows { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            TalentTypeConfiguration.GetTypeConfiguration()
                .Configure(builder.Entity<Talent>());

            ShowTypeConfiguration.GetTypeConfiguration()
                .Configure(builder.Entity<Show>());

            OnModelInitialize(builder);

            base.OnModelCreating(builder);
        }

        private void OnModelInitialize(ModelBuilder builder)
        {
            // Create Roles
            var adminRole = new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = IdentityRoles.Admin,
                NormalizedName = IdentityRoles.Admin.ToUpper()
            };
            var userRole = new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = IdentityRoles.User,
                NormalizedName = IdentityRoles.User.ToUpper()
            };

            // Seeding AspNetRoles
            builder.Entity<IdentityRole>().HasData(adminRole, userRole);

            // Create Admin User
            var hasher = new PasswordHasher<IdentityUser>();
            var adminUser = new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin",
                NormalizedUserName = "admin".ToUpper(),
                PasswordHash = hasher.HashPassword(null, "PassW0rD!")
            };

            //Seeding AspNetUsers
            builder.Entity<IdentityUser>().HasData(adminUser);

            var adminRoles = new IdentityUserRole<string>
            {
                RoleId = adminRole.Id,
                UserId = adminUser.Id
            };

            // Seeding Admin role to the Admin user
            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
        }

    }
}