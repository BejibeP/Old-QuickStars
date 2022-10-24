using MaViCS.Domain.Models;

namespace MaViCS.Domain.Interfaces
{
    public interface IShowRepository
    {

        Task<IEnumerable<Show>> GetShows(bool ignoreArchived = true);

        Task<IEnumerable<Show>> GetShowsByTour(long tourId, bool ignoreArchived = true);

        Task<Show?> GetShowById(long id, bool ignoreArchived = true);

        Task<Show?> AddShow(Show show);

        Task<Show?> UpdateShow(Show show);

        Task<bool> ArchiveShow(long id);

        Task<bool> DeleteShow(long id);

    }
}
