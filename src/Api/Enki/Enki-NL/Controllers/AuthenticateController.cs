using Enki.Domain.Dtos;
using Enki.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private static IAuthenticateService _authenticateService;

        public AuthenticateController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost]
        public ActionResult Login(AuthenticateDto request)
        {
            if (ModelState.IsValid)
            {
                var token = _authenticateService.ConnectUser(request);
                return token != null ? Ok(token) : BadRequest("Invalid credentials");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
