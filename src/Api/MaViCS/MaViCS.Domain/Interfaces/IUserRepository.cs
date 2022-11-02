using MaViCS.Domain.Models;

namespace MaViCS.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetUserByLoginAndPassword(string login, string password);
    }
}
