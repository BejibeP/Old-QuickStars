using QuickStars.MaViCS.Domain.Data.Models;

namespace QuickStars.MaViCS.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {

        Task<User?> GetUserByLoginAndPassword(string login, string password);

    }
}
