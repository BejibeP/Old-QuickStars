using MaViCS.Domain.Models;
using Microsoft.EntityFrameworkCore;

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

            var a = new Town
            {
                Id = 4
            };

            modelBuilder.Entity<Town>().HasData(a);
        }

    }
}