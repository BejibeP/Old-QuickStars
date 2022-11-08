using QuickStars.MaViCS.Domain.Data;
using QuickStars.MaViCS.Domain.Data.Entities;
using QuickStars.MaViCS.Domain.Interfaces;

namespace QuickStars.MaViCS.Domain.Repositories
{
    public class TalentRepository : BaseRepository<Talent>, ITalentRepository
    {

        public TalentRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

    }
}
