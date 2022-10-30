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
                Password = "A",
                Role = UserRole.Admin,
                CreatedBy = "Application",
                CreatedOn = DateTime.UtcNow
            };

            modelBuilder.Entity<User>().HasData(user1);

            var atlantis = new Town
            {
                Id = 1,
                Name = "Atlantis",
                Region = "Ocean",
                Description = "A Sunken city",
                Latitude = 0,
                Longitude = 0,
                CreatedBy = "Application",
                CreatedOn = DateTime.UtcNow
            };

            modelBuilder.Entity<Town>().HasData(atlantis);

            var gawr = new Talent
            {
                Id = 1,
                Name = "Gura",
                Surname = "Gawr",
                Title = "Shark-Girl Idol",
                HomeTownId = 1,
                CreatedBy = "Application",
                CreatedOn = DateTime.UtcNow
            };

            modelBuilder.Entity<Talent>().HasData(gawr);

            var startDate = new DateTime(2022, 1, 1);

            var tour1 = new Tour
            {
                Id = 1,
                TalentId = 1,
                Name = "Shark First Concert",
                StartedOn = startDate,
                CreatedBy = "Application",
                CreatedOn = DateTime.UtcNow
            };

            modelBuilder.Entity<Tour>().HasData(tour1);

            var show1 = new Show
            {
                Id = 1,
                TourId = 1,
                LocationId = 1,
                Date = startDate,
                CreatedBy = "Application",
                CreatedOn = DateTime.UtcNow
            };

            modelBuilder.Entity<Show>().HasData(show1);

        }

    }
}