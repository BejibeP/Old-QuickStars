using MaViCS.Business.Dtos;
using MaViCS.Business.Interfaces;
using MaViCS.Domain.Interfaces;
using MaViCS.Domain.Models;
using MaViCS.Domain.Repositories;

namespace MaViCS.Business.Services
{
    public class TourService : ITourService
    {
        public readonly ITourRepository _tourRepository;
        public readonly IShowRepository _showRepository;

        public TourService(ITourRepository tourRepository, IShowRepository showRepository)
        {
            _tourRepository = tourRepository;
            _showRepository = showRepository;
        }

        public async Task<IEnumerable<TourDto>> GetTours()
        {
            var tours = await _tourRepository.GetTours();

            return tours.Select(x => x.ToTourDto()).ToList();
        }

        public async Task<IEnumerable<TourDto>> GetToursByTalent(long talentId)
        {
            var tours = await _tourRepository.GetToursByTalent(talentId);

            return tours.Select(x => x.ToTourDto()).ToList();
        }

        public async Task<IOrderedEnumerable<ShowDto>> GetShowsByTour(long tourId)
        {
            var shows = await _showRepository.GetShowsByTour(tourId);

            return shows.Select(x => x.ToShowDto()).OrderBy(x => x.Date);
        }

        public async Task<TourDto?> GetTourById(long id)
        {
            var tour = await _tourRepository.GetTourById(id);

            return tour?.ToTourDto();
        }

        public async Task<TourDto?> AddTour(CreateOrUpdateTourDto tourDto)
        {
            var tour = tourDto.ToTour();

            tour = await _tourRepository.AddTour(tour);

            return tour?.ToTourDto();
        }

        public async Task<TourDto?> UpdateTour(long id, CreateOrUpdateTourDto tourDto)
        {
            var tour = await _tourRepository.GetTourById(id);

            if (tour == null)
                return null;

            tour = tour.UpdateTour(tourDto);

            tour = await _tourRepository.UpdateTour(tour);
            return tour?.ToTourDto();
        }

        public async Task<ShowDto?> AddShow(long tourId, CreateOrUpdateShowDto showDto)
        {
            var tour = await _tourRepository.GetTourById(tourId);

            if (tour == null)
                return null;

            var show = showDto.ToShow();
            show.TourId = tourId;

            show = await _showRepository.AddShow(show);
            return show?.ToShowDto();
        }

        public async Task<ShowDto?> UpdateShow(long showId, CreateOrUpdateShowDto showDto)
        {
            var show = await _showRepository.GetShowById(showId);

            if (show == null)
                return null;

            show = show.UpdateShow(showDto);

            show = await _showRepository.AddShow(show);
            return show?.ToShowDto();
        }

        public async Task<bool> ArchiveTour(long id)
        {
            return await _tourRepository.ArchiveTour(id);
        }

        public async Task<bool> DeleteTour(long id)
        {
            return await _tourRepository.DeleteTour(id);
        }

        public async Task<bool> DeleteShow(long id)
        {
            return await _showRepository.DeleteShow(id);
        }

    }
}
