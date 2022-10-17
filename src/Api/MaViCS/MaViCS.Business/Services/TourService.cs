using MaViCS.Business.Dtos;
using MaViCS.Business.Interfaces;
using MaViCS.Domain.Interfaces;

namespace MaViCS.Business.Services
{
    public class TourService : ITourService
    {
        public ITourRepository _tourRepository;
        public IShowRepository _showRepository;

        public TourService(ITourRepository tourRepository, IShowRepository showRepository)
        {
            _tourRepository = tourRepository;
            _showRepository = showRepository;
        }

        public List<TourDto> GetTours()
        {
            return _tourRepository.GetTours()
                .Select(x => x.ToTourDto())
                .ToList();
        }

        public List<TourDto> GetToursByTalent(long talentId)
        {
            return _tourRepository.GetToursByTalent(talentId)
                .Select(x => x.ToTourDto())
                .ToList();
        }

        public IOrderedEnumerable<ShowDto> GetShowsByTour(long tourId)
        {
            return _showRepository.GetShowsByTour(tourId)
                .Select(x => x.ToShowDto())
                .OrderBy(x => x.Date);
        }

        public TourDto? GetTourById(long id)
        {
            return _tourRepository.GetTourById(id)?.ToTourDto();
        }

        public TourDto? AddTour(CreateOrUpdateTourDto tourDto)
        {
            var tour = tourDto.ToTour();

            return _tourRepository.AddTour(tour)?.ToTourDto();
        }

        public TourDto? UpdateTour(long id, CreateOrUpdateTourDto tourDto)
        {
            var tour = tourDto.ToTour();
            tour.Id = id;

            return _tourRepository.UpdateTour(tour)?.ToTourDto();
        }

        public ShowDto? AddShow(long tourId, CreateOrUpdateShowDto showDto)
        {
            var show = showDto.ToShow();
            show.TourId = tourId;

            return _showRepository.AddShow(show)?.ToShowDto();
        }

        public ShowDto? UpdateShow(long id, long tourId, CreateOrUpdateShowDto showDto)
        {
            var show = showDto.ToShow();
            show.Id = id;
            show.TourId = tourId;

            return _showRepository.AddShow(show)?.ToShowDto();
        }

        public bool ArchiveTour(long id)
        {
            return _tourRepository.ArchiveTour(id);
        }

        public bool DeleteTour(long id)
        {
            return _tourRepository.DeleteTour(id);
        }

        public bool DeleteShow(long id)
        {
            return _showRepository.DeleteShow(id);
        }

    }
}
