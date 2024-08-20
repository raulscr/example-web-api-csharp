using Microsoft.AspNetCore.Mvc;

using Auth.Controller.Model;
using Auth.Service.Exceptions;
using Auth.Service;

namespace Auth.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController(ILogger<AuthController> logger, IAuthService service) : ControllerBase
    {
        private readonly ILogger<AuthController> _logger = logger;
        private IAuthService _service = service;

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginRequest userLogin)
        {
            try
            {
                var token = _service.Login(new UserLoginServiceAdapter(userLogin));
                return Ok(new { token });
            }
            catch (AuthenticationFailedServiceException e)
            {
                return Unauthorized(new { e.Message });
            }
        }
    }
}
