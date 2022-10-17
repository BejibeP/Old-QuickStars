namespace MaViCS.Domain.Models
{
    public class Town : BaseEntity
    {

        public string Name { get; set; }

        public string Region { get; set; }

        public string Description { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

    }
}
