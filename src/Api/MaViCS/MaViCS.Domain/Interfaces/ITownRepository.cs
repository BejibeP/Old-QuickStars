using MaViCS.Domain.Models;

namespace MaViCS.Domain.Interfaces
{
    public interface ITownRepository
    {

        List<Town> GetTowns(bool ignoreArchived = true);

        Town? GetTownById(long id, bool ignoreArchived = true);

        Town? AddTown(Town town);

        Town? UpdateTown(Town town);

        bool ArchiveTown(long id);

        bool DeleteTown(long id);

    }
}
