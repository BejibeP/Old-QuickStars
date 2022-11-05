using QuickStars.MaViCS.Domain.Data.Models;
using QuickStars.MaViCS.Domain.Security;

namespace QuickStars.MaViCS.Domain.Interfaces
{
    public interface ISecurityService
    {

        bool ValidatePassword(string password);

        string HashPassword(string password);

        AuthToken GenerateAuthToken(User user);

    }
}
