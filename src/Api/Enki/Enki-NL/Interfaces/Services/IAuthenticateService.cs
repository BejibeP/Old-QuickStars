using Enki.Domain.Dtos;

namespace Enki.Interfaces.Services
{
    public interface IAuthenticateService
    {
        TokenDto ConnectUser(AuthenticateDto request);
    }
}
