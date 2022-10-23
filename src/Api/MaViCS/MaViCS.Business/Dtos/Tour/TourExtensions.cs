using MaViCS.Domain.Models;

namespace MaViCS.Business.Dtos
{
    public static class TourExtensions
    {

        public static Tour ToTour(this CreateOrUpdateTourDto dto)
        {
            return new Tour()
            {
                TalentId = dto.TalentId,
                StartedOn = dto.StartedOn
            };
        }

        public static TourDto ToTourDto(this Tour tour)
        {
            TourDto result = new TourDto()
            {
                Id = tour.Id,
                StartedOn = tour.StartedOn,
            };

            if (tour.Talent is not null)
                result.Talent = tour.Talent.ToTalentDto();

            if (tour.Shows is not null)
                result.Shows = tour.Shows.Select(x => x.ToShowDto()).ToList();

            return result;
        }

        public static Show ToShow(this CreateOrUpdateShowDto dto)
        {
            return new Show()
            {
                Date = dto.Date,
                LocationId = dto.LocationId
            };
        }

        public static ShowDto ToShowDto(this Show show)
        {
            ShowDto result = new ShowDto()
            {
                Id = show.Id,
                Date = show.Date,
            };

            if (show.Tour is not null)
                result.Tour = show.Tour.ToTourDto();

            if (show.Location is not null)
                result.Location = show.Location.ToTownDto();

            return result;
        }

    }
}
