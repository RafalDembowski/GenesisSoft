using AutoMapper.Configuration;
using Domain;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace API.Services
{
    public class JwtTokenService
    {
        private readonly IConfiguration _configuration;
        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateJwtToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier , user.Id),
                new Claim(ClaimTypes.Email , user.Email),
                new Claim(ClaimTypes.Name , user.Name)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenKey"]));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            //zmniejszyć czas trawania po dodaniu refresh tokena
            SecurityTokenDescriptor jwtTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = credentials
            };

            JwtSecurityTokenHandler jwTokenHandler = new JwtSecurityTokenHandler();

            SecurityToken token = jwTokenHandler.CreateToken(jwtTokenDescriptor);

            return jwTokenHandler.WriteToken(token);
        }
    }
}
