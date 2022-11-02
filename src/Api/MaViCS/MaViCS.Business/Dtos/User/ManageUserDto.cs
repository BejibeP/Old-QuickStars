using MaViCS.Domain.Framework.Habilitation;

namespace MaViCS.Business.Dtos
{
    public class ManageUserDto
    {
        public DateTime? LastLoggedOn { get; set; }

        public UserRole Role { get; set; }

        public bool ResetPassword { get; set; }

        public bool Enabled { get; set; }
    }
}
