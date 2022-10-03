using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enki.Domain
{
    internal class Shrine : BaseEntity
    {
        public string Name { get; set; }        
        public string Description { get; set; }

        public string Idol { get; set; }

        public string Localization { get; set; }
    }
}
