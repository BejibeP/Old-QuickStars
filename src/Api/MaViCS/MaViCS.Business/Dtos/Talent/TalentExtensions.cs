using QuickStars.MaViCS.Domain.Data.Models;

namespace QuickStars.MaViCS.Business.Dtos
{
    public static class TalentExtensions
    {

        public static Talent ToTalent(this CreateTalentDto dto)
        {
            return new Talent()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Title = dto.Title,
                DateOfBirth = dto.DateOfBirth
            };
        }

        public static Talent UpdateTalent(this Talent talent, UpdateTalentDto dto)
        {
            talent.Title = dto.Title;
            talent.DateOfBirth = dto.DateOfBirth;
            return talent;
        }

        public static TalentDto ToTalentDto(this Talent talent)
        {
            TalentDto result = new TalentDto()
            {
                Id = talent.Id,
                FirstName = talent.FirstName,
                LastName = talent.LastName,
                Title = talent.Title,
                DateOfBirth = talent.DateOfBirth
            };
            return result;
        }

    }
}
