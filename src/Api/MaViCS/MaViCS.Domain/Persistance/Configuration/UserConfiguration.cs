using MaViCS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MaViCS.Domain.Persistance.Configuration
{
    public static class UserConfiguration
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<User>()
                .Property(x => x.CreatedOn).HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<User>()
                .Property(x => x.CreatedBy).HasDefaultValue("Application");

        }
    }
}
