using MaViCS.Domain.Models;

namespace MaViCS.Business.Dtos
{
    public class PilgrimageDto
    {
        public Priest Priest { get; set; }

        public DateTime DepartedOn { get; set; }

        public Coordinates DepartedFrom { get; set; }
    }
}
