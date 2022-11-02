using MaViCS.Business.Dtos;
using MaViCS.Business.Interfaces;
using MaViCS.Domain.Interfaces;

namespace MaViCS.Business.Services
{
    public class TourService : ITourService
    {
        public readonly ITourRepository _tourRepository;

        public TourService(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }

        public async Task<IEnumerable<TourDto>> GetTours()
        {
            var tours = await _tourRepository.GetAll();

            return tours.Select(x => x.ToTourDto()).ToList();
        }

        public async Task<IEnumerable<TourDto>> GetToursByTalent(long talentId)
        {
            var tours = await _tourRepository.GetByTalent(talentId);

            return tours.Select(x => x.ToTourDto()).ToList();
        }

        public async Task<TourDto?> GetTourById(long id)
        {
            var tour = await _tourRepository.GetById(id);

            return tour?.ToTourDto();
        }

        public async Task<TourDto?> AddTour(CreateOrUpdateTourDto tourDto)
        {
            var tour = tourDto.ToTour();

            tour = await _tourRepository.Create(tour);

            return tour?.ToTourDto();
        }

        public async Task<TourDto?> UpdateTour(long id, CreateOrUpdateTourDto tourDto)
        {
            var tour = await _tourRepository.GetById(id, true, null);

            if (tour == null)
                return null;

            tour = tour.UpdateTour(tourDto);

            tour = await _tourRepository.Update(tour);
            return tour?.ToTourDto();
        }

        public async Task<bool> ArchiveTour(long id)
        {
            return await _tourRepository.Archive(id);
        }

        public async Task<bool> DeleteTour(long id)
        {
            return await _tourRepository.Delete(id);
        }

    }
}
