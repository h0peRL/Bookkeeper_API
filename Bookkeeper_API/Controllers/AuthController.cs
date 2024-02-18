using Bookkeeper_API.Data.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookkeeper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Register(UserDto request)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Login(UserDto request)
        {
            throw new NotImplementedException();
        }
    }
}
