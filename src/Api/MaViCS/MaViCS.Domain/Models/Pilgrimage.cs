namespace MaViCS.Domain.Models
{
    public class Pilgrimage : BaseEntity
    {
        public long PriestId { get; set; }
        public Priest Priest { get; set; }

        public DateTime DepartedOn { get; set; }

        public Coordinates DepartedFrom { get; set; }
    }
}
