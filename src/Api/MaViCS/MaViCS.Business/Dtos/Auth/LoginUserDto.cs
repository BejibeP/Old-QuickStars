using System.ComponentModel.DataAnnotations;

namespace QuickStars.MaViCS.Business.Dtos
{
    public class LoginUserDto
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
