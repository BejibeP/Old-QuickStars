using MaViCS.Domain.Interfaces;
using MaViCS.Domain.Models;
using MaViCS.Domain.Persistance;
using Microsoft.EntityFrameworkCore;

namespace MaViCS.Domain.Repositories
{
    public class TownRepository : BaseRepository<Town>, ITownRepository
    {
        public TownRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }
    }
}
