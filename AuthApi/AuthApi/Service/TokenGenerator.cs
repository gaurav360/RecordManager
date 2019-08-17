using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Collections.Generic;

namespace AuthApi.Service
{
    public class TokenGenerator : ITokenGenerator
    {
        public string GetJwtToken(string userId, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userId),
                new Claim(JwtRegisteredClaimNames.Typ, role)
            }; 

            claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("My_Token_Security_Key"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "AuthServer",
                audience: "MyServiceApi",
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }
    }
}
