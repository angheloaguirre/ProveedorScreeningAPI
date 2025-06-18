using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using ProveedorScreeningAPI.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace ProveedorScreeningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Usuario> _userManager;

        public AuthController(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }

        // Obtener todos los usuarios
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();

            // Si no hay usuarios, devuelve un 404
            if (users == null || users.Count == 0)
            {
                return NotFound("No users found.");
            }

            return Ok(users);
        }

        // Método de login para autenticar y generar JWT
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var token = GenerateJwtToken(model.Username);
                return Ok(new { token });
            }

            return Unauthorized("Invalid credentials");
        }

        // Generación del token JWT
        private string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("supersecretkeythatshouldbe256bitlong..."));
            var creds = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                "your_issuer",
                "your_audience",
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
