using MaViCS.Domain.Interfaces;
using MaViCS.Domain.Models;
using MaViCS.Domain.Persistance;

namespace MaViCS.Domain.Repositories
{
    public class TownRepository : ITownRepository
    {
        private readonly DatabaseContext _databaseContext;

        public TownRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<Town> GetTowns(bool ignoreArchived = true)
        {
            if (!ignoreArchived)
                return _databaseContext.Towns.ToList();

            return _databaseContext.Towns.Where(x => x.DeletedOn == null).ToList();
        }

        public Town? GetTownById(long id, bool ignoreArchived = true)
        {
            if (!ignoreArchived)
                return _databaseContext.Towns.FirstOrDefault(x => x.Id == id);

            return _databaseContext.Towns.FirstOrDefault(x => x.Id == id && x.DeletedOn == null);
        }

        public Town? AddTown(Town townn)
        {
            var entry = _databaseContext.Towns.Add(townn);
            _databaseContext.SaveChanges();

            return entry.Entity;
        }

        public Town? UpdateTown(Town town)
        {
            bool isNotArchived = _databaseContext.Towns.Any(x => x.Id == town.Id & town.DeletedOn == null);
            if (isNotArchived) return null;

            var entry = _databaseContext.Towns.Update(town);
            _databaseContext.SaveChanges();

            return entry.Entity;
        }

        public bool ArchiveTown(long id)
        {
            var town = _databaseContext.Towns.FirstOrDefault(x => x.Id == id);

            if (town is null || town.DeletedOn is not null) return false;

            town.DeletedOn = DateTime.Now;

            _databaseContext.Towns.Update(town);
            _databaseContext.SaveChanges();

            return true;
        }

        public bool DeleteTown(long id)
        {
            var town = _databaseContext.Towns.FirstOrDefault(x => x.Id == id);

            if (town is null) return false;

            _databaseContext.Towns.Remove(town);
            _databaseContext.SaveChanges();

            return true;
        }

    }
}
