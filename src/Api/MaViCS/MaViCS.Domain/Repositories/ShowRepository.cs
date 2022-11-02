using MaViCS.Domain.Interfaces;
using MaViCS.Domain.Models;
using MaViCS.Domain.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MaViCS.Domain.Repositories
{
    public class ShowRepository : BaseRepository<Show>, IShowRepository
    {
        public ShowRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public async Task<IEnumerable<Show>> GetByTour(long tourId, bool ignoreArchived = true, params Expression<Func<Show, object>>[] includes)
        {
            IQueryable<Show> query = _databaseContext.Shows;

            foreach (var include in includes)
                query = query.Include(include);

            if (ignoreArchived) query = query.Where(x => x.DeletedOn == null);

            return await query.Where(x => x.TourId == tourId).ToListAsync();
        }
    }
}
