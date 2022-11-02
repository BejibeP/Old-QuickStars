using MaViCS.Domain.Interfaces;
using MaViCS.Domain.Models;
using MaViCS.Domain.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MaViCS.Domain.Repositories
{
    public class TourRepository : BaseRepository<Tour>, ITourRepository
    {
        public TourRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public async Task<IEnumerable<Tour>> GetByTalent(long talentId, bool ignoreArchived = true, params Expression<Func<Tour, object>>[] includes)
        {
            IQueryable<Tour> query = _databaseContext.Tours;

            foreach (var include in includes)
                query = query.Include(include);

            if (ignoreArchived) query = query.Where(x => x.DeletedOn == null);

            return await query.Where(x => x.TalentId == talentId).ToListAsync();
        }
    }
}
