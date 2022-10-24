using MaViCS.Business.Dtos;

namespace MaViCS.Business.Interfaces
{
    public interface IShowService
    {

        Task<IOrderedEnumerable<ShowDto>> GetShowsByTour(long tourId);

        Task<ShowDto?> AddShow(long tourId, CreateOrUpdateShowDto showDto);

        Task<ShowDto?> UpdateShow(long showId, CreateOrUpdateShowDto showDto);

        Task<bool> DeleteShow(long id);

    }
}
