using MaViCS.Domain.Models;

namespace MaViCS.Domain.Interfaces
{
    public interface ITourRepository
    {

        Task<IEnumerable<Tour>> GetTours(bool ignoreArchived = true);

        Task<IEnumerable<Tour>> GetToursByTalent(long talentId, bool ignoreArchived = true);

        Task<Tour?> GetTourById(long id, bool ignoreArchived = true);

        Task<Tour?> AddTour(Tour tour);

        Task<Tour?> UpdateTour(Tour tour);

        Task<bool> ArchiveTour(long id);

        Task<bool> DeleteTour(long id);

    }
}
