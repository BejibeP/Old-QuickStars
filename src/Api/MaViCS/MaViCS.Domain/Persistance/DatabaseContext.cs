using MaViCS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace MaViCS.Domain.Persistance
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Town> Towns { get; set; }
        public DbSet<Talent> Talents { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Show> Shows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Town>()
                .Property(e => e.Latitude).HasPrecision(7, 4);

            modelBuilder.Entity<Town>()
                .Property(e => e.Longitude).HasPrecision(7, 4);

            modelBuilder.Entity<Town>().HasMany(e => e.Talents);

            modelBuilder.Entity<Town>().HasMany(e => e.Shows);

            modelBuilder.Entity<Talent>()
                .HasOne(e => e.HomeTown)
                .WithMany(e => e.Talents)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tour>()
                .HasOne(e => e.Talent)
                .WithMany(e => e.Tours)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tour>()
                .HasMany(e => e.Shows);

            modelBuilder.Entity<Show>()
                .HasOne(e => e.Tour)
                .WithMany(e => e.Shows)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Show>()
                .HasOne(e => e.Location)
                .WithMany(e => e.Shows)
                .OnDelete(DeleteBehavior.SetNull);

            OnModelInitialize(modelBuilder);
        }

        private void OnModelInitialize(ModelBuilder modelBuilder)
        {

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