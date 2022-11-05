using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickStars.MaViCS.Business.Dtos;
using QuickStars.MaViCS.Business.Interfaces;

namespace QuickStars.MaViCS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(long id)
        {
            var user = await _userService.GetUserById(id);

            if (user is null)
                return NotFound();

            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult<UserDto>> Update([FromQuery] long id, [FromBody] UpdateUserDto userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = await _userService.UpdateUser(id, userDto);

                if (user is null)
                    return NotFound();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [Route("Manage")]
        [HttpPut]
        public async Task<ActionResult<UserDto>> Update([FromQuery] long id, [FromBody] ManageUserDto userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = await _userService.ManageUser(id, userDto);

                if (user is null)
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
                bool result = await _userService.ArchiveUser(id);

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
                bool result = await _userService.DeleteUser(id);

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
