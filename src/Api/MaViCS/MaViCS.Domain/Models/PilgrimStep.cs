namespace MaViCS.Domain.Models
{
    public class PilgrimStep : BaseEntity
    {
        public int Order { get; set; }

        public long PilgrimageId { get; set; }
        public Pilgrimage Pilgrimage { get; set; }

        public long ShrineId { get; set; }
        public Shrine Shrine { get; set; }

        public TimeSpan DurationOfStay { get; set; }
    }
}
