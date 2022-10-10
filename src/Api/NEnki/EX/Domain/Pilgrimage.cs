using System.Drawing;

namespace Enki.Domain
{
    internal class Pilgrimage : BaseEntity
    {
        public long PriestId { get; set; }
        public Priest Priest { get; set; }

        public DateTime DepartedOn { get; set; }

        public Point DepartedFrom { get; set; }
    }
}
