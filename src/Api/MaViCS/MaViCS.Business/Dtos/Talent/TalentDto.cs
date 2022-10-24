namespace MaViCS.Business.Dtos
{
    public class TalentDto
    {

        public long Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string? Title { get; set; }

        public virtual TownDto? HomeTown { get; set; }

    }
}
