using MaViCS.Business.Dtos;

namespace MaViCS.Business.Dtos
{
    public class TourDto
    {

        public long Id { get; set; }

        public TalentDto Talent { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }

        public DateTime StartedOn { get; set; }

        public List<ShowDto> Shows { get; set; }

    }
}
