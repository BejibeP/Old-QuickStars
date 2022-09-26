namespace Enki.Domain.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisteredOn { get; set; }
        public string Order { get; set; }
        public List<Pilgrimage> Pilgrimages { get; set; }

    }
}
