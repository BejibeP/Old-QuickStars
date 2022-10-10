using System.Collections.Generic;
using System.Reflection.Emit;

namespace MaViCS.Domain.Persistance
{
    /*
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var max = new User
            {
                Id = 1,
                RegisteredOn = DateTime.Now,
                Name = "Max",
                Surname = "McMann",
                Email = "max.mcmann@mail.com",
                Password = SecurityTools.HashPassword("password"),
                Order = "Attorney"
            };

            var armstrong = new User
            {
                Id = 2,
                RegisteredOn = DateTime.Now,
                Name = "S.",
                Surname = "Armstrong",
                Email = "s.armstrong@mail.com",
                Password = SecurityTools.HashPassword("Nanomachines"),
                Order = "Senator"
            };

            var claire = new User
            {
                Id = 3,
                RegisteredOn = DateTime.Now,
                Name = "Jill",
                Surname = "Valentine",
                Email = "claire.redfield@mail.com",
                Password = SecurityTools.HashPassword("password"),
                Order = "S.T.A.R.S"
            };

            var gura = new User
            {
                Id = 4,
                RegisteredOn = DateTime.Now,
                Name = "Gura",
                Surname = "Gawr",
                Email = "gura.gawr@mail.com",
                Password = SecurityTools.HashPassword("shaaark"),
                Order = "Shark Girl Idol"
            };

            modelBuilder.Entity<User>().HasData(max, armstrong, claire, gura);
        }
*/
    }