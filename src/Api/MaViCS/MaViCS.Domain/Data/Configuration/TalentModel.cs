using Microsoft.EntityFrameworkCore;
using QuickStars.MaViCS.Domain.Data.Entities;

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

        }
    }
}
