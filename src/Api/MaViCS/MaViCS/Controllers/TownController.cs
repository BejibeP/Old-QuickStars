using MaViCS.Business.Dtos;
using MaViCS.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MaViCS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TownController : ControllerBase
    {
        private readonly ITownService _townService;

        public TownController(ITownService townService)
        {
            _townService = townService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TownDto>>> GetAll()
        {
            var towns = await _townService.GetTowns();
            return Ok(towns);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TownDto>> GetById([FromQuery] long id)
        {
            var town = await _townService.GetTownById(id);

            if (town is null)
                return NotFound();

            return Ok(town);
        }

        [HttpPost]
        public async Task<ActionResult<TownDto>> Create([FromBody] CreateOrUpdateTownDto townDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var town = await _townService.AddTown(townDto);

                if (town is null)
                    return BadRequest();

                return Ok(town);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<ActionResult<TownDto>> Update([FromQuery] long id, [FromBody] CreateOrUpdateTownDto shrineDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var town = await _townService.UpdateTown(id, shrineDto);

                if (town is null)
                    return NotFound();

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
                bool result = await _townService.ArchiveTown(id);

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
                bool result = await _townService.DeleteTown(id);

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
