using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CustomerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IOptions<JWTTokenConfig> _config;

        public AuthenticationController(IOptions<JWTTokenConfig> config)
        {
            _config = config;
        }

        [HttpPost]
        [Route("Login")]
        [Produces("application/json")]
        public IActionResult Login([FromBody] UserCredentials credentials)
        {
            var token =  Authorize(credentials);
            if (token == null) { return Unauthorized(); }
            return Ok(token);
        }

        private string Authorize(UserCredentials userCredentials)
        {
            
            if (userCredentials.Username== "admin" && userCredentials.Password=="password")
            {
                var identity = new ClaimsIdentity(new Claim[]
                 {
                    new Claim(ClaimTypes.NameIdentifier,"2"),
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Role, "AdminUser")
                 });

                return GenerateToken(identity);
            }
            return null;
        }       

        private string GenerateToken(ClaimsIdentity claimsIdentity)
        {
            if (claimsIdentity == null) { return null; }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddDays(_config.Value.ExpirationTimeDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}