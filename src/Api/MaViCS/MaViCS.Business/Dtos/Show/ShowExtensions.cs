using QuickStars.MaViCS.Domain.Data.Models;

namespace QuickStars.MaViCS.Business.Dtos
{
    public static class ShowExtensions
    {

        public static Show ToShow(this CreateOrUpdateShowDto dto)
        {
            return new Show()
            {
                TalentId = dto.TalentId,
                Name = dto.Name,
                Description = dto.Description,
                Date = dto.Date,
            };
        }

        public static Show UpdateShow(this Show show, CreateOrUpdateShowDto dto)
        {
            show.TalentId = dto.TalentId;
            show.Name = dto.Name;
            show.Description = dto.Description;
            show.Date = dto.Date;
            return show;
        }

        public static ShowDto ToShowDto(this Show show)
        {
            ShowDto result = new ShowDto()
            {
                Id = show.Id,
                TalentId = show.TalentId,
                Name= show.Name,
                Description = show.Description,
                Date = show.Date
            };

            if (show.Talent is not null)
                result.Talent = show.Talent.ToTalentDto();

            return result;
        }

    }
}
