using QuickStars.MaViCS.Business.Dtos.Auth;
using System.Security.Claims;

namespace QuickStars.MaViCS.Business.Interfaces.Auth
{
    public interface IAuthService
    {

        Task<ServiceResult> Login(LoginDto dto);

        Task<ServiceResult> Register(RegisterDto dto);

        Task<ServiceResult> GetUserInfos(ClaimsPrincipal userClaim);

    }
}
