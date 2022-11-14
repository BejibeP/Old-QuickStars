using QuickStars.MaViCS.Business.Dtos;

namespace QuickStars.MaViCS.Business.Interfaces
{
    public interface IShowService
    {
        Task<ServiceResult<IEnumerable<ShowDto>>> GetShows();

        Task<ServiceResult<IEnumerable<ShowDto>>> GetShowsByTalent(long talentId);

        Task<ServiceResult<ShowDto>> GetShowById(long id);

        Task<ServiceResult<ShowDto>> AddShow(CreateOrUpdateShowDto showDto);

        Task<ServiceResult<ShowDto>> UpdateShow(long id, CreateOrUpdateShowDto showDto);

        Task<ServiceResult<bool>> ArchiveShow(long id);

        Task<ServiceResult<bool>> DeleteShow(long id);
    }
}
