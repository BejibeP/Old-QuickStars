using MaViCS.Business.Dtos;

namespace MaViCS.Business.Interfaces
{
    public interface ITalentService
    {

        Task<IEnumerable<TalentDto>> GetTalents();

        Task<TalentDto?> GetTalentById(long id);

        Task<TalentDto?> AddTalent(CreateTalentDto talentDto);

        Task<TalentDto?> UpdateTalent(long id, UpdateTalentDto talentDto);

        Task<bool> ArchiveTalent(long id);

        Task<bool> DeleteTalent(long id);

    }
}
