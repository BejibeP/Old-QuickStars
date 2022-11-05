using Microsoft.AspNetCore.Mvc;
using QuickStars.MaViCS.Business.Dtos;
using QuickStars.MaViCS.Business.Interfaces;
using QuickStars.MaViCS.Domain.Interfaces;
using QuickStars.MaViCS.Domain.Security;

namespace QuickStars.MaViCS.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ISecurityService _securityService;

        public AuthController(IUserService userService, ISecurityService securityService)
        {
            _userService = userService;
            _securityService = securityService;
        }

        [Route("api/Login")]
        [HttpGet]
        public async Task<ActionResult<AuthToken>> LoginUser([FromQuery] LoginUserDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userService.LoginUser(loginDto);

            if (user is null)
                return NotFound();

            return Ok(user);
        }

        [Route("api/Register")]
        [HttpPost]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegisterUserDto userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (!_securityService.ValidatePassword(userDto.Password))
                    return BadRequest(SecurityService.InvalidPasswordErrorMessage);

                var user = await _userService.RegisterUser(userDto);

                if (user is null)
                    return BadRequest();

                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [Route("api/ResetPwd")]
        [HttpPut]
        public async Task<ActionResult<UserDto>> Update([FromQuery] ResetPasswordDto passwordDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (!_securityService.ValidatePassword(passwordDto.NewPassword))
                    return BadRequest(SecurityService.InvalidPasswordErrorMessage);

                var user = await _userService.ResetPassword(passwordDto);

                if (user is null)
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
