using MaViCS.Business.Dtos;
using MaViCS.Business.Interfaces;
using MaViCS.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace MaViCS.Controllers
{
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
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(long id)
        {
            var user = await _userService.GetUserById(id);

            if (user is null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet("Login")]
        public async Task<ActionResult<UserDto>> LoginUser([FromQuery] string login, [FromQuery] string password)
        {
            var user = await _userService.AuthenticateUser(login, password);

            if (user is null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Create([FromBody] CreateUserDto userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = await _userService.AddUser(userDto);

                if (user is null)
                    return BadRequest();

                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
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

        [HttpPut("UserRole")]
        public async Task<ActionResult<UserDto>> Update([FromQuery] long id, [FromBody] UpdateUserRoleDto userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = await _userService.UpdateUserRole(id, userDto);

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
