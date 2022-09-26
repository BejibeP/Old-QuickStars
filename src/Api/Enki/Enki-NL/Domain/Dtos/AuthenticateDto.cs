using System.ComponentModel.DataAnnotations;

namespace Enki.Domain.Dtos
{
    public class AuthenticateDto
    {
        [Required]
        public string Mail { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class TokenDto
    {
        public string Mail { get; set; }

        public string Token { get; set; }
    }
}
