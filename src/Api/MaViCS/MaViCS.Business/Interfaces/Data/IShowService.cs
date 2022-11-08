using QuickStars.MaViCS.Business.Dtos;

namespace QuickStars.MaViCS.Business.Interfaces
{
    public interface IShowService
    {

        Task<ServiceResult> GetShows();

        Task<ServiceResult> GetShowsByTalent(long talentId);

        Task<ServiceResult> GetShowById(long id);

        Task<ServiceResult> AddShow(CreateOrUpdateShowDto showDto);

        Task<ServiceResult> UpdateShow(long id, CreateOrUpdateShowDto showDto);

        Task<ServiceResult> ArchiveShow(long id);

        Task<ServiceResult> DeleteShow(long id);

    }
}
