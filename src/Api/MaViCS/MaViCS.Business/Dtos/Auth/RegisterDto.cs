using System.ComponentModel.DataAnnotations;

namespace QuickStars.MaViCS.Business.Dtos.Auth
{
    public class RegisterDto
    {

        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        public string Password { get; set; }

    }
}