﻿namespace MaViCS.Domain.Models
{
    public class Tour : BaseEntity
    {

        public long TalentId { get; set; }
        public virtual Talent Talent { get; set; }

        public DateTime StartedOn { get; set; }

        public virtual List<Show> Shows { get; set; }

    }
}
