using Enki.Domain.Models;
using Enki.Tools;
using Microsoft.EntityFrameworkCore;

namespace Enki.Domain
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Shrine> Shrines { get; set; }
        public DbSet<Pilgrimage> Pilgrimages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pilgrimage>()
                    .HasKey(s => new { s.UserId, s.ShrineId });

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

            var atlantis = new Shrine { Id = 1, ConstructionDate = DateTime.MinValue, DeityName = "Poseidon", ShrineName = "Ruin of Atlantis" };
            var valhalla = new Shrine { Id = 2, ConstructionDate = DateTime.MinValue, DeityName = "Odin", ShrineName = "Valhalla" };
            var nazareth = new Shrine { Id = 3, ConstructionDate = DateTime.MinValue, DeityName = "Jesus", ShrineName = "Nazareth" };

            var pilgrimG1 = new Pilgrimage { ShrineId = atlantis.Id, UserId = gura.Id };
            var pilgrimG2 = new Pilgrimage { ShrineId = valhalla.Id, UserId = gura.Id };
            var pilgrimC1 = new Pilgrimage { ShrineId = atlantis.Id, UserId = claire.Id };
            var pilgrimA1 = new Pilgrimage { ShrineId = nazareth.Id, UserId = armstrong.Id };
            var pilgrimA2 = new Pilgrimage { ShrineId = valhalla.Id, UserId = armstrong.Id };
            var pilgrimM1 = new Pilgrimage { ShrineId = valhalla.Id, UserId = max.Id };

            modelBuilder.Entity<User>().HasData(max, armstrong, claire, gura);
            modelBuilder.Entity<Shrine>().HasData(atlantis, valhalla, nazareth);
            modelBuilder.Entity<Pilgrimage>().HasData(pilgrimG1, pilgrimG2, pilgrimC1, pilgrimA1, pilgrimA2, pilgrimM1);

        }

    }
}
