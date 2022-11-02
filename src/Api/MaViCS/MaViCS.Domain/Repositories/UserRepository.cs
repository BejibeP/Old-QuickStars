using MaViCS.Domain.Interfaces;
using MaViCS.Domain.Models;
using MaViCS.Domain.Persistance;
using Microsoft.EntityFrameworkCore;

namespace MaViCS.Domain.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        public UserRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public async Task<User?> GetUserByLoginAndPassword(string login, string password)
        {
            IQueryable<User> query = _databaseContext.Users;

            query = query.Where(x => x.DeletedOn == null && x.Enabled == true)
                .Where(x => x.Username == login && x.Password == password);

            return await query.FirstOrDefaultAsync();
        }

    }
}
