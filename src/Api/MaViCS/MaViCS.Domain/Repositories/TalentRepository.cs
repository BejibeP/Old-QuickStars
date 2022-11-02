using MaViCS.Domain.Interfaces;
using MaViCS.Domain.Models;
using MaViCS.Domain.Persistance;
using Microsoft.EntityFrameworkCore;

namespace MaViCS.Domain.Repositories
{
    public class TalentRepository : BaseRepository<Talent>, ITalentRepository
    {

        public TalentRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

    }
}
