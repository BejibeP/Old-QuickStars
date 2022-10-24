namespace MaViCS.Domain.Models
{
    public class Talent : BaseEntity
    {

        public string Name { get; set; }

        public string Surname { get; set; }

        public string? Title { get; set; }

        public long? HomeTownId { get; set; }
        public virtual Town? HomeTown { get; }

        public virtual List<Tour> Tours { get; }

    }
}
