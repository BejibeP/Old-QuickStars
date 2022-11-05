using System.ComponentModel.DataAnnotations;

namespace QuickStars.MaViCS.Business.Dtos
{
    public class RegisterUserDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]        
        public string Password { get; set; }
    }
}