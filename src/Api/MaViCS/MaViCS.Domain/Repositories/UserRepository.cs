using MaViCS.Domain.Interfaces;
using MaViCS.Domain.Models;
using MaViCS.Domain.Persistance;
using Microsoft.EntityFrameworkCore;

namespace MaViCS.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<User>> GetUsers(bool ignoreArchived = true, bool loadIncludes = true)
        {
            IQueryable<User> query = _databaseContext.Users;

            if (ignoreArchived) query = query.Where(x => x.DeletedOn == null);

            return await query.ToListAsync();
        }

        public async Task<User?> GetUserById(long id, bool ignoreArchived = true, bool loadIncludes = true)
        {
            IQueryable<User> query = _databaseContext.Users;

            if (ignoreArchived) query = query.Where(x => x.DeletedOn == null);

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User?> AuthenticateUser(string login, string password)
        {
            IQueryable<User> query = _databaseContext.Users;

            query = query.Where(x => x.Username == login || x.Mail == login)
                .Where(x => x.Password == password);
            //SecurityTools.HashPassword(password));

            return await query.FirstOrDefaultAsync();
        }

        public async Task<User?> AddUser(User user)
        {
            user.CreatedOn = DateTime.UtcNow;

            var entry = await _databaseContext.Users.AddAsync(user);
            await _databaseContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<User?> UpdateUser(User user)
        {
            user.ModifiedOn = DateTime.UtcNow;

            var entry = _databaseContext.Users.Update(user);
            await _databaseContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<bool> ArchiveUser(long id)
        {
            var user = await _databaseContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user is null || user.DeletedOn is not null) return false;

            user.DeletedOn = DateTime.UtcNow;

            _databaseContext.Users.Update(user);
            await _databaseContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteUser(long id)
        {
            var user = await _databaseContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user is null) return false;

            _databaseContext.Users.Remove(user);
            await _databaseContext.SaveChangesAsync();

            return true;
        }

    }
}
