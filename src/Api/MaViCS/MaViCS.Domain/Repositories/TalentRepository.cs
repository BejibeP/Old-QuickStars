using MaViCS.Domain.Interfaces;
using MaViCS.Domain.Models;
using MaViCS.Domain.Persistance;
using Microsoft.EntityFrameworkCore;

namespace MaViCS.Domain.Repositories
{
    public class TalentRepository : ITalentRepository
    {
        private readonly DatabaseContext _databaseContext;

        public TalentRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Talent>> GetTalents(bool ignoreArchived = true, bool loadIncludes = true)
        {
            IQueryable<Talent> query = _databaseContext.Talents;

            if (loadIncludes) query = query.Include(x => x.HomeTown);

            if (ignoreArchived) query = query.Where(x => x.DeletedOn == null);

            return await query.ToListAsync();
        }

        public async Task<Talent?> GetTalentById(long id, bool ignoreArchived = true, bool loadIncludes = true)
        {
            IQueryable<Talent> query = _databaseContext.Talents;

            if (loadIncludes) query = query.Include(x => x.HomeTown);

            if (ignoreArchived) query = query.Where(x => x.DeletedOn == null);

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Talent?> AddTalent(Talent talent)
        {
            talent.CreatedOn = DateTime.UtcNow;

            var entry = await _databaseContext.Talents.AddAsync(talent);
            await _databaseContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<Talent?> UpdateTalent(Talent talent)
        {
            talent.ModifiedOn = DateTime.UtcNow;

            var entry = _databaseContext.Talents.Update(talent);
            await _databaseContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<bool> ArchiveTalent(long id)
        {
            var talent = await _databaseContext.Talents.FirstOrDefaultAsync(x => x.Id == id);

            if (talent is null || talent.DeletedOn is not null) return false;

            talent.DeletedOn = DateTime.UtcNow;

            _databaseContext.Talents.Update(talent);
            await _databaseContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteTalent(long id)
        {
            var talent = await _databaseContext.Talents.FirstOrDefaultAsync(x => x.Id == id);

            if (talent is null) return false;

            _databaseContext.Talents.Remove(talent);
            await _databaseContext.SaveChangesAsync();

            return true;
        }

    }
}
