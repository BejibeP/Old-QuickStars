using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickStars.MaViCS.Business.Dtos;
using QuickStars.MaViCS.Business.Interfaces;
using QuickStars.MaViCS.Domain.Auth;
using QuickStars.MaViCS.Extensions;

namespace QuickStars.MaViCS.Controllers
{
    [Authorize(Roles = IdentityRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class TalentController : ControllerBase
    {
        private readonly ITalentService _talentService;

        public TalentController(ITalentService talentService)
        {
            _talentService = talentService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TalentDto>>> GetAll()
        {
            var talents = await _talentService.GetTalents();
            return this.FromResult(talents);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<TalentDto>> GetById(long id)
        {
            var talent = await _talentService.GetTalentById(id);
            return this.FromResult(talent);
        }

        [HttpPost]
        public async Task<ActionResult<TalentDto>> Create([FromBody] CreateTalentDto talentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var talent = await _talentService.AddTalent(talentDto);
            return this.FromResult(talent);
        }

        [HttpPut]
        public async Task<ActionResult<TalentDto>> Update([FromQuery] long id, [FromBody] UpdateTalentDto talentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var talent = await _talentService.UpdateTalent(id, talentDto);
            return this.FromResult(talent);
        }

        [HttpPatch]
        public async Task<ActionResult> Archive([FromQuery] long id)
        {
            var result = await _talentService.ArchiveTalent(id);
            return this.FromResult(result);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] long id)
        {
            var result = await _talentService.DeleteTalent(id);
            return this.FromResult(result);
        }
    }
}
