using MaViCS.Domain.Models;

namespace MaViCS.Business.Dtos
{
    public static class TalentExtensions
    {

        public static Talent ToTalent(this CreateTalentDto dto)
        {
            return new Talent()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Title = dto.Title,
                HomeTownId = dto.HomeTownId,
            };
        }

        public static Talent UpdateTalent(this Talent talent, UpdateTalentDto dto)
        {
            talent.Title = dto.Title;
            return talent;
        }

        public static TalentDto ToTalentDto(this Talent talent)
        {
            TalentDto result = new TalentDto()
            {
                Id = talent.Id,
                Name = talent.Name,
                Surname = talent.Surname,
                Title = talent.Title
            };

            if (talent.HomeTown is not null)
                result.HomeTown = talent.HomeTown.ToTownDto();

            return result;
        }

    }
}
