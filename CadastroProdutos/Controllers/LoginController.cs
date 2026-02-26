using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using CadastroProdutos.Dtos.Requests;
using Microsoft.IdentityModel.Tokens;

namespace CadastroProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(IConfiguration configuration) : ControllerBase
    {
        [HttpPost]
        public ActionResult Login(LoginRequest login)
        {
            string role;
            // validar users
            
            switch (login)
            {
                case { Usuario: "admin", Senha: "admin123" }:
                    role = "admin";
                    break;
                case { Usuario: "cliente", Senha: "cliente123" }:
                    role = "cliente";
                    break;
                default:
                    return Unauthorized();
            }
            
            // criar o token JWT
            var jwtConfig = configuration.GetSection("Jwt");
            var keyString = jwtConfig["Key"]
                            ?? throw new Exception("JWT Key nao configurada");
            
            var key = Encoding.ASCII.GetBytes(keyString);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity([
                    new Claim(ClaimTypes.Name, login.Usuario),
                    new Claim(ClaimTypes.Role, role)
                ]),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = jwtConfig["Issuer"],
                Audience = jwtConfig["Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            
            return Ok(new { Token = tokenString });
        }
    }
}
