namespace QuickStars.MaViCS.Business.Dtos
{
    public class ShowDto
    {
        public long Id { get; set; }

        public long TalentId { get; set; }
        public TalentDto Talent { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime Date { get; set; }
    }
}
