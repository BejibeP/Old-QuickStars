using System.ComponentModel.DataAnnotations;

namespace QuickStars.MaViCS.Business.Dtos.Auth
{
    public class ResetPasswordDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        public string NewPassword { get; set; }
    }
}
