using MaViCS.Domain.Framework.Habilitation;

namespace MaViCS.Domain.Models
{
    public class User : BaseEntity
    {

        public string Username { get; set; }

        public string Password { get; set; }

        public string? ProfilePicture { get; set; }

        public DateTime? LastLoggedOn { get; set; }

        public UserRoleEnum Role { get; set; }

        public bool ResetPassword { get; set; }

        public bool Enabled { get; set; }

    }
}
