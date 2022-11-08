using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace QuickStars.MaViCS.Domain.Data
{
    public class DatabaseContext : IdentityDbContext<IdentityUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        //public DbSet<User> Users { get; set; }
        //public DbSet<Talent> Talents { get; set; }
        //public DbSet<Show> Shows { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //    UserModel.OnModelCreating(modelBuilder);
            //    TalentModel.OnModelCreating(modelBuilder);
            //    ShowModel.OnModelCreating(modelBuilder);

            //    OnModelInitialize(modelBuilder);

            base.OnModelCreating(builder);
        }

        //protected override void OnModelInitialize(ModelBuilder builder)
        //{
        //    //    var supervisor = new User
        //    //    {
        //    //        Id = 1,
        //    //        Username = "superviseur",
        //    //        //Password = _securityService.HashPassword("admin"),
        //    //        ResetPassword = true,
        //    //        Enabled = true
        //    //    };

        // await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        // await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        // var supervisor = new IdentityUser
        //{
        // UserName = "superviseur",
        // SecurityStamp = Guid.NewGuid().ToString(),
        // Password = "admin"
        //}

        // var result = await _userManager.CreateAsync(user, model.Password);

        //    //    modelBuilder.Entity<User>().HasData(supervisor);
        //}


        //public override int SaveChanges()
        //{
        //    ApplyTimestampToEntries();
        //    return base.SaveChanges();
        //}

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    ApplyTimestampToEntries();
        //    return base.SaveChangesAsync(cancellationToken);
        //}

        //private void ApplyTimestampToEntries()
        //{
        //    var entries = ChangeTracker.Entries()
        //        .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        //    foreach (var entry in entries)
        //    {
        //        if (entry.Entity is not BaseEntity)
        //            continue;

        //        if (entry.State == EntityState.Added)
        //        {
        //            ((BaseEntity)entry.Entity).CreatedOn = DateTime.UtcNow;
        //            ((BaseEntity)entry.Entity).CreatedBy = "Application";
        //        }

        //        if (entry.State == EntityState.Modified)
        //        {
        //            ((BaseEntity)entry.Entity).ModifiedOn = DateTime.UtcNow;
        //            ((BaseEntity)entry.Entity).ModifiedBy = "Application";
        //        }
        //    }
        //}

    }
}
/*

public class User : BaseEntity
{

    public string Username { get; set; }

    public string Password { get; set; }

    public DateTime? LastLoggedOn { get; set; }

    public bool ResetPassword { get; set; }

    public bool Enabled { get; set; }

}

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
            .Property(e => e.ResetPassword).HasDefaultValue(false);

        modelBuilder.Entity<User>()
            .Property(e => e.Enabled).HasDefaultValue(false);

    }
}
*/