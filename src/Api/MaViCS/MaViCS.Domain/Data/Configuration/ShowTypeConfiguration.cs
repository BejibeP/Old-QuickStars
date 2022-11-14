using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickStars.MaViCS.Domain.Data.Entities;

namespace QuickStars.MaViCS.Domain.Data.Configuration
{
    public class ShowTypeConfiguration : BaseEntityTypeConfiguration<Show>
    {
        public static ShowTypeConfiguration GetTypeConfiguration()
        {
            return new ShowTypeConfiguration();
        }

        public override void Configure(EntityTypeBuilder<Show> builder)
        {
            base.Configure(builder);

            builder.HasOne(e => e.Talent);

        }

    }
}