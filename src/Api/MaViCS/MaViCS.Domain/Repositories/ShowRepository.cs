using MaViCS.Domain.Interfaces;
using MaViCS.Domain.Models;
using MaViCS.Domain.Persistance;

namespace MaViCS.Domain.Repositories
{
    public class ShowRepository : IShowRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ShowRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<Show> GetShows(bool ignoreArchived = true)
        {
            if (!ignoreArchived)
                return _databaseContext.Shows.ToList();

            return _databaseContext.Shows.Where(x => x.DeletedOn == null).ToList();
        }

        public List<Show> GetShowsByTour(long tourId, bool ignoreArchived = true)
        {
            if (!ignoreArchived)
                return _databaseContext.Shows.Where(x => x.TourId == tourId).ToList();

            return _databaseContext.Shows.Where(x => x.TourId == tourId && x.DeletedOn == null).ToList();
        }

        public Show? GetShowById(long id, bool ignoreArchived = true)
        {
            if (!ignoreArchived)
                return _databaseContext.Shows.FirstOrDefault(x => x.Id == id);

            return _databaseContext.Shows.FirstOrDefault(x => x.Id == id && x.DeletedOn == null);
        }

        public Show? AddShow(Show show)
        {
            var entry = _databaseContext.Shows.Add(show);
            _databaseContext.SaveChanges();

            return entry.Entity;
        }

        public Show? UpdateShow(Show show)
        {
            bool isNotArchived = _databaseContext.Shows.Any(x => x.Id == show.Id & show.DeletedOn == null);
            if (isNotArchived) return null;

            var entry = _databaseContext.Shows.Update(show);
            _databaseContext.SaveChanges();

            return entry.Entity;
        }

        public bool ArchiveShow(long id)
        {
            var show = _databaseContext.Shows.FirstOrDefault(x => x.Id == id);

            if (show is null || show.DeletedOn is not null) return false;

            show.DeletedOn = DateTime.Now;

            _databaseContext.Shows.Update(show);
            _databaseContext.SaveChanges();

            return true;
        }

        public bool DeleteShow(long id)
        {
            var show = _databaseContext.Shows.FirstOrDefault(x => x.Id == id);

            if (show is null) return false;

            _databaseContext.Shows.Remove(show);
            _databaseContext.SaveChanges();

            return true;
        }

    }
}
