namespace MaViCS.Domain.Models
{
    public class Shrine : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Coordinates Coordinates { get; set; }

        public string IdolName { get; set; }
    }
}
