using QuickStars.MaViCS.Business.Dtos;
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

        public async Task<IEnumerable<ShowDto>> GetShows()
        {
            var shows = await _showRepository.GetAll(true, x => x.Talent);

            return shows.Select(e => e.ToShowDto()).ToList();
        }

        public async Task<IEnumerable<ShowDto>> GetShowsByTalent(long talentId)
        {
            var shows = await _showRepository.GetByTalent(talentId, true, x => x.Talent);

            return shows.Select(e => e.ToShowDto()).ToList();
        }

        public async Task<ShowDto?> GetShowById(long id)
        {
            var show = await _showRepository.GetById(id, true, x => x.Talent);

            return show?.ToShowDto();
        }

        public async Task<ShowDto?> AddShow(CreateOrUpdateShowDto showDto)
        {
            var talent = _talentRepository.GetById(showDto.TalentId);

            if (talent == null)
                return null;

            var show = showDto.ToShow();

            show = await _showRepository.Create(show);

            return show?.ToShowDto();
        }

        public async Task<ShowDto?> UpdateShow(long showId, CreateOrUpdateShowDto showDto)
        {
            var show = await _showRepository.GetById(showId, true);

            if (show == null)
                return null;

            var talent = _talentRepository.GetById(showDto.TalentId);

            if (talent == null)
                return null;

            show = show.UpdateShow(showDto);

            show = await _showRepository.Update(show);
            return show?.ToShowDto();
        }

        public async Task<bool> ArchiveShow(long id)
        {
            return await _showRepository.Archive(id);
        }

        public async Task<bool> DeleteShow(long id)
        {
            return await _showRepository.Delete(id);
        }

    }
}
