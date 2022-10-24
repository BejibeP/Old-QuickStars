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

        public async Task<IEnumerable<Tour>> GetTours(bool ignoreArchived = true)
        {
            if (!ignoreArchived)
                return await _databaseContext.Tours.ToListAsync();

            return await _databaseContext.Tours.Where(x => x.DeletedOn == null).ToListAsync();
        }

        public async Task<IEnumerable<Tour>> GetToursByTalent(long talentId, bool ignoreArchived = true)
        {
            if (!ignoreArchived)
                return await _databaseContext.Tours.Where(x => x.TalentId == talentId).ToListAsync();

            return await _databaseContext.Tours.Where(x => x.TalentId == talentId && x.DeletedOn == null).ToListAsync();
        }

        public async Task<Tour?> GetTourById(long id, bool ignoreArchived = true)
        {
            if (!ignoreArchived)
                return await _databaseContext.Tours.FirstOrDefaultAsync(x => x.Id == id);

            return await _databaseContext.Tours.FirstOrDefaultAsync(x => x.Id == id && x.DeletedOn == null);
        }

        public async Task<Tour?> AddTour(Tour tour)
        {
            var entry = await _databaseContext.Tours.AddAsync(tour);
            await _databaseContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<Tour?> UpdateTour(Tour tour)
        {
            bool isNotArchived = await _databaseContext.Tours.AnyAsync(x => x.Id == tour.Id & tour.DeletedOn == null);
            if (isNotArchived) return null;

            var entry = _databaseContext.Tours.Update(tour);
            await _databaseContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<bool> ArchiveTour(long id)
        {
            var tour = await _databaseContext.Tours.FirstOrDefaultAsync(x => x.Id == id);

            if (tour is null || tour.DeletedOn is not null) return false;

            tour.DeletedOn = DateTime.Now;

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
