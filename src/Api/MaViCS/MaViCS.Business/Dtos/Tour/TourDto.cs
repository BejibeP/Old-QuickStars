namespace MaViCS.Business.Dtos
{
    public class TourDto
    {

        public long Id { get; set; }

        public TalentDto Talent { get; set; }

        public DateTime StartedOn { get; set; }

        public List<ShowDto> Shows { get; set; }

    }
}
