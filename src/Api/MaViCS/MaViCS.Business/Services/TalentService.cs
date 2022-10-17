using MaViCS.Business.Dtos;
using MaViCS.Business.Interfaces;
using MaViCS.Domain.Interfaces;

namespace MaViCS.Business.Services
{
    public class TalentService : ITalentService
    {
        public ITalentRepository _talentRepository;

        public TalentService(ITalentRepository talentRepository)
        {
            _talentRepository = talentRepository;
        }

        public List<TalentDto> GetTalents()
        {
            return _talentRepository.GetTalents()
                .Select(x => x.ToTalentDto())
                .ToList();
        }

        public TalentDto? GetTalentById(long id)
        {
            return _talentRepository.GetTalentById(id)?.ToTalentDto();
        }

        public TalentDto? AddTalent(CreateTalentDto talentDto)
        {
            var talent = talentDto.ToTalent();

            return _talentRepository.AddTalent(talent)?.ToTalentDto();
        }

        public TalentDto? UpdateTalent(long id, UpdateTalentDto talentDto)
        {
            var talent = talentDto.ToTalent();
            talent.Id = id;

            return _talentRepository.UpdateTalent(talent)?.ToTalentDto();
        }

        public bool ArchiveTalent(long id)
        {
            return _talentRepository.ArchiveTalent(id);
        }

        public bool DeleteTalent(long id)
        {
            return _talentRepository.DeleteTalent(id);
        }

    }
}
