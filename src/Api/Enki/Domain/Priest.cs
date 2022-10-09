using System.Drawing;

namespace Enki.Domain
{
    internal class Priest : BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Title { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfDeath { get; set; }

        public Point HomeCoordinates { get; set; }
    }
}
