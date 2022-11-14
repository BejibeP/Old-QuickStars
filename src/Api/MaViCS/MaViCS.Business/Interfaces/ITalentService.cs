using QuickStars.MaViCS.Business.Dtos;

namespace QuickStars.MaViCS.Business.Interfaces
{
    public interface ITalentService
    {
        Task<ServiceResult<IEnumerable<TalentDto>>> GetTalents();

        Task<ServiceResult<TalentDto>> GetTalentById(long id);

        Task<ServiceResult<TalentDto>> AddTalent(CreateTalentDto talentDto);

        Task<ServiceResult<TalentDto>> UpdateTalent(long id, UpdateTalentDto talentDto);

        Task<ServiceResult<bool>> ArchiveTalent(long id);

        Task<ServiceResult<bool>> DeleteTalent(long id);
    }
}
