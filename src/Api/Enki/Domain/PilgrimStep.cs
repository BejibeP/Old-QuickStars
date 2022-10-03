using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enki.Domain
{
    internal class PilgrimStep : BaseEntity
    {
        public long PilgrimageId { get; set; }
        public Pilgrimage Pilgrimage { get; set; }
        public int Order { get; set; }

        public long ShrineId { get; set; }
        public Shrine Shrine { get; set; }

        public TimeSpan DurationOfStay { get; set; }

    }
}
