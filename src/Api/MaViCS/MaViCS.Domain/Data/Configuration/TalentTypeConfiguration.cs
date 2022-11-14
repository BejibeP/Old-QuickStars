using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickStars.MaViCS.Domain.Data.Entities;

namespace QuickStars.MaViCS.Domain.Data.Configuration
{
    public class TalentTypeConfiguration : BaseEntityTypeConfiguration<Talent>
    {
        public static TalentTypeConfiguration GetTypeConfiguration()
        {
            return new TalentTypeConfiguration();
        }

        public override void Configure(EntityTypeBuilder<Talent> builder)
        {
            base.Configure(builder);

            builder.HasIndex(e => new { e.FirstName, e.LastName })
                .IsUnique();
        }

    }
}