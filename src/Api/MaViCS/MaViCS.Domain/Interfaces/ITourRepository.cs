using MaViCS.Domain.Models;

namespace MaViCS.Domain.Interfaces
{
    public interface ITourRepository
    {

        List<Tour> GetTours(bool ignoreArchived = true);

        List<Tour> GetToursByTalent(long talentId, bool ignoreArchived = true);

        Tour? GetTourById(long id, bool ignoreArchived = true);

        Tour? AddTour(Tour tour);

        Tour? UpdateTour(Tour tour);

        bool ArchiveTour(long id);

        bool DeleteTour(long id);

    }
}
