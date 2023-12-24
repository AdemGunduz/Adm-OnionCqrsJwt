using Adm.Application.Dto;
using Adm.Application.Features.CQRS.UserQuery;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Adm.Application.Security
{
    public class TokenHandler
    {
        public static TokenDto GenerateToken(CheckUserQueryResponse response)
        {
            var claims = new List<Claim>();

            if (!string.IsNullOrWhiteSpace(response.Role))
                claims.Add(new Claim(ClaimTypes.Role, response.Role));

            claims.Add(new Claim(ClaimTypes.NameIdentifier, response.Id.ToString()));

            if (!string.IsNullOrWhiteSpace(response.Username))
                claims.Add(new Claim("Username", response.Username));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Token.Key));

            var signinCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expireDate = DateTime.UtcNow.AddDays(Token.Expire);

            JwtSecurityToken token = new JwtSecurityToken(issuer: Token.ValidIssuer, audience: Token.ValidAudience, claims: claims, notBefore: DateTime.UtcNow, expires: expireDate, signingCredentials: signinCredentials);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            return new TokenDto(tokenHandler.WriteToken(token), expireDate);


        }
    }
}
