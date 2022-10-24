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

        public async Task<IEnumerable<Talent>> GetTalents(bool ignoreArchived = true)
        {
            if (!ignoreArchived)
                return await _databaseContext.Talents.ToListAsync();

            return await _databaseContext.Talents.Where(x => x.DeletedOn == null).ToListAsync();
        }

        public async Task<Talent?> GetTalentById(long id, bool ignoreArchived = true)
        {
            if (!ignoreArchived)
                return await _databaseContext.Talents.FirstOrDefaultAsync(x => x.Id == id);

            return await _databaseContext.Talents.FirstOrDefaultAsync(x => x.Id == id && x.DeletedOn == null);
        }

        public async Task<Talent?> AddTalent(Talent talent)
        {
            var entry = await _databaseContext.Talents.AddAsync(talent);
            await _databaseContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<Talent?> UpdateTalent(Talent talent)
        {
            bool isNotArchived = await _databaseContext.Talents.AnyAsync(x => x.Id == talent.Id & talent.DeletedOn == null);
            if (isNotArchived) return null;

            var entry = _databaseContext.Talents.Update(talent);
            await _databaseContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<bool> ArchiveTalent(long id)
        {
            var talent = await _databaseContext.Talents.FirstOrDefaultAsync(x => x.Id == id);

            if (talent is null || talent.DeletedOn is not null) return false;

            talent.DeletedOn = DateTime.Now;

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
