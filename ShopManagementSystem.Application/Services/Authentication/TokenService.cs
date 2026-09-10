using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopManagementSystem.Application.Interfaces.Authentication;
using ShopManagementSystem.Domain.Entities.Identity;

namespace ShopManagementSystem.Application.Services.Authentication;

public class TokenService(IConfiguration configuration) : ITokenService
{
    public string CreateToken(User user)
    {
        var claims = new List<Claim>()
    {
         new Claim(
             ClaimTypes.NameIdentifier,
             user.Id.ToString()),

         new Claim(
             ClaimTypes.Name,
             user.Name),
     };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
                configuration["Jwt:Key"]!));

        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }
}
