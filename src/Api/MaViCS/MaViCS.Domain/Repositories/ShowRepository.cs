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

        public async Task<IEnumerable<Show>> GetShows(bool ignoreArchived = true)
        {
            if (!ignoreArchived)
                return await _databaseContext.Shows.ToListAsync();

            return await _databaseContext.Shows.Where(x => x.DeletedOn == null).ToListAsync();
        }

        public async Task<IEnumerable<Show>> GetShowsByTour(long tourId, bool ignoreArchived = true)
        {
            if (!ignoreArchived)
                return await _databaseContext.Shows.Where(x => x.TourId == tourId).ToListAsync();

            return await _databaseContext.Shows.Where(x => x.TourId == tourId && x.DeletedOn == null).ToListAsync();
        }

        public async Task<Show?> GetShowById(long id, bool ignoreArchived = true)
        {
            if (!ignoreArchived)
                return await _databaseContext.Shows.FirstOrDefaultAsync(x => x.Id == id);

            return await _databaseContext.Shows.FirstOrDefaultAsync(x => x.Id == id && x.DeletedOn == null);
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
