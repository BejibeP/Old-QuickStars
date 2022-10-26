using MaViCS.Domain.Models;

namespace MaViCS.Domain.Interfaces
{
    public interface ITownRepository
    {

        Task<IEnumerable<Town>> GetTowns(bool ignoreArchived = true);

        Task<Town?> GetTownById(long id, bool ignoreArchived = true);

        Task<Town?> AddTown(Town town);

        Task<Town?> UpdateTown(Town town);

        Task<bool> ArchiveTown(long id);

        Task<bool> DeleteTown(long id);

    }
}
