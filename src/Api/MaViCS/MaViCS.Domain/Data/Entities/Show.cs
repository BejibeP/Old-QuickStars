namespace QuickStars.MaViCS.Domain.Data.Entities
{
    public class Show : BaseEntity
    {

        public long TalentId { get; set; }
        public Talent Talent { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime Date { get; set; }

    }
}
