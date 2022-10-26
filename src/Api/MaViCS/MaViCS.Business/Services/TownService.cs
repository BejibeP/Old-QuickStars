using MaViCS.Business.Dtos;
using MaViCS.Business.Interfaces;
using MaViCS.Domain.Interfaces;

namespace MaViCS.Business.Services
{
    public class TownService : ITownService
    {
        public readonly ITownRepository _townRepository;

        public TownService(ITownRepository townRepository)
        {
            _townRepository = townRepository;
        }

        public async Task<IEnumerable<TownDto>> GetTowns()
        {
            var towns = await _townRepository.GetTowns();

            return towns.Select(x => x.ToTownDto()).ToList();
        }

        public async Task<TownDto?> GetTownById(long id)
        {
            var town = await _townRepository.GetTownById(id);

            return town?.ToTownDto();
        }

        public async Task<TownDto?> AddTown(CreateOrUpdateTownDto townDto)
        {
            var town = townDto.ToTown();

            town = await _townRepository.AddTown(town);

            return town?.ToTownDto();
        }

        public async Task<TownDto?> UpdateTown(long id, CreateOrUpdateTownDto townDto)
        {
            var town = await _townRepository.GetTownById(id);

            if (town == null)
                return null;

            town = town.UpdateTown(townDto);

            town = await _townRepository.UpdateTown(town);

            return town?.ToTownDto();
        }

        public async Task<bool> ArchiveTown(long id)
        {
            return await _townRepository.ArchiveTown(id);
        }

        public async Task<bool> DeleteTown(long id)
        {
            return await _townRepository.DeleteTown(id);
        }

    }
}
