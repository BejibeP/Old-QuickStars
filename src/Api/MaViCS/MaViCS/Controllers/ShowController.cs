using Microsoft.AspNetCore.Mvc;
using QuickStars.MaViCS.Business.Dtos;
using QuickStars.MaViCS.Business.Interfaces;
using QuickStars.MaViCS.Business.Services;

namespace QuickStars.MaViCS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly IShowService _showService;

        public ShowController(IShowService showService)
        {
            _showService = showService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShowDto>>> GetAll()
        {
            var shows = await _showService.GetShows();
            return Ok(shows);
        }

        [HttpGet("ByTalent")]
        public async Task<ActionResult<IEnumerable<ShowDto>>> GetByTalent([FromQuery] long talentId)
        {
            var shows = await _showService.GetShowsByTalent(talentId);
            return Ok(shows);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShowDto>> GetById(long id)
        {
            var show = await _showService.GetShowById(id);

            if (show is null)
                return NotFound();

            return Ok(show);
        }

        [HttpPost]
        public async Task<ActionResult<ShowDto>> Create([FromBody] CreateOrUpdateShowDto showDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var show = await _showService.AddShow(showDto);

                if (show is null)
                    return BadRequest();

                return Ok(show);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ShowDto>> Update([FromQuery] long id, [FromBody] CreateOrUpdateShowDto showDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var show = await _showService.UpdateShow(id, showDto);

                if (show is null)
                    return BadRequest();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPatch]
        public async Task<ActionResult> Archive([FromQuery] long id)
        {
            try
            {
                bool result = await _showService.ArchiveShow(id);

                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] long id)
        {
            try
            {
                bool result = await _showService.DeleteShow(id);

                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}
