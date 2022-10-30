using MaViCS.Domain.Models;

namespace MaViCS.Business.Dtos
{
    public static class UserExtensions
    {

        public static User ToUser(this CreateUserDto dto)
        {
            return new User()
            {
                Username = dto.Username,
                Mail = dto.Mail,
                Password = dto.Password
            };
        }

        public static User UpdateUser(this User user, UpdateUserDto dto)
        {
            user.Username = dto.Username;
            user.Mail = dto.Mail;
            user.Password = dto.Password;
            return user;
        }

        public static UserDto ToUserDto(this User user)
        {
            return new UserDto()
            {
                Id = user.Id,
                Username = user.Username,
                Mail = user.Mail,
                Password = user.Password,                
                Role = user.Role
            };
        }

    }
}
