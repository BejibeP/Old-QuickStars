using MaViCS.Business.Dtos;
using MaViCS.Business.Interfaces;
using MaViCS.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace MaViCS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly ITourService _tourService;

        public TourController(ITourService tourService)
        {
            _tourService = tourService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourDto>>> GetAll()
        {
            var tours = await _tourService.GetTours();
            return Ok(tours);
        }

        [HttpGet("{talentId}")]
        public async Task<ActionResult<IEnumerable<TourDto>>> GetByTalents([FromQuery] long talentId)
        {
            var tours = await _tourService.GetToursByTalent(talentId);
            return Ok(tours);
        }

        [HttpGet("{tourId}")]
        public async Task<ActionResult<IOrderedEnumerable<ShowDto>>> GetByTour([FromQuery] long tourId)
        {
            var shows = await _tourService.GetShowsByTour(tourId);
            return Ok(shows);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TourDto>> GetById([FromQuery] long id)
        {
            var tour = await _tourService.GetTourById(id);

            if (tour is null)
                return NotFound();

            return Ok(tour);
        }

        [HttpPost]
        public async Task<ActionResult<TourDto>> Create([FromBody] CreateOrUpdateTourDto tourDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var tour = await _tourService.AddTour(tourDto);

                if (tour is null)
                    return BadRequest();

                return Ok(tour);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("{tourId}")]
        public async Task<ActionResult<ShowDto>> CreateShow([FromQuery] long tourId, [FromBody] CreateOrUpdateShowDto showDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var show = await _tourService.AddShow(tourId, showDto);

                if (show is null)
                    return BadRequest();

                return Ok(show);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{tourId}")]
        public async Task<ActionResult<TourDto>> Update([FromQuery] long id, [FromBody] CreateOrUpdateTourDto tourDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var tour = await _tourService.UpdateTour(id, tourDto);

                if (tour is null)
                    return BadRequest();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{showId}")]
        public async Task<ActionResult<ShowDto>> UpdateShow([FromQuery] long id, [FromQuery] long tourId, [FromBody] CreateOrUpdateShowDto showDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var priest = await _tourService.UpdateShow(id, tourId, showDto);

                if (priest is null)
                    return BadRequest();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPatch("{tourId}")]
        public async Task<ActionResult> Archive([FromQuery] long id)
        {
            try
            {
                bool result = await _tourService.ArchiveTour(id);

                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{tourId}")]
        public async Task<ActionResult> Delete([FromQuery] long id)
        {
            try
            {
                bool result = await _tourService.DeleteTour(id);

                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{showId}")]
        public async Task<ActionResult> DeleteShow([FromQuery] long id)
        {
            try
            {
                bool result = await _tourService.DeleteShow(id);

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
