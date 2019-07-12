﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend.Service.Authorization.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Service.Authorization.Utils
{
    public class JwtTokenGenerator: IJwtTokenGenerator
    {
        private readonly JwtSettings _jwtSettings;

        public JwtTokenGenerator(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public string GenerateToken(Guid userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecretKey = Encoding.ASCII.GetBytes(_jwtSettings.JwtSecret);
            var claims = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, userId.ToString()),
            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = null,
                Issuer = null,
                Subject = claims,
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(jwtSecretKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var serializedToken = tokenHandler.WriteToken(token);

            return serializedToken;
        }
    }
}
