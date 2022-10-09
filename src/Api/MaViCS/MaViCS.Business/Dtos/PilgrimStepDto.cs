namespace MaViCS.Business.Dtos
{
    public class PilgrimStepDto
    {
        public int Order { get; set; }

        public PilgrimageDto Pilgrimage { get; set; }

        public ShrineDto Shrine { get; set; }

        public TimeSpan DurationOfStay { get; set; }
    }
}
