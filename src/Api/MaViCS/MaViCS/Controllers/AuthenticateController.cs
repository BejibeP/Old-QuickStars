using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickStars.MaViCS.Business.Dtos.Auth;
using QuickStars.MaViCS.Business.Interfaces.Auth;

namespace QuickStars.MaViCS.Controllers
{
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthenticateController(IAuthService authService)
        {
            _authService = authService;
        }

        [Route("api/login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _authService.Login(dto);

            if (result.Type == Business.ResultType.Unauthorized)
                return Unauthorized();

            return Ok(result);
        }

        [Route("api/register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var result = await _authService.Register(dto);

            if (result.Type == Business.ResultType.Unauthorized)
                return Unauthorized();

            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        [Route("/api/claims")]
        public async Task<IActionResult> GetUserInfos()
        {
            var userInfo = await _authService.GetUserInfos(User);
            return Ok(userInfo);
        }

    }
}
