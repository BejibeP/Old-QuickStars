using MaViCS.Domain.Framework.Habilitation;
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

            modelBuilder.Entity<User>()
                .Property(x => x.Role).HasDefaultValue(UserRoleEnum.None);

            modelBuilder.Entity<User>()
                .Property(x => x.ResetPassword).HasDefaultValue(false);

            modelBuilder.Entity<User>()
                .Property(x => x.Enabled).HasDefaultValue(false);

        }
    }
}
