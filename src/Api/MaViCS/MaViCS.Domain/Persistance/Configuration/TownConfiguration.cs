using MaViCS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MaViCS.Domain.Persistance.Configuration
{
    public static class TownConfiguration
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Town>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Town>()
                .Property(x => x.CreatedOn).HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<Town>()
                .Property(x => x.CreatedBy).HasDefaultValue("Application");

            modelBuilder.Entity<Town>()
                .Property(e => e.Latitude).HasPrecision(7, 4);

            modelBuilder.Entity<Town>()
                .Property(e => e.Longitude).HasPrecision(7, 4);

        }
    }
}
