using MaViCS.Domain.Interfaces;
using MaViCS.Domain.Models;
using MaViCS.Domain.Persistance;

namespace MaViCS.Domain.Repositories
{
    public class TalentRepository : ITalentRepository
    {
        private readonly DatabaseContext _databaseContext;

        public TalentRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<Talent> GetTalents(bool ignoreArchived = true)
        {
            if (!ignoreArchived)
                return _databaseContext.Talents.ToList();

            return _databaseContext.Talents.Where(x => x.DeletedOn == null).ToList();
        }

        public Talent? GetTalentById(long id, bool ignoreArchived = true)
        {
            if (!ignoreArchived)
                return _databaseContext.Talents.FirstOrDefault(x => x.Id == id);

            return _databaseContext.Talents.FirstOrDefault(x => x.Id == id && x.DeletedOn == null);
        }

        public Talent? AddTalent(Talent talent)
        {
            var entry = _databaseContext.Talents.Add(talent);
            _databaseContext.SaveChanges();

            return entry.Entity;
        }

        public Talent? UpdateTalent(Talent talent)
        {
            bool isNotArchived = _databaseContext.Talents.Any(x => x.Id == talent.Id & talent.DeletedOn == null);
            if (isNotArchived) return null;

            var entry = _databaseContext.Talents.Update(talent);
            _databaseContext.SaveChanges();

            return entry.Entity;
        }

        public bool ArchiveTalent(long id)
        {
            var talent = _databaseContext.Talents.FirstOrDefault(x => x.Id == id);

            if (talent is null || talent.DeletedOn is not null) return false;

            talent.DeletedOn = DateTime.Now;

            _databaseContext.Talents.Update(talent);
            _databaseContext.SaveChanges();

            return true;
        }

        public bool DeleteTalent(long id)
        {
            var talent = _databaseContext.Talents.FirstOrDefault(x => x.Id == id);

            if (talent is null) return false;

            _databaseContext.Talents.Remove(talent);
            _databaseContext.SaveChanges();

            return true;
        }

    }
}
