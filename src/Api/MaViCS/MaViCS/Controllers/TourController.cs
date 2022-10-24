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
        public async Task<ActionResult<IEnumerable<TourDto>>> GetByTalents(long talentId)
        {
            var tours = await _tourService.GetToursByTalent(talentId);
            return Ok(tours);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TourDto>> GetById(long id)
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

        [HttpPut]
        public async Task<ActionResult<TourDto>> Update([FromQuery] long tourId, [FromBody] CreateOrUpdateTourDto tourDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var tour = await _tourService.UpdateTour(tourId, tourDto);

                if (tour is null)
                    return BadRequest();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPatch]
        public async Task<ActionResult> Archive([FromQuery] long tourId)
        {
            try
            {
                bool result = await _tourService.ArchiveTour(tourId);

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
        public async Task<ActionResult> Delete([FromQuery] long tourId)
        {
            try
            {
                bool result = await _tourService.DeleteTour(tourId);

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
