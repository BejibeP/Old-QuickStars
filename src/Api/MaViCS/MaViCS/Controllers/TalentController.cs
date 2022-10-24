using MaViCS.Business.Dtos;
using MaViCS.Business.Interfaces;
using MaViCS.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace MaViCS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalentController : ControllerBase
    {
        private readonly ITalentService _talentService;

        public TalentController(ITalentService talentService)
        {
            _talentService = talentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TalentDto>>> GetAll()
        {
            var talents = await _talentService.GetTalents();
            return Ok(talents);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TalentDto>> GetById(long id)
        {
            var talent = await _talentService.GetTalentById(id);

            if (talent is null)
                return NotFound();

            return Ok(talent);
        }

        [HttpPost]
        public async Task<ActionResult<TalentDto>> Create([FromBody] CreateTalentDto talentDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var talent = await _talentService.AddTalent(talentDto);

                if (talent is null)
                    return BadRequest();

                return Ok(talent);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<ActionResult<TalentDto>> Update([FromQuery] long id, [FromBody] UpdateTalentDto talentDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var talent = await _talentService.UpdateTalent(id, talentDto);

                if (talent is null)
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
                bool result = await _talentService.ArchiveTalent(id);

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
                bool result = await _talentService.DeleteTalent(id);

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
