using MaViCS.Domain.Models;

namespace MaViCS.Domain.Interfaces
{
    public interface ITalentRepository
    {

        Task<IEnumerable<Talent>> GetTalents(bool ignoreArchived = true, bool loadIncludes = true);

        Task<Talent?> GetTalentById(long id, bool ignoreArchived = true, bool loadIncludes = true);

        Task<Talent?> AddTalent(Talent talent);

        Task<Talent?> UpdateTalent(Talent talent);

        Task<bool> ArchiveTalent(long id);

        Task<bool> DeleteTalent(long id);

    }
}
