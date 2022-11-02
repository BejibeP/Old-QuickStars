using MaViCS.Domain.Framework.Authentication;
using MaViCS.Domain.Framework.Habilitation;
using MaViCS.Domain.Models;
using MaViCS.Domain.Persistance.Configuration;
using Microsoft.EntityFrameworkCore;

namespace MaViCS.Domain.Persistance
{
    public class DatabaseContext : DbContext
    {

        private readonly AuthHelper _securityHelper;

        public DbSet<User> Users { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Talent> Talents { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Show> Shows { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options, AuthHelper securityHelper) : base(options)
        {
            _securityHelper = securityHelper;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UserConfiguration.OnModelCreating(modelBuilder);
            TownConfiguration.OnModelCreating(modelBuilder);
            TalentConfiguration.OnModelCreating(modelBuilder);
            TourConfiguration.OnModelCreating(modelBuilder);
            ShowConfiguration.OnModelCreating(modelBuilder);

            OnModelInitialize(modelBuilder);
        }

        private void OnModelInitialize(ModelBuilder modelBuilder)
        {
            var supervisor = new User
            {
                Id = 1,
                Username = "superviseur",
                Password = _securityHelper.HashPassword("admin"),
                Role = UserRoleEnum.Administrator,
                ResetPassword = true,
                Enabled = true
            };

            modelBuilder.Entity<User>().HasData(supervisor);
        }

    }
}