using Microsoft.AspNetCore.Identity.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Auth.Service.Model;
using Auth.Service.Exceptions;

namespace Auth.Service
{
    public class AuthService : IAuthService
    {
        public string Login(UserLoginModel user)
        {
            // call repository to verify
            if (user.Login != "admin" || user.Password != "123456")
            {
                throw new AuthenticationFailedServiceException("User or Password incorrect");
            }
            return GenerateJwtToken(user.Login);
        }

        private string GenerateJwtToken(string login)
        {
            var key = Encoding.ASCII.GetBytes("SuaChaveSecretaSuperSegura1234567");
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, login)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}