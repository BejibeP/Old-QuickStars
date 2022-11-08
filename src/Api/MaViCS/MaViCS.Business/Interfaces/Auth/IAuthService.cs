using QuickStars.MaViCS.Business.Dtos.Auth;

namespace QuickStars.MaViCS.Business.Interfaces.Auth
{
    public interface IAuthService
    {

        Task<ServiceResult> Login(LoginDto dto);

        Task<ServiceResult> Register(RegisterDto dto);

    }
}
