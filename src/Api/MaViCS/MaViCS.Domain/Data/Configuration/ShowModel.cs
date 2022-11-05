using Microsoft.EntityFrameworkCore;
using QuickStars.MaViCS.Domain.Data.Models;

namespace QuickStars.MaViCS.Domain.Data.Configuration
{
    public static class ShowModel
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Show>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Show>()
                .Property(x => x.CreatedOn).HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<Show>()
                .Property(x => x.CreatedBy).HasDefaultValue("Application");

        }
    }
}
