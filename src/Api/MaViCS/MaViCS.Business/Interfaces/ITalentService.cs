using MaViCS.Business.Dtos;

namespace MaViCS.Business.Interfaces
{
    public interface ITalentService
    {

        List<TalentDto> GetTalents();

        TalentDto? GetTalentById(long id);

        TalentDto? AddTalent(CreateTalentDto talentDto);

        TalentDto? UpdateTalent(long id, UpdateTalentDto talentDto);

        bool ArchiveTalent(long id);

        bool DeleteTalent(long id);

    }
}
