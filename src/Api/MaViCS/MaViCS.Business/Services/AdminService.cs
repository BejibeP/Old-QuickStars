using Microsoft.AspNetCore.Identity;
using QuickStars.MaViCS.Business.Dtos.Auth;
using QuickStars.MaViCS.Business.Interfaces;
using QuickStars.MaViCS.Domain.Auth;

namespace QuickStars.MaViCS.Business.Services
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AdminService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ServiceResult<bool>> ResetUserPassword(ResetPasswordDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Username);
            if (user is null)
                return ServiceResult<bool>.NotFound("User does not exists");

            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, resetToken, dto.NewPassword);

            if (!result.Succeeded)
                return ServiceResult<bool>.ServerError("Password change failed! Please check user details and try again.");

            return ServiceResult<bool>.Success("Password sucessfuly updated");
        }

        public async Task<ServiceResult<bool>> AddUserRole(UserRoleDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Username);
            if (user is null)
                return ServiceResult<bool>.NotFound("User does not exists");

            var validRoles = new string[] { IdentityRoles.Admin, IdentityRoles.User };

            if (!validRoles.Contains(dto.Role))
                return ServiceResult<bool>.ServerError("Role does not exists");

            var result = await _userManager.AddToRoleAsync(user, dto.Role);

            if (!result.Succeeded)
                return ServiceResult<bool>.ServerError("Role Change failed.");

            return ServiceResult<bool>.Success("Role sucessfuly updated");
        }

        public async Task<ServiceResult<bool>> DeleteUserRole(UserRoleDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Username);
            if (user is null)
                return ServiceResult<bool>.NotFound("User does not exists");

            var validRoles = new string[] { IdentityRoles.Admin, IdentityRoles.User };

            if (!validRoles.Contains(dto.Role))
                return ServiceResult<bool>.ServerError("Role does not exists");

            var result = await _userManager.RemoveFromRoleAsync(user, dto.Role);
            if (!result.Succeeded)
                return ServiceResult<bool>.ServerError("Role Change failed.");

            return ServiceResult<bool>.Success("Role sucessfuly updated");
        }

    }
}
