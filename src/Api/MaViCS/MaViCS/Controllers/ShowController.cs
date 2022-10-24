using MaViCS.Business.Dtos;
using MaViCS.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MaViCS.Controllers
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
        public async Task<ActionResult<IOrderedEnumerable<ShowDto>>> GetByTour([FromQuery] long tourId)
        {
            var shows = await _showService.GetShowsByTour(tourId);
            return Ok(shows);
        }

        [HttpPost]
        public async Task<ActionResult<ShowDto>> CreateShow([FromQuery] long tourId, [FromBody] CreateOrUpdateShowDto showDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var show = await _showService.AddShow(tourId, showDto);

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
        public async Task<ActionResult<ShowDto>> UpdateShow([FromQuery] long showId, [FromBody] CreateOrUpdateShowDto showDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var show = await _showService.UpdateShow(showId, showDto);

                if (show is null)
                    return BadRequest();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteShow([FromQuery] long showId)
        {
            try
            {
                bool result = await _showService.DeleteShow(showId);

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
