using MaViCS.Business.Dtos;
using MaViCS.Business.Interfaces;
using MaViCS.Domain.Interfaces;
using MaViCS.Domain.Models;
using MaViCS.Domain.Repositories;

namespace MaViCS.Business.Services
{
    public class ShowService : IShowService
    {
        public readonly ITourRepository _tourRepository;
        public readonly IShowRepository _showRepository;

        public ShowService(ITourRepository tourRepository, IShowRepository showRepository)
        {
            _tourRepository = tourRepository;
            _showRepository = showRepository;
        }

        public async Task<IOrderedEnumerable<ShowDto>> GetShowsByTour(long tourId)
        {
            var shows = await _showRepository.GetShowsByTour(tourId);

            return shows.Select(x => x.ToShowDto()).OrderBy(x => x.Date);
        }

        public async Task<ShowDto?> AddShow(long tourId, CreateOrUpdateShowDto showDto)
        {
            var tour = await _tourRepository.GetTourById(tourId, true, false);

            if (tour == null)
                return null;

            var show = showDto.ToShow();
            show.TourId = tourId;

            show = await _showRepository.AddShow(show);
            return show?.ToShowDto();
        }

        public async Task<ShowDto?> UpdateShow(long showId, CreateOrUpdateShowDto showDto)
        {
            var show = await _showRepository.GetShowById(showId, true, false);

            if (show == null)
                return null;

            show = show.UpdateShow(showDto);

            show = await _showRepository.UpdateShow(show);
            return show?.ToShowDto();
        }

        public async Task<bool> DeleteShow(long id)
        {
            return await _showRepository.DeleteShow(id);
        }

    }
}
