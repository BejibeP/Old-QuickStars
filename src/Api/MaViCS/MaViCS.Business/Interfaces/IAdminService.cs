using QuickStars.MaViCS.Business.Dtos.Auth;

namespace QuickStars.MaViCS.Business.Interfaces
{
    public interface IAdminService
    {
        Task<ServiceResult<bool>> ResetUserPassword(ResetPasswordDto dto);
        Task<ServiceResult<bool>> AddUserRole(UserRoleDto dto);
        Task<ServiceResult<bool>> DeleteUserRole(UserRoleDto dto);
    }
}
