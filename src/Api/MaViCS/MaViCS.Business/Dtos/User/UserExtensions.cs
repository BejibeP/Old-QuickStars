using MaViCS.Domain.Framework.Habilitation;
using MaViCS.Domain.Models;

namespace MaViCS.Business.Dtos
{
    public static class UserExtensions
    {

        public static UserDto ToUserDto(this User user)
        {
            return new UserDto()
            {
                Id = user.Id,
                Username = user.Username,
                ProfilePicture = user.ProfilePicture,
                LastLoggedOn = user.LastLoggedOn,
                Role = user.Role.ToUserRole(),
                ResetPassword = user.ResetPassword,
                Enabled = user.Enabled
            };
        }

        public static User UpdateUser(this User user, UpdateUserDto dto)
        {
            user.Username = dto.Username;
            user.ProfilePicture = dto.ProfilePicture;
            return user;
        }

        public static User UpdateUser(this User user, ManageUserDto dto)
        {
            user.LastLoggedOn = dto.LastLoggedOn;
            user.Role = dto.Role.ToEnum();
            user.ResetPassword = dto.ResetPassword;
            user.Enabled = dto.Enabled;
            return user;
        }

    }
}
