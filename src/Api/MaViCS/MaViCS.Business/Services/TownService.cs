using MaViCS.Business.Dtos;
using MaViCS.Business.Interfaces;
using MaViCS.Domain.Interfaces;

namespace MaViCS.Business.Services
{
    public class TownService : ITownService
    {
        public ITownRepository _townRepository;

        public TownService(ITownRepository townRepository)
        {
            _townRepository = townRepository;
        }

        public List<TownDto> GetTowns()
        {
            return _townRepository.GetTowns()
                .Select(x => x.ToTownDto())
                .ToList();
        }

        public TownDto? GetTownById(long id)
        {
            return _townRepository.GetTownById(id)?.ToTownDto();
        }

        public TownDto? AddTown(CreateOrUpdateTownDto townDto)
        {
            var town = townDto.ToTown();

            return _townRepository.AddTown(town)?.ToTownDto();
        }

        public TownDto? UpdateTown(long id, CreateOrUpdateTownDto townDto)
        {
            var town = townDto.ToTown();
            town.Id = id;

            return _townRepository.UpdateTown(town)?.ToTownDto();
        }

        public bool ArchiveTown(long id)
        {
            return _townRepository.ArchiveTown(id);
        }

        public bool DeleteTown(long id)
        {
            return _townRepository.DeleteTown(id);
        }

    }
}
