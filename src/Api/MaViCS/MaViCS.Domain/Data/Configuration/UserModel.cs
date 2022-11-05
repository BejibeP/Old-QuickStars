using Microsoft.EntityFrameworkCore;
using QuickStars.MaViCS.Domain.Data.Models;
using static QuickStars.MaViCS.Domain.Security.UserHabilitation;

namespace QuickStars.MaViCS.Domain.Data.Configuration
{
    public class UserModel
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<User>()
                .HasIndex(e => e.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(e => e.CreatedOn).HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<User>()
                .Property(e => e.CreatedBy).HasDefaultValue("Application");

            modelBuilder.Entity<User>()
                .Property(e => e.Role).HasDefaultValue(UserRoleEnum.None);

            modelBuilder.Entity<User>()
                .Property(e => e.ResetPassword).HasDefaultValue(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Enabled).HasDefaultValue(false);

        }
    }
}
