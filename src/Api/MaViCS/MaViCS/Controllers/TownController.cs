using MaViCS.Business.Dtos;
using MaViCS.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MaViCS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TownController : ControllerBase
    {
        private static ITownService _townService;

        public TownController(ITownService townService)
        {
            _townService = townService;
        }

        [HttpGet]
        public ActionResult<List<TownDto>> GetAll()
        {
            return Ok(_townService.GetTowns());
        }

        [HttpGet]
        public ActionResult<List<TownDto>> GetById(long id)
        {
            var town = _townService.GetTownById(id);
            if (town is null) return NotFound();

            return Ok(town);
        }

        [HttpPost]
        public ActionResult<TownDto> Create(CreateOrUpdateTownDto townDto)
        {
            if (ModelState.IsValid)
            {
                var town = _townService.AddTown(townDto);

                if (town is null) return BadRequest();

                return Ok(town);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public ActionResult<TownDto> Update(long id, CreateOrUpdateTownDto shrineDto)
        {
            if (ModelState.IsValid)
            {
                var town = _townService.UpdateTown(id, shrineDto);

                if (town is null) return BadRequest();

                return Ok(town);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPatch]
        public ActionResult Archive(long id)
        {
            _townService.ArchiveTown(id);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete(long id) 
        {
            _townService.DeleteTown(id);
            return NoContent();
        }

    }
}
