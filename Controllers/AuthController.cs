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
        private readonly IUserBusiness _userBusiness;

        public AuthController(TokenService tokenService, IUserBusiness userBusiness)
        {
            _tokenService = tokenService;
            _userBusiness = userBusiness;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            // Simulação de autenticação (substituir por uma lógica real)
            //if (loginRequest.Email == "admin@sistema.com" && loginRequest.Password == "admin123")
            //{
            //    var tokem = _tokenService.GenerateToken(loginRequest);
            //    return Ok(new { tokem });
            //}

            var user = await _userBusiness.AuthenticateAsync(loginRequest.Email, loginRequest.Password);
            if (user == null)
            {
                return Unauthorized(new { Message = "Email ou senha inválidos"});
            }

            var token = _tokenService.GenerateToken(user);

            return Ok(new
            {
                token,
                user = new
                {
                    id = user.Id,
                    username = user.Username,
                    email = user.Email,
                    role = user.Role
                }
            });
        }
    }
}
