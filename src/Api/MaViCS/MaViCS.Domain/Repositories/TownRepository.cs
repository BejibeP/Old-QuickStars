using MaViCS.Domain.Interfaces;
using MaViCS.Domain.Models;
using MaViCS.Domain.Persistance;
using Microsoft.EntityFrameworkCore;

namespace MaViCS.Domain.Repositories
{
    public class TownRepository : ITownRepository
    {
        private readonly DatabaseContext _databaseContext;

        public TownRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Town>> GetTowns(bool ignoreArchived = true)
        {
            IQueryable<Town> query = _databaseContext.Towns;

            if (ignoreArchived) query = query.Where(x => x.DeletedOn == null);

            return await query.ToListAsync();
        }

        public async Task<Town?> GetTownById(long id, bool ignoreArchived = true)
        {
            IQueryable<Town> query = _databaseContext.Towns;

            if (ignoreArchived) query = query.Where(x => x.DeletedOn == null);

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Town?> AddTown(Town town)
        {
            town.CreatedOn = DateTime.UtcNow;

            var entry = await _databaseContext.Towns.AddAsync(town);
            await _databaseContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<Town?> UpdateTown(Town town)
        {
            town.ModifiedOn = DateTime.UtcNow;

            var entry = _databaseContext.Towns.Update(town);
            await _databaseContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<bool> ArchiveTown(long id)
        {
            var town = await _databaseContext.Towns.FirstOrDefaultAsync(x => x.Id == id);

            if (town is null || town.DeletedOn is not null) return false;

            town.DeletedOn = DateTime.UtcNow;

            _databaseContext.Towns.Update(town);
            await _databaseContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteTown(long id)
        {
            var town = await _databaseContext.Towns.FirstOrDefaultAsync(x => x.Id == id);

            if (town is null) return false;

            _databaseContext.Towns.Remove(town);
            await _databaseContext.SaveChangesAsync();

            return true;
        }

    }
}
