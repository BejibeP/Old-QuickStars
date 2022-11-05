using Microsoft.EntityFrameworkCore;
using QuickStars.MaViCS.Domain.Data;
using QuickStars.MaViCS.Domain.Data.Models;
using QuickStars.MaViCS.Domain.Interfaces;

namespace QuickStars.MaViCS.Domain.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        public UserRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public async Task<User?> GetUserByLoginAndPassword(string login, string password)
        {
            IQueryable<User> query = _databaseContext.Users;

            query = query.Where(e => e.DeletedOn == null && e.Enabled == true)
                .Where(e => e.Username == login && e.Password == password);

            return await query.FirstOrDefaultAsync();
        }

    }
}
