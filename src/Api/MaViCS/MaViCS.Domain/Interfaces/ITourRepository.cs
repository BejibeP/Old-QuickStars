using MaViCS.Domain.Models;
using System.Linq.Expressions;

namespace MaViCS.Domain.Interfaces
{
    public interface ITourRepository : IBaseRepository<Tour>
    {
        Task<IEnumerable<Tour>> GetByTalent(long talentId, bool ignoreArchived = true, params Expression<Func<Tour, object>>[] includes);
    }
}
