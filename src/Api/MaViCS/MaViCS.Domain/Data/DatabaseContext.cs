using Microsoft.EntityFrameworkCore;
using QuickStars.MaViCS.Domain.Data.Configuration;
using QuickStars.MaViCS.Domain.Data.Models;
using QuickStars.MaViCS.Domain.Interfaces;
using static QuickStars.MaViCS.Domain.Security.UserHabilitation;

namespace QuickStars.MaViCS.Domain.Data
{
    public class DatabaseContext : DbContext
    {

        private readonly ISecurityService _securityService;

        public DatabaseContext(DbContextOptions<DatabaseContext> options, ISecurityService securityService) : base(options)
        {
            _securityService = securityService;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Talent> Talents { get; set; }
        public DbSet<Show> Shows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UserModel.OnModelCreating(modelBuilder);
            TalentModel.OnModelCreating(modelBuilder);
            ShowModel.OnModelCreating(modelBuilder);

            OnModelInitialize(modelBuilder);
        }

        private void OnModelInitialize(ModelBuilder modelBuilder)
        {
            var supervisor = new User
            {
                Id = 1,
                Username = "superviseur",
                Password = _securityService.HashPassword("admin"),
                Role = UserRoleEnum.Administrator,
                ResetPassword = true,
                Enabled = true
            };

            modelBuilder.Entity<User>().HasData(supervisor);
        }

    }
}