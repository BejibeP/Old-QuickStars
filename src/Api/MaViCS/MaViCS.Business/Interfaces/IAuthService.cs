using QuickStars.MaViCS.Business.Dtos.Auth;
using System.Security.Claims;

namespace QuickStars.MaViCS.Business.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResult<TokenDto>> Login(LoginDto dto);

        Task<ServiceResult<bool>> Register(RegisterDto dto);

        Task<ServiceResult<bool>> ResetPassword(ResetPasswordDto dto);
    }
}
