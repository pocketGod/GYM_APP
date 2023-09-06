using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using GYM_MODELS.Settings;
using MongoDB.Driver.Linq;

namespace GYM_LOGICS.Services
{
    public class JWTService
    {
        private readonly JwtSettings _jwtSettings;

        public JWTService(JwtSettings jwtSettings)
        {
            _jwtSettings= jwtSettings;
        }

        public string GenerateJwtToken(string username)
        {
            Claim[] claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            SymmetricSecurityKey key = new(Encoding.ASCII.GetBytes(_jwtSettings.SecretKey));
            SigningCredentials creds = new (key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new(claims: claims, expires: DateTime.Now.AddMinutes(_jwtSettings.TokenExpirationMinutes), signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
