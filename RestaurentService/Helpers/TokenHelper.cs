using Microsoft.IdentityModel.Tokens;
using RestaurentService.DTOS;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestaurentService.Helpers
{
    public class TokenHelper
    {
        string key = "***ITC###INFOTECH***";
        public string GenerateToken(RestaurentLoginDTO u)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                    new Claim("Role", "Restaurent"),
                    new Claim("Email",u.Email)
    };
            var token = new JwtSecurityToken("www.abc.com",
              "www.abc.com",
             claims,
             expires: DateTime.Now.AddMinutes(12000),
             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
