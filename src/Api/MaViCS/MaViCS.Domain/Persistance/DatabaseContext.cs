using MaViCS.Domain.Framework;
using MaViCS.Domain.Models;
using MaViCS.Domain.Persistance.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace MaViCS.Domain.Persistance
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Talent> Talents { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Show> Shows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UserConfiguration.OnModelCreating(modelBuilder);
            TownConfiguration.OnModelCreating(modelBuilder);
            TalentConfiguration.OnModelCreating(modelBuilder);
            TourConfiguration.OnModelCreating(modelBuilder);
            ShowConfiguration.OnModelCreating(modelBuilder);

            OnModelInitialize(modelBuilder);
        }

        private void OnModelInitialize(ModelBuilder modelBuilder)
        {

            var user1 = new User
            {
                Id = 1,
                Username = "superviseur",
                Mail = "su@mail.com",
                Password = PasswordTool.HashPassword("admin"),
                Role = UserRole.UserRoleEnum.Superviseur,
                CreatedBy = "Application",
                CreatedOn = DateTime.UtcNow
            };

            modelBuilder.Entity<User>().HasData(user1);
        }

    }
}