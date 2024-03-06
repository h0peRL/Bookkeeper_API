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
            try
            {
                IUserRoleState newUserRoleState = new NewUserRoleState();
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
                User user = new(null, request.Username, hashedPassword, newUserRoleState);
                _dataRepository.AddUser(user);
                _dataRepository.DisapproveExistingUser(user);
                return Ok("User created successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(UserDto request)
        {
            try
            {
                User user = _dataRepository.GetUserByUsername(request.Username);
                if (user == null) return Unauthorized("Invalid username or password");
                if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash)) return Unauthorized("Invalid username or password");
                if (user.Role.GetRoleName() == "new user") return Unauthorized("User is not authorized yet");

                string token = GenerateToken(user);
                return Ok(token);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("authorize/{userId}")]
        [Authorize]
        public IActionResult AuthorizeUser(int userId)
        {
            try
            {
                _dataRepository.AuthorizeNewUser(_dataRepository.GetUserById(userId));
                return Ok("User authorized successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private string GenerateToken(User user)
        {
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim("UserId", user.Id.ToString() ?? string.Empty),
                    new Claim("Role", user.Role.ToString() ?? string.Empty)
                },
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
