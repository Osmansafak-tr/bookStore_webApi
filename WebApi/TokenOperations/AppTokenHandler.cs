using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebApi.Entities;
using WebApi.TokenOperations.Models;

namespace WebApi.TokenOperations
{
    public class AppTokenHandler
    {
        public  IConfiguration Configuration { get; set; }

        public AppTokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Token CreateJwtToken(User user)
        {
            Token tokenModel = new Token();
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            DateTime tokenExpirationTime = DateTime.Now.AddMinutes(15);
            
            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: Configuration["Token:Issuer"],
                audience: Configuration["Token:Audience"],
                expires: tokenExpirationTime,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials
            );

            tokenModel.AccessToken = CreateAccessToken(securityToken);
            tokenModel.RefreshToken = CreateRefreshToken();
            tokenModel.Expiration = tokenExpirationTime;
            return tokenModel;
        }

        private string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }

        private string CreateAccessToken(JwtSecurityToken securityToken)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(securityToken);
        }
    }
}
