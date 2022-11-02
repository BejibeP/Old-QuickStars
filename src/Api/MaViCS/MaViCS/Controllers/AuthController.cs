using MaViCS.Business.Dtos;
using MaViCS.Business.Interfaces;
using MaViCS.Domain.Framework.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace MaViCS.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly AuthHelper _securityHelper;

        public AuthController(IUserService userService, AuthHelper securityHelper)
        {
            _userService = userService;
            _securityHelper = securityHelper;
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

                if (!_securityHelper.VerifyPassword(userDto.Password))
                    return BadRequest(AuthHelper.InvalidPasswordErrorMessage);

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

                if (!_securityHelper.VerifyPassword(passwordDto.NewPassword))
                    return BadRequest(AuthHelper.InvalidPasswordErrorMessage);

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
