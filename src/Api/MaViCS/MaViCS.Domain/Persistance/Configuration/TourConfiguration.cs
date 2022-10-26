using MaViCS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MaViCS.Domain.Persistance.Configuration
{
    public static class TourConfiguration
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Tour>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Tour>()
                .Property(x => x.CreatedOn).HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<Tour>()
                .Property(x => x.CreatedBy).HasDefaultValue("Application");

            modelBuilder.Entity<Tour>()
                .HasOne(e => e.Talent)
                .WithMany(e => e.Tours)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tour>()
                .HasMany(e => e.Shows);

        }
    }
}
