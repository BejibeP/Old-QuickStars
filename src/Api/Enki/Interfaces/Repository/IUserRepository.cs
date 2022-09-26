using Enki.Domain.Models;

namespace Enki.Interfaces.Repository
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();

        User AddUser(User newUser, string clearPassword);

        User AuthenticateUser(string email, string password);

    }
}
