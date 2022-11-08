namespace QuickStars.MaViCS.Domain.Data.Entities
{
    public class Talent : BaseEntity
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? Title { get; set; }

        public DateTime? DateOfBirth { get; set; }

    }
}
