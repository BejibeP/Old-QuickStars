using MaViCS.Domain.Framework;
using MaViCS.Domain.Models;

namespace MaViCS.Business.Dtos
{
    public static class AuthExtensions
    {

        public static User ToUser(this RegisterUserDto dto)
        {
            return new User()
            {
                Username = dto.Username,
                Password = dto.Password
            };
        }

    }
}
