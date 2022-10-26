namespace MaViCS.Business.Dtos
{
    public class CreateTalentDto
    {

        public string Name { get; set; }

        public string Surname { get; set; }

        public string? Title { get; set; }

        public long? HomeTownId { get; set; }

    }
}
