using MaViCS.Business.Dtos;
using MaViCS.Domain.Models;

namespace MaViCS.Business.Dtos
{
    public static class ShowExtensions
    {

        public static Show ToShow(this CreateOrUpdateShowDto dto)
        {
            return new Show()
            {
                Date = dto.Date,
                LocationId = dto.LocationId
            };
        }

        public static Show UpdateShow(this Show show, CreateOrUpdateShowDto dto)
        {
            show.Date = dto.Date;
            show.LocationId = dto.LocationId;
            return show;
        }

        public static ShowDto ToShowDto(this Show show, bool loadTour = true)
        {
            ShowDto result = new ShowDto()
            {
                Id = show.Id,
                Date = show.Date,
            };

            if (show.Tour is not null && loadTour)
                result.Tour = show.Tour.ToTourDto(false);

            if (show.Location is not null)
                result.Location = show.Location.ToTownDto();

            return result;
        }

    }
}
