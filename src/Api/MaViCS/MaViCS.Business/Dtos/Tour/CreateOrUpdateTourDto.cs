namespace MaViCS.Business.Dtos
{
    public class CreateOrUpdateTourDto
    {

        public long TalentId { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }

        public DateTime StartedOn { get; set; }

    }
}
