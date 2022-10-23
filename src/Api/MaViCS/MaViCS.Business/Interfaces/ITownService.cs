using MaViCS.Business.Dtos;

namespace MaViCS.Business.Interfaces
{
    public interface ITownService
    {

        List<TownDto> GetTowns();

        TownDto? GetTownById(long id);

        TownDto? AddTown(CreateOrUpdateTownDto shrineDto);

        TownDto? UpdateTown(long id, CreateOrUpdateTownDto shrineDto);

        bool ArchiveTown(long id);

        bool DeleteTown(long id);

    }
}
