namespace Enki.Domain.Models
{
    public class Pilgrimage
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public long ShrineId { get; set; }
        public Shrine Shrine { get; set; }
    }
}
