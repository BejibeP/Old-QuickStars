using MaViCS.Domain.Models;

namespace MaViCS.Domain.Interfaces
{
    public interface IShowRepository
    {

        List<Show> GetShows(bool ignoreArchived = true);

        List<Show> GetShowsByTour(long tourId, bool ignoreArchived = true);

        Show? GetShowById(long id, bool ignoreArchived = true);

        Show? AddShow(Show show);

        Show? UpdateShow(Show show);

        bool ArchiveShow(long id);

        bool DeleteShow(long id);

    }
}
