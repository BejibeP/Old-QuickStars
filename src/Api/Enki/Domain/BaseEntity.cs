﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enki.Domain
{
    internal abstract class BaseEntity
    {
        public long Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public DateTime DeletedOn { get; set; }
        public string? DeletedBy { get; set; }
    }
}
