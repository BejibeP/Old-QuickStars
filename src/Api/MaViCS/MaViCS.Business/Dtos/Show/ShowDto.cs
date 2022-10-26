namespace MaViCS.Business.Dtos
{
    public class ShowDto
    {

        public long Id { get; set; }

        public virtual TourDto Tour { get; set; }

        public DateTime Date { get; set; }

        public virtual TownDto? Location { get; set; }

    }
}
