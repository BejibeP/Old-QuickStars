using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enki.Domain
{
    internal class Pilgrimage : BaseEntity
    {

        public long PriestId { get; set; }
        
        public Priest Priest { get; set; }

        public string DepartedFrom { get; set; } // localization

        public DateTime DepartedOn { get; set; }

    }
}
