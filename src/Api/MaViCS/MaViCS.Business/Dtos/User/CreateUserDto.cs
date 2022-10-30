using MaViCS.Domain.Models;

namespace MaViCS.Business.Dtos
{
    public class CreateUserDto
    {

        public string Username { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }

    }
}
