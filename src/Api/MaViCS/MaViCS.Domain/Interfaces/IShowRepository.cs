using QuickStars.MaViCS.Domain.Data.Entities;
using System.Linq.Expressions;

namespace QuickStars.MaViCS.Domain.Interfaces
{
    public interface IShowRepository : IBaseRepository<Show>
    {
        Task<IEnumerable<Show>> GetByTalent(long talentId, bool ignoreArchived = true, params Expression<Func<Show, object>>[] includes);
    }
}
