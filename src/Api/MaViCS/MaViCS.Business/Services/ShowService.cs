using QuickStars.MaViCS.Business.Dtos;
using QuickStars.MaViCS.Business.Dtos.Extensions;
using QuickStars.MaViCS.Business.Interfaces;
using QuickStars.MaViCS.Domain.Interfaces;

namespace QuickStars.MaViCS.Business.Services
{
    public class ShowService : IShowService
    {
        public readonly IShowRepository _showRepository;
        public readonly ITalentRepository _talentRepository;

        public ShowService(IShowRepository showRepository, ITalentRepository talentRepository)
        {
            _showRepository = showRepository;
            _talentRepository = talentRepository;
        }

        public async Task<ServiceResult<IEnumerable<ShowDto>>> GetShows()
        {
            var shows = await _showRepository.GetAll(true, x => x.Talent);

            var showDtos = shows.Select(e => e.ToShowDto()).ToList();

            return ServiceResult<IEnumerable<ShowDto>>.Success(showDtos);
        }

        public async Task<ServiceResult<IEnumerable<ShowDto>>> GetShowsByTalent(long talentId)
        {
            var shows = await _showRepository.GetByTalent(talentId, true, x => x.Talent);

            var showDtos = shows.Select(e => e.ToShowDto()).ToList();

            return ServiceResult<IEnumerable<ShowDto>>.Success(showDtos);
        }

        public async Task<ServiceResult<ShowDto>> GetShowById(long id)
        {
            var show = await _showRepository.GetById(id, true, x => x.Talent);
            if (show is null)
                return ServiceResult<ShowDto>.NotFound("Show not found");

            return ServiceResult<ShowDto>.Success(show.ToShowDto());
        }

        public async Task<ServiceResult<ShowDto>> AddShow(CreateOrUpdateShowDto showDto)
        {
            var talent = _talentRepository.GetById(showDto.TalentId);
            if (talent == null)
                return ServiceResult<ShowDto>.NotFound("Talent not found");

            var show = await _showRepository.Create(showDto.ToShow());
            if (show is null)
                return ServiceResult<ShowDto>.ServerError();

            return ServiceResult<ShowDto>.Success(show.ToShowDto());
        }

        public async Task<ServiceResult<ShowDto>> UpdateShow(long showId, CreateOrUpdateShowDto showDto)
        {
            var show = await _showRepository.GetById(showId, true);
            if (show == null)
                return ServiceResult<ShowDto>.NotFound("Show not found");

            var talent = _talentRepository.GetById(showDto.TalentId);
            if (talent == null)
                return ServiceResult<ShowDto>.NotFound("Talent not found");

            show = await _showRepository.Update(show.UpdateShow(showDto));
            if (show is null)
                return ServiceResult<ShowDto>.ServerError();

            return ServiceResult<ShowDto>.Success(show.ToShowDto());
        }

        public async Task<ServiceResult<bool>> ArchiveShow(long id)
        {
            bool result = await _showRepository.Archive(id);
            if (!result)
                return ServiceResult<bool>.NotFound();

            return ServiceResult<bool>.NoContent();
        }

        public async Task<ServiceResult<bool>> DeleteShow(long id)
        {
            bool result = await _showRepository.Delete(id);
            if (!result)
                return ServiceResult<bool>.NotFound();

            return ServiceResult<bool>.NoContent();
        }

    }
}
