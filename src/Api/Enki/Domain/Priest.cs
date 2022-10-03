using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enki.Domain
{
    internal class Priest : BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Title { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfDeath { get; set; }

        public string Home { get; set; } // localisation ?
    }
}
