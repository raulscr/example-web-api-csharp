using Microsoft.AspNetCore.Mvc;

using Auth.Controller.Model;
using Auth.Service.Exceptions;
using Auth.Service;

namespace Auth.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly ILogger<AuthController> _logger;
        private IAuthService _service;

        public AuthController(ILogger<AuthController> logger, IAuthService service)
        {
            _logger = logger;
            _service = service;
        }

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
