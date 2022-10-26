using MaViCS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MaViCS.Domain.Persistance.Configuration
{
    public static class TalentConfiguration
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Talent>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Talent>()
                .Property(x => x.CreatedOn).HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<Talent>()
                .Property(x => x.CreatedBy).HasDefaultValue("Application");

            modelBuilder.Entity<Talent>()
                .HasOne(e => e.HomeTown)
                .WithMany(e => e.Talents)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
