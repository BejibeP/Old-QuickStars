using Microsoft.EntityFrameworkCore;
using QuickStars.MaViCS.Domain.Data.Models;

namespace QuickStars.MaViCS.Domain.Data.Configuration
{
    public static class TalentModel
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Talent>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Talent>()
                .HasIndex(e => new { e.FirstName, e.LastName })
                .IsUnique();

            modelBuilder.Entity<Talent>()
                .Property(e => e.CreatedOn).HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<Talent>()
                .Property(e => e.CreatedBy).HasDefaultValue("Application");

        }
    }
}
