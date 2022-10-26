using MaViCS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MaViCS.Domain.Persistance.Configuration
{
    public static class ShowConfiguration
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Show>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Show>()
                .Property(x => x.CreatedOn).HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<Show>()
                .Property(x => x.CreatedBy).HasDefaultValue("Application");

            modelBuilder.Entity<Show>()
                .HasOne(e => e.Tour)
                .WithMany(e => e.Shows)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Show>()
                .HasOne(e => e.Location)
                .WithMany(e => e.Shows)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
