using static QuickStars.MaViCS.Domain.Security.UserHabilitation;

namespace QuickStars.MaViCS.Domain.Data.Models
{
    public class User : BaseEntity
    {

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime? LastLoggedOn { get; set; }

        public UserRoleEnum Role { get; set; }

        public bool ResetPassword { get; set; }

        public bool Enabled { get; set; }

    }
}
