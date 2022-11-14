using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickStars.MaViCS.Business.Dtos;
using QuickStars.MaViCS.Business.Interfaces;
using QuickStars.MaViCS.Domain.Auth;
using QuickStars.MaViCS.Extensions;

namespace QuickStars.MaViCS.Controllers
{
    [Authorize(Roles = IdentityRoles.User)]
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly IShowService _showService;

        public ShowController(IShowService showService)
        {
            _showService = showService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShowDto>>> GetAll()
        {
            var shows = await _showService.GetShows();
            return this.FromResult(shows);
        }

        [AllowAnonymous]
        [HttpGet("ByTalent")]
        public async Task<ActionResult<IEnumerable<ShowDto>>> GetByTalent([FromQuery] long talentId)
        {
            var shows = await _showService.GetShowsByTalent(talentId);
            return this.FromResult(shows);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<ShowDto>> GetById(long id)
        {
            var show = await _showService.GetShowById(id);
            return this.FromResult(show);
        }

        [HttpPost]
        public async Task<ActionResult<ShowDto>> Create([FromBody] CreateOrUpdateShowDto showDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var show = await _showService.AddShow(showDto);
            return this.FromResult(show);
        }

        [HttpPut]
        public async Task<ActionResult<ShowDto>> Update([FromQuery] long id, [FromBody] CreateOrUpdateShowDto showDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var show = await _showService.UpdateShow(id, showDto);
            return this.FromResult(show);
        }

        [HttpPatch]
        public async Task<ActionResult> Archive([FromQuery] long id)
        {
            var result = await _showService.ArchiveShow(id);
            return this.FromResult(result);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] long id)
        {
            var result = await _showService.DeleteShow(id);
            return this.FromResult(result);
        }
    }
}
