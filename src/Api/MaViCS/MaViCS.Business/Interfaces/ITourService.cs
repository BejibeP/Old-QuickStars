using MaViCS.Business.Dtos;

namespace MaViCS.Business.Interfaces
{
    public interface ITourService
    {

        Task<IEnumerable<TourDto>> GetTours();

        Task<IEnumerable<TourDto>> GetToursByTalent(long talentId);

        Task<IOrderedEnumerable<ShowDto>> GetShowsByTour(long tourId);

        Task<TourDto?> GetTourById(long id);

        Task<TourDto?> AddTour(CreateOrUpdateTourDto tourDto);

        Task<TourDto?> UpdateTour(long id, CreateOrUpdateTourDto tourDto);

        Task<ShowDto?> AddShow(long tourId, CreateOrUpdateShowDto showDto);

        Task<ShowDto?> UpdateShow(long showId, CreateOrUpdateShowDto showDto);

        Task<bool> ArchiveTour(long id);

        Task<bool> DeleteTour(long id);

        Task<bool> DeleteShow(long id);

    }
}
