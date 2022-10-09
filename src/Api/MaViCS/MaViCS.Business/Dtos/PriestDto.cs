using MaViCS.Domain.Models;

namespace MaViCS.Business.Dtos
{
    public class PriestDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Title { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfDeath { get; set; }

        public Coordinates HomeCoordinates { get; set; }
    }
}
