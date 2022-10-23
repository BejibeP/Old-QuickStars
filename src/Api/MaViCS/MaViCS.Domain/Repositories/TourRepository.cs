using MaViCS.Domain.Interfaces;
using MaViCS.Domain.Models;
using MaViCS.Domain.Persistance;

namespace MaViCS.Domain.Repositories
{
    public class TourRepository : ITourRepository
    {
        private readonly DatabaseContext _databaseContext;

        public TourRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<Tour> GetTours(bool ignoreArchived = true)
        {
            if (!ignoreArchived)
                return _databaseContext.Tours.ToList();

            return _databaseContext.Tours.Where(x => x.DeletedOn == null).ToList();
        }

        public List<Tour> GetToursByTalent(long talentId, bool ignoreArchived = true)
        {
            if (!ignoreArchived)
                return _databaseContext.Tours.Where(x => x.TalentId == talentId).ToList();

            return _databaseContext.Tours.Where(x => x.TalentId == talentId && x.DeletedOn == null).ToList();
        }

        public Tour? GetTourById(long id, bool ignoreArchived = true)
        {
            if (!ignoreArchived)
                return _databaseContext.Tours.FirstOrDefault(x => x.Id == id);

            return _databaseContext.Tours.FirstOrDefault(x => x.Id == id && x.DeletedOn == null);
        }

        public Tour? AddTour(Tour tour)
        {
            var entry = _databaseContext.Tours.Add(tour);
            _databaseContext.SaveChanges();

            return entry.Entity;
        }

        public Tour? UpdateTour(Tour tour)
        {
            bool isNotArchived = _databaseContext.Tours.Any(x => x.Id == tour.Id & tour.DeletedOn == null);
            if (isNotArchived) return null;

            var entry = _databaseContext.Tours.Update(tour);
            _databaseContext.SaveChanges();

            return entry.Entity;
        }

        public bool ArchiveTour(long id)
        {
            var tour = _databaseContext.Tours.FirstOrDefault(x => x.Id == id);

            if (tour is null || tour.DeletedOn is not null) return false;

            tour.DeletedOn = DateTime.Now;

            _databaseContext.Tours.Update(tour);
            _databaseContext.SaveChanges();

            return true;
        }

        public bool DeleteTour(long id)
        {
            var tour = _databaseContext.Tours.FirstOrDefault(x => x.Id == id);

            if (tour is null) return false;

            _databaseContext.Tours.Remove(tour);
            _databaseContext.SaveChanges();

            return true;
        }

    }
}
