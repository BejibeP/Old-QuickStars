using System.Drawing;

namespace Enki.Domain
{
    internal class Shrine : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Point Coordinates { get; set; }

        public string IdolName { get; set; }
    }
}
