using MaViCS.Business.Dtos;

namespace MaViCS.Business.Interfaces
{
    public interface ITourService
    {

        List<TourDto> GetTours();

        List<TourDto> GetToursByTalent(long talentId);

        IOrderedEnumerable<ShowDto> GetShowsByTour(long tourId);

        TourDto? GetTourById(long id);

        TourDto? AddTour(CreateOrUpdateTourDto tourDto);

        TourDto? UpdateTour(long id, CreateOrUpdateTourDto tourDto);

        ShowDto? AddShow(long tourId, CreateOrUpdateShowDto showDto);

        ShowDto? UpdateShow(long id, long tourId, CreateOrUpdateShowDto showDto);

        bool ArchiveTour(long id);

        bool DeleteTour(long id);

        bool DeleteShow(long id);

    }
}
