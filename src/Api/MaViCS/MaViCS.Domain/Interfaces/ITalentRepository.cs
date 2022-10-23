using MaViCS.Domain.Models;

namespace MaViCS.Domain.Interfaces
{
    public interface ITalentRepository
    {

        List<Talent> GetTalents(bool ignoreArchived = true);

        Talent? GetTalentById(long id, bool ignoreArchived = true);

        Talent? AddTalent(Talent talent);

        Talent? UpdateTalent(Talent talent);

        bool ArchiveTalent(long id);

        bool DeleteTalent(long id);

    }
}
