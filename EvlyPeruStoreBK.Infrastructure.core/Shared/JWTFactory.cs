﻿using EvlyPeruStoreBK.core.Settings;
using EvlyPeruStoreBK.Infrastructure.core.Data;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace EvlyPeruStoreBK.Infrastructure.core.Shared
{
    public class JWTFactory : IJWTFactory
    {
        private readonly JWTSettings _jwtSettings;

        public JWTFactory(IOptions<JWTSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public string GenerateJWToken(Naturalperson user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Email)
            };

            byte[] keyBytes;
            using (var rng = RandomNumberGenerator.Create())
            {
                keyBytes = new byte[32]; // Clave de 256 bits (32 bytes)
                rng.GetBytes(keyBytes);
            }
            var key = new SymmetricSecurityKey(keyBytes);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: creds

            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
