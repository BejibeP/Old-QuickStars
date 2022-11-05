using QuickStars.MaViCS.Business.Dtos;

namespace QuickStars.MaViCS.Business.Interfaces
{
    public interface IShowService
    {

        Task<IEnumerable<ShowDto>> GetShows();

        Task<IEnumerable<ShowDto>> GetShowsByTalent(long talentId);

        Task<ShowDto?> GetShowById(long id);

        Task<ShowDto?> AddShow(CreateOrUpdateShowDto showDto);

        Task<ShowDto?> UpdateShow(long id, CreateOrUpdateShowDto showDto);

        Task<bool> ArchiveShow(long id);

        Task<bool> DeleteShow(long id);

    }
}
