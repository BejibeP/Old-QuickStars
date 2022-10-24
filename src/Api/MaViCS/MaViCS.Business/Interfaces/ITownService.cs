using MaViCS.Business.Dtos;

namespace MaViCS.Business.Interfaces
{
    public interface ITownService
    {

        Task<IEnumerable<TownDto>> GetTowns();

        Task<TownDto?> GetTownById(long id);

        Task<TownDto?> AddTown(CreateOrUpdateTownDto shrineDto);

        Task<TownDto?> UpdateTown(long id, CreateOrUpdateTownDto shrineDto);

        Task<bool> ArchiveTown(long id);

        Task<bool> DeleteTown(long id);

    }
}
