namespace MaViCS.Domain.Models
{
    public class User : BaseEntity
    {

        public string Username { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }

        public UserRole.UserRoleEnum Role { get; set; }

    }
}
