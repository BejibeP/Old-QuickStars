using MaViCS.Business.Dtos;
using MaViCS.Business.Interfaces;
using MaViCS.Domain.Interfaces;
using MaViCS.Domain.Repositories;

namespace MaViCS.Business.Services
{
    public class TalentService : ITalentService
    {
        public readonly ITalentRepository _talentRepository;

        public TalentService(ITalentRepository talentRepository)
        {
            _talentRepository = talentRepository;
        }

        public async Task<IEnumerable<TalentDto>> GetTalents()
        {
            var talents = await _talentRepository.GetTalents();

            return talents.Select(x => x.ToTalentDto()).ToList();
        }

        public async Task<TalentDto?> GetTalentById(long id)
        {
            var talent = await _talentRepository.GetTalentById(id);

            return talent?.ToTalentDto();
        }

        public async Task<TalentDto?> AddTalent(CreateTalentDto talentDto)
        {
            var talent = talentDto.ToTalent();

            talent = await _talentRepository.AddTalent(talent);

            return talent?.ToTalentDto();
        }

        public async Task<TalentDto?> UpdateTalent(long id, UpdateTalentDto talentDto)
        {
            var talent = await _talentRepository.GetTalentById(id);

            if (talent == null)
                return null;

            talent = talent.UpdateTalent(talentDto);

            talent = await _talentRepository.UpdateTalent(talent);
            return talent?.ToTalentDto();
        }

        public async Task<bool> ArchiveTalent(long id)
        {
            return await _talentRepository.ArchiveTalent(id);
        }

        public async Task<bool> DeleteTalent(long id)
        {
            return await _talentRepository.DeleteTalent(id);
        }

    }
}
