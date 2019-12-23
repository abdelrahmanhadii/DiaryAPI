using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TodoListAPI.Helpers
{
    public static class Token
    {
        public static string CreateToken(string userId, IList<string> identityRoles)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Sid, userId)
            };
            foreach (var item in identityRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item)); ;
            }
            var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:54467",
                    audience: "http://localhost:54467",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(50),
                    signingCredentials: signinCredentials
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }
    }
}
