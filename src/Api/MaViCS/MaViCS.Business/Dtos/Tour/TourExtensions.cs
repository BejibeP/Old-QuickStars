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
                Name = dto.Name,
                Description = dto.Description,
                StartedOn = dto.StartedOn
            };
        }

        public static Tour UpdateTour(this Tour tour, CreateOrUpdateTourDto dto)
        {
            tour.TalentId = dto.TalentId;
            tour.Name = dto.Name;
            tour.Description = dto.Description;
            tour.StartedOn = dto.StartedOn;
            return tour;
        }

        public static TourDto ToTourDto(this Tour tour)
        {
            TourDto result = new TourDto()
            {
                Id = tour.Id,
                Name = tour.Name,
                Description = tour.Description,
                StartedOn = tour.StartedOn,
            };

            if (tour.Talent is not null)
                result.Talent = tour.Talent.ToTalentDto();

            if (tour.Shows is not null)
                result.Shows = tour.Shows.Select(x => x.ToShowDto()).ToList();

            return result;
        }

    }
}
