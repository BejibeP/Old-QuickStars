using QuickStars.MaViCS.Domain.Data.Models;

namespace QuickStars.MaViCS.Business.Dtos
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
