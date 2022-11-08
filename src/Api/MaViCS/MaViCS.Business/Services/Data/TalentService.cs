using QuickStars.MaViCS.Business.Dtos;
using QuickStars.MaViCS.Business.Dtos.Extensions;
using QuickStars.MaViCS.Business.Interfaces;
using QuickStars.MaViCS.Domain.Interfaces;
using QuickStars.MaViCS.Domain.Repositories;

namespace QuickStars.MaViCS.Business.Services
{
    public class TalentService : ITalentService
    {
        public readonly ITalentRepository _talentRepository;

        public TalentService(ITalentRepository talentRepository)
        {
            _talentRepository = talentRepository;
        }

        public async Task<ServiceResult> GetTalents()
        {
            var talents = await _talentRepository.GetAll();

            var talentDtos = talents.Select(e => e.ToTalentDto()).ToList();

            return ServiceResult<IEnumerable<TalentDto>>.Success(talentDtos);
        }

        public async Task<ServiceResult> GetTalentById(long id)
        {
            var talent = await _talentRepository.GetById(id);
            if (talent is null)
                return ServiceResult.NotFound("");

            return ServiceResult<TalentDto>.Success(talent.ToTalentDto());
        }

        public async Task<ServiceResult> AddTalent(CreateTalentDto talentDto)
        {
            var talent = await _talentRepository.Create(talentDto.ToTalent());

            if (talent is null)
                return ServiceResult.Error("");

            return ServiceResult<TalentDto>.Success(talent.ToTalentDto());
        }

        public async Task<ServiceResult> UpdateTalent(long id, UpdateTalentDto talentDto)
        {
            var talent = await _talentRepository.GetById(id);
            if (talent == null)
                return ServiceResult.NotFound("");

            talent = await _talentRepository.Update(talent.UpdateTalent(talentDto));

            if (talent is null)
                return ServiceResult.Error("");

            return ServiceResult<TalentDto>.Success(talent.ToTalentDto());
        }

        public async Task<ServiceResult> ArchiveTalent(long id)
        {
            bool result = await _talentRepository.Archive(id);

            if (!result)
                return ServiceResult.NotFound("");

            return ServiceResult.Success();
        }

        public async Task<ServiceResult> DeleteTalent(long id)
        {
            bool result = await _talentRepository.Delete(id);

            if (!result)
                return ServiceResult.NotFound("");

            return ServiceResult.Success();
        }

    }
}
