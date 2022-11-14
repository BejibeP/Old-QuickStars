namespace QuickStars.MaViCS.Business.Dtos
{
    public class CreateTalentDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? Title { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}
