using Microsoft.AspNetCore.Mvc;
using SistemaDeRecarga.Auth;
using SistemaDeRecarga.Model;

namespace SistemaDeRecarga.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            // Simulação de autenticação (substituir por uma lógica real)
            if (user.Username == "admin" && user.Password == "admin123")
            {
                var token = _tokenService.GenerateToken(user);
                return Ok(new { token });
            }

            return Unauthorized("Usuário ou senha inválidos.");
        }
    }
}
