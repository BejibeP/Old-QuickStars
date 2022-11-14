using System.ComponentModel.DataAnnotations;

namespace QuickStars.MaViCS.Business.Dtos
{
    public class CreateOrUpdateShowDto
    {
        [Required]
        public long TalentId { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
