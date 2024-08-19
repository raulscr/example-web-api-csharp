using Microsoft.AspNetCore.Identity.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Auth.Service.Model;
using Auth.Service.Exceptions;

using User.Repository;

namespace Auth.Service
{
    public class AuthService : IAuthService
    {
        private readonly ILogger<AuthService> _logger;
        private IUserRepository _userRepository;

        public AuthService(ILogger<AuthService> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public string Login(UserLoginModel user)
        {
            // try to find the user by userName
            var registredUser = _userRepository.GetUserByName(user.Login).Result;
            if (registredUser == null)
            {
                throw new AuthenticationFailedServiceException("User not found");
            }

            if (user.Password != registredUser.Password)
            {
                throw new AuthenticationFailedServiceException("Password incorrect");
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