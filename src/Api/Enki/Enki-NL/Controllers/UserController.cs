using Enki.Domain.Dtos;
using Enki.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Enki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpPost]
        [Authorize(Roles = "Senator")]
        public ActionResult Post(AddUserDto dto)
        {
            if (ModelState.IsValid)
            {

                return Ok(_userService.AddUser(dto));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
