using MaViCS.Domain.Interfaces;
using MaViCS.Domain.Models;
using MaViCS.Domain.Persistance;
using Microsoft.EntityFrameworkCore;

namespace MaViCS.Domain.Repositories
{
    public class TourRepository : ITourRepository
    {
        private readonly DatabaseContext _databaseContext;

        public TourRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Tour>> GetTours(bool ignoreArchived = true, bool loadIncludes = true)
        {
            IQueryable<Tour> query = _databaseContext.Tours;

            if (loadIncludes) 
                query = query.Include(x => x.Talent)
                    .Include(x => x.Shows)
                    .ThenInclude(x => x.Location);

            if (ignoreArchived) query = query.Where(x => x.DeletedOn == null);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Tour>> GetToursByTalent(long talentId, bool ignoreArchived = true, bool loadIncludes = true)
        {
            IQueryable<Tour> query = _databaseContext.Tours;

            if (loadIncludes)
                query = query.Include(x => x.Talent)
                    .Include(x => x.Shows)
                    .ThenInclude(x => x.Location);

            if (ignoreArchived) query = query.Where(x => x.DeletedOn == null);

            return await query.Where(x => x.TalentId == talentId).ToListAsync();
        }

        public async Task<Tour?> GetTourById(long id, bool ignoreArchived = true, bool loadIncludes = true)
        {
            IQueryable<Tour> query = _databaseContext.Tours;

            if (loadIncludes)
                query = query.Include(x => x.Talent)
                    .Include(x => x.Shows)
                    .ThenInclude(x => x.Location);

            if (ignoreArchived) query = query.Where(x => x.DeletedOn == null);

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tour?> AddTour(Tour tour)
        {
            tour.CreatedOn = DateTime.UtcNow;

            var entry = await _databaseContext.Tours.AddAsync(tour);
            await _databaseContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<Tour?> UpdateTour(Tour tour)
        {
            tour.ModifiedOn = DateTime.UtcNow;

            var entry = _databaseContext.Tours.Update(tour);
            await _databaseContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<bool> ArchiveTour(long id)
        {
            var tour = await _databaseContext.Tours.FirstOrDefaultAsync(x => x.Id == id);

            if (tour is null || tour.DeletedOn is not null) return false;

            tour.DeletedOn = DateTime.UtcNow;

            _databaseContext.Tours.Update(tour);
            await _databaseContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteTour(long id)
        {
            var tour = await _databaseContext.Tours.FirstOrDefaultAsync(x => x.Id == id);

            if (tour is null) return false;

            _databaseContext.Tours.Remove(tour);
            await _databaseContext.SaveChangesAsync();

            return true;
        }

    }
}
