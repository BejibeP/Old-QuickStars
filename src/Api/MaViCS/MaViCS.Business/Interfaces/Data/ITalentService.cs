using QuickStars.MaViCS.Business.Dtos;

namespace QuickStars.MaViCS.Business.Interfaces
{
    public interface ITalentService
    {

        Task<ServiceResult> GetTalents();

        Task<ServiceResult> GetTalentById(long id);

        Task<ServiceResult> AddTalent(CreateTalentDto talentDto);

        Task<ServiceResult> UpdateTalent(long id, UpdateTalentDto talentDto);

        Task<ServiceResult> ArchiveTalent(long id);

        Task<ServiceResult> DeleteTalent(long id);

    }
}
