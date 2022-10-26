using MaViCS.Business.Dtos;

namespace MaViCS.Business.Interfaces
{
    public interface ITourService
    {

        Task<IEnumerable<TourDto>> GetTours();

        Task<IEnumerable<TourDto>> GetToursByTalent(long talentId);

        Task<TourDto?> GetTourById(long id);

        Task<TourDto?> AddTour(CreateOrUpdateTourDto tourDto);

        Task<TourDto?> UpdateTour(long id, CreateOrUpdateTourDto tourDto);

        Task<bool> ArchiveTour(long id);

        Task<bool> DeleteTour(long id);

    }
}
