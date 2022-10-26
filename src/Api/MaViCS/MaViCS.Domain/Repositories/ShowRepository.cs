using MaViCS.Domain.Interfaces;
using MaViCS.Domain.Models;
using MaViCS.Domain.Persistance;
using Microsoft.EntityFrameworkCore;

namespace MaViCS.Domain.Repositories
{
    public class ShowRepository : IShowRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ShowRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Show>> GetShows(bool ignoreArchived = true, bool loadIncludes = true)
        {
            IQueryable<Show> query = _databaseContext.Shows;

            if (loadIncludes)
                query = query.Include(x => x.Location)
                    .Include(x => x.Tour)
                    .ThenInclude(x => x.Talent);

            if (ignoreArchived) query = query.Where(x => x.DeletedOn == null);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Show>> GetShowsByTour(long tourId, bool ignoreArchived = true, bool loadIncludes = true)
        {
            IQueryable<Show> query = _databaseContext.Shows;

            if (loadIncludes)
                query = query.Include(x => x.Location)
                    .Include(x => x.Tour)
                    .ThenInclude(x => x.Talent);

            if (ignoreArchived) query = query.Where(x => x.DeletedOn == null);

            return await query.Where(x => x.TourId == tourId).ToListAsync();
        }

        public async Task<Show?> GetShowById(long id, bool ignoreArchived = true, bool loadIncludes = true)
        {
            IQueryable<Show> query = _databaseContext.Shows;

            if (loadIncludes)
                query = query.Include(x => x.Location)
                    .Include(x => x.Tour)
                    .ThenInclude(x => x.Talent);

            if (ignoreArchived) query = query.Where(x => x.DeletedOn == null);

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Show?> AddShow(Show show)
        {
            show.CreatedOn = DateTime.UtcNow;

            var entry = await _databaseContext.Shows.AddAsync(show);
            await _databaseContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<Show?> UpdateShow(Show show)
        {
            show.ModifiedOn = DateTime.UtcNow;

            var entry = _databaseContext.Shows.Update(show);
            await _databaseContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<bool> ArchiveShow(long id)
        {
            var show = await _databaseContext.Shows.FirstOrDefaultAsync(x => x.Id == id);

            if (show is null || show.DeletedOn is not null) return false;

            show.DeletedOn = DateTime.UtcNow;

            _databaseContext.Shows.Update(show);
            await _databaseContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteShow(long id)
        {
            var show = await _databaseContext.Shows.FirstOrDefaultAsync(x => x.Id == id);

            if (show is null) return false;

            _databaseContext.Shows.Remove(show);
            await _databaseContext.SaveChangesAsync();

            return true;
        }

    }
}
