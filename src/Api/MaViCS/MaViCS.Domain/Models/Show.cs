namespace MaViCS.Domain.Models
{
    public class Show : BaseEntity
    {

        public long TourId { get; set; }
        public virtual Tour Tour { get; set; }

        public DateTime Date { get; set; }

        public long LocationId { get; set; }
        public virtual Town Location { get; set; }

    }
}
