using Bookkeeper_API.Data;
using Bookkeeper_API.Data.DTOs;
using Bookkeeper_API.Model.UserManagement;
using Bookkeeper_API.Model.UserManagement.RoleStates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace Bookkeeper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IDataRepository _dataRepository;
        private readonly IConfiguration _configuration;

        public AuthController(ILogger<AuthController> logger, AppDbContext dbContext, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _dataRepository = new EFCoreDataRepository(dbContext);
        }

        [HttpPost("register")]
        public IActionResult Register(UserDto request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("login")]
        public IActionResult Login(UserDto request)
        {
            throw new NotImplementedException();
        }
    }
}
