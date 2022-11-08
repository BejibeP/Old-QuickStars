using Microsoft.EntityFrameworkCore;
using QuickStars.MaViCS.Domain.Data.Entities;

namespace QuickStars.MaViCS.Domain.Data.Configuration
{
    public static class ShowModel
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Show>()
                .HasKey(x => x.Id);

        }
    }
}
