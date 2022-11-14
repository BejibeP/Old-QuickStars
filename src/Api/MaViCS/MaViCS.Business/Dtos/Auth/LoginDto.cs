using System.ComponentModel.DataAnnotations;

namespace QuickStars.MaViCS.Business.Dtos.Auth
{
    public class LoginDto
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
