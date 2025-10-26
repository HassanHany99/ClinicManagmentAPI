using ClinicAPI.Data;
using ClinicAPI.DTOs;
using ClinicAPI.Models;
using ClinicAPI.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClinicAPI.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly IConfiguration _config;
        private readonly ClinicDbContext _context;

        public AuthController(IConfiguration config, ClinicDbContext context)
        {
            _config = config;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if (_context.Users.Any(u => u.Username == user.Username))
                return ErrorResponse("Username already exists.");

            _context.Users.Add(user);
            _context.SaveChanges();
            return SuccessResponse(user, "User Created");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(UserDataDTO user)
        {
            var account = _context.Users
                .FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

            if (account == null)
                return UnAuthorizedResponse();

            var token = GenerateJwtToken(account);
            return SuccessResponse(token, "Token Generated", 200);
        }

        private string GenerateJwtToken(User account)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.Username),
                new Claim(ClaimTypes.Role, account.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
