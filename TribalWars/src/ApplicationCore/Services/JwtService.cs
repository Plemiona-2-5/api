using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApplicationCore.Interfaces;
using ApplicationCore.Settings;
using Microsoft.IdentityModel.Tokens;

namespace ApplicationCore.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtService(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public string GenerateJwtToken(string userId)
        {
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenLifetimeInSeconds = Convert.ToDouble(_jwtSettings.JwtTokenLifetimeInSeconds);

            var claims = new Claim[]
            {
                new(JwtRegisteredClaimNames.Sub, userId)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddSeconds(tokenLifetimeInSeconds),
                Issuer = _jwtSettings.Issuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}