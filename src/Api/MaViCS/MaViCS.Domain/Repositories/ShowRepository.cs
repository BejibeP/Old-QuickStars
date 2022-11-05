using Microsoft.EntityFrameworkCore;
using QuickStars.MaViCS.Domain.Data;
using QuickStars.MaViCS.Domain.Data.Models;
using QuickStars.MaViCS.Domain.Interfaces;
using System.Linq.Expressions;

namespace QuickStars.MaViCS.Domain.Repositories
{
    public class ShowRepository : BaseRepository<Show>, IShowRepository
    {

        public ShowRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public async Task<IEnumerable<Show>> GetByTalent(long talentId, bool ignoreArchived = true, params Expression<Func<Show, object>>[] includes)
        {
            IQueryable<Show> query = _databaseContext.Shows;

            foreach (var include in includes)
                query = query.Include(include);

            if (ignoreArchived) query = query.Where(e => e.DeletedOn == null);

            return await query.Where(e => e.TalentId == talentId).ToListAsync();
        }

    }
}
