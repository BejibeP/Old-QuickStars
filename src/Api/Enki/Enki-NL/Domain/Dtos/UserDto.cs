using System.ComponentModel.DataAnnotations;

namespace Enki.Domain.Dtos
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime RegisteredOn { get; set; }
        public string Order { get; set; }
    }

    public class AddUserDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

        [Required]
        public string Order { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

}
