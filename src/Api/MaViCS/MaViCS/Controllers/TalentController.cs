using MaViCS.Business.Dtos;
using MaViCS.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MaViCS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalentController : ControllerBase
    {
        private static ITalentService _talentService;

        public TalentController(ITalentService talentService)
        {
            _talentService = talentService;
        }

        [HttpGet]
        public ActionResult<List<TalentDto>> GetAll()
        {
            return Ok(_talentService.GetTalents());
        }

        [HttpGet]
        public ActionResult<List<TalentDto>> GetById(long id)
        {
            var talent = _talentService.GetTalentById(id);
            if (talent is null) return NotFound();

            return Ok(talent);
        }

        [HttpPost]
        public ActionResult<TalentDto> Create(CreateTalentDto talentDto)
        {
            if (ModelState.IsValid)
            {
                var talent = _talentService.AddTalent(talentDto);

                if (talent is null) return BadRequest();

                return Ok(talent);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public ActionResult<TalentDto> Update(long id, UpdateTalentDto talentDto)
        {
            if (ModelState.IsValid)
            {
                var talent = _talentService.UpdateTalent(id, talentDto);

                if (talent is null) return BadRequest();

                return Ok(talent);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPatch]
        public ActionResult Archive(long id)
        {
            _talentService.ArchiveTalent(id);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            _talentService.DeleteTalent(id);
            return NoContent();
        }

    }
}
