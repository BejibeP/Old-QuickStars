using MaViCS.Domain.Models;
using System.Linq.Expressions;

namespace MaViCS.Domain.Interfaces
{
    public interface IShowRepository : IBaseRepository<Show>
    {
        Task<IEnumerable<Show>> GetByTour(long tourId, bool ignoreArchived = true, params Expression<Func<Show, object>>[] includes);
    }
}
