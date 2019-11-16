﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace tokenGen
{
    public class tokenGenerator
    {
        public static async Task<string> generator(string privateKey, string json)
        {
            var issuer = "Machete.com/remitente";
            var authority = "MacheteMontenegro";
            var createJwt = await CreateJWTAsync(issuer, authority, privateKey, json);
            return createJwt;
        }

        public static async Task<string> CreateJWTAsync(string issuer, string authority, string symSec, string userJson)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = await CreateClaimsIdentities(userJson);

            var token = tokenHandler.CreateJwtSecurityToken(
                issuer: issuer,
                audience: authority,
                subject: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials:
                new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.Default.GetBytes(symSec)),
                        SecurityAlgorithms.HmacSha256Signature));

            return tokenHandler.WriteToken(token);
        }

        public static Task<ClaimsIdentity> CreateClaimsIdentities(string userJson)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, userJson));
            return Task.FromResult(claimsIdentity);
        }

    }
}
