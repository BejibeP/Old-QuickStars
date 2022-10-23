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
        private static ITourService _tourService;
        
        public TourController(ITourService tourService)
        {
            _tourService = tourService;
        }

        [Route("GetTours")]
        [HttpGet]
        public ActionResult<List<TourDto>> GetAll()
        {
            return Ok(_tourService.GetTours());
        }

        [Route("GetToursByTalents")]
        [HttpGet]
        public ActionResult<List<TourDto>> GetByTalents(long talentId)
        {
            return Ok(_tourService.GetToursByTalent(talentId));
        }

        [Route("GetShowsByTour")]
        [HttpGet]
        public ActionResult<IOrderedEnumerable<ShowDto>> GetByTour(long tourId)
        {
            return Ok(_tourService.GetShowsByTour(tourId));
        }

        [Route("GetTourById")]
        [HttpGet]
        public ActionResult<TourDto> GetById(long id)
        {
            var tour = _tourService.GetTourById(id);
            if (tour is null) return NotFound();

            return Ok(tour);
        }

        [Route("CreateTour")]
        [HttpPost]
        public ActionResult<TourDto> Create(CreateOrUpdateTourDto tourDto)
        {
            if (ModelState.IsValid)
            {
                var tour = _tourService.AddTour(tourDto);

                if (tour is null) return BadRequest();

                return Ok(tour);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("CreateShow")]
        [HttpPost]
        public ActionResult<ShowDto> CreateShow(long tourId, CreateOrUpdateShowDto showDto)
        {
            if (ModelState.IsValid)
            {
                var show = _tourService.AddShow(tourId, showDto);

                if (show is null) return BadRequest();

                return Ok(show);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("UpdateTour")]
        [HttpPut]
        public ActionResult<TourDto> Update(long id, CreateOrUpdateTourDto tourDto)
        {
            if (ModelState.IsValid)
            {
                var tour = _tourService.UpdateTour(id, tourDto);

                if (tour is null) return BadRequest();

                return Ok(tour);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("UpdateShow")]
        [HttpPut]
        public ActionResult<ShowDto> UpdateShow(long id, long tourId, CreateOrUpdateShowDto showDto)
        {
            if (ModelState.IsValid)
            {
                var priest = _tourService.UpdateShow(id, tourId, showDto);

                if (priest is null) return BadRequest();

                return Ok(priest);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("ArchiveTour")]
        [HttpPatch]
        public ActionResult Archive(long id)
        {
            _tourService.ArchiveTour(id);
            return NoContent();
        }

        [Route("DeleteTour")]
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            _tourService.DeleteTour(id);
            return NoContent();
        }

        [Route("DeleteShow")]
        [HttpDelete]
        public ActionResult DeleteShow(long id)
        {
            _tourService.DeleteShow(id);
            return NoContent();
        }

    }
}
