using MaViCS.Domain.Models;

namespace MaViCS.Business.Dtos
{
    public class UserDto
    {

        public long Id { get; set; }

        public string Username { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }

        public UserRole.UserRoleEnum Role { get; set; }

    }
}
