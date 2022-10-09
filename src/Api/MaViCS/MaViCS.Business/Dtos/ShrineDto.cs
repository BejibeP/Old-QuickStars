using MaViCS.Domain.Models;

namespace MaViCS.Business.Dtos
{
    public class ShrineDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Coordinates Coordinates { get; set; }

        public string IdolName { get; set; }
    }
}
