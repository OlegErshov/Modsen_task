using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authenticationService;
        public AuthController(IAuthService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<Response>> LogIn([FromBody] UserCredentials userCredentials)
        {
            var response = await _authenticationService.LogInAsync(userCredentials);
            return response.Success ? response : BadRequest(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<Response>> Register([FromBody] RegistrationModel user)
        {
            var response = await _authenticationService.RegisterAsync(user);
            return response.Success ? response : BadRequest(response);
        }
    }
}
