using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using CadastroProdutos.Dtos.Requests;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;

namespace CadastroProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            configuration = _configuration;
        }

        [HttpPost]
        public ActionResult Login(LoginRequest login)
        {
            string role;
            // validar users
            
            switch (login)
            {
                case { Usuario: "admin", Senha: "exemplo123" }:
                    role = "admin";
                    break;
                case { Usuario: "cliente", Senha: "exemplo123" }:
                    role = "cliente";
                    break;
                default:
                    return Unauthorized();
            }
            
            // criar o token JWT
            var jwtConfig = _configuration.GetSection("Jwt");
            var key = Encoding.ASCII.GetBytes(jwtConfig["Key"]);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity([
                    new Claim("usuario", login.Usuario),
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
