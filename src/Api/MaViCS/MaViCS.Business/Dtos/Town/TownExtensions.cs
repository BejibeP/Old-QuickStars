using MaViCS.Domain.Models;

namespace MaViCS.Business.Dtos
{
    public static class TownExtensions
    {

        public static Town ToTown(this CreateOrUpdateTownDto dto)
        {
            return new Town()
            {
                Name = dto.Name,
                Region = dto.Region,
                Description = dto.Description,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude
            };
        }

        public static TownDto ToTownDto(this Town town)
        {
            return new TownDto()
            {
                Id = town.Id,
                Name = town.Name,
                Region = town.Region,
                Description = town.Description,
                Latitude = town.Latitude,
                Longitude = town.Longitude
            };
        }

    }
}
