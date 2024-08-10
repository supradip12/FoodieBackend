using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserService.DTOS;

namespace UserService.Helper
{
    public class TokenHelper
    {
        string key = "***ITC###INFOTECH***";
        public string GenerateToken(UserLoginDTO u)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                    new Claim("Role", "User"),
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
