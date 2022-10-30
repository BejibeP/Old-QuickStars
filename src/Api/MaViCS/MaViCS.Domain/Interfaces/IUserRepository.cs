using MaViCS.Domain.Models;

namespace MaViCS.Domain.Interfaces
{
    public interface IUserRepository
    {

        Task<IEnumerable<User>> GetUsers(bool ignoreArchived = true, bool loadIncludes = true);

        Task<User?> GetUserById(long id, bool ignoreArchived = true, bool loadIncludes = true);

        Task<User?> AuthenticateUser(string login, string password);

        Task<User?> AddUser(User user);

        Task<User?> UpdateUser(User user);

        Task<bool> ArchiveUser(long id);

        Task<bool> DeleteUser(long id);

    }
}
