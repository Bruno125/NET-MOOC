using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using ShoppingCart.Repository;
using Microsoft.IdentityModel.Tokens;

namespace ShoppingCart.Jwt
{
    public interface ITokenProvider
    {
        string GetPath();
        Task<TokenResponse> GetToken(string userId = null);
        string ReadUserId(string token);
    }

    public class JwtTokenProvider : ITokenProvider
    {
        private TokenProviderOptions _options;
        private JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        public JwtTokenProvider(TokenProviderOptions options)
        {
            _options = options;
        }

        public string GetPath()
        {
            return _options.Path;
        }

        public async Task<TokenResponse> GetToken(string userId = null)
        {
            var now = DateTime.UtcNow;
            var expire = now.Add(_options.Expiration);


            var claims = new List<Claim>();

            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            if(userId != null)
                claims.Add(new Claim("userId", userId));

            /*claims.Add(new Claim(JwtRegisteredClaimNames.Iat, 
                                 DateTimeOffset.FromUnixTimeSeconds(now.ToString()).ToString(),
                                 ClaimValueTypes.Integer64));
            if (userId != null)
            {
                claims.Add(new Claim(JwtRegisteredClaimNames.Sub, userId));
            }*/
                
            // Create the JWT and write it to a string

            var jwt = new JwtSecurityToken(
                claims: claims,
                notBefore: now,
                issuer: _options.Issuer,
                signingCredentials: _options.SigningCredentials,
                expires: expire);
            var encodedJwt = tokenHandler.WriteToken(jwt);

            var response = new TokenResponse()
            {
                DataResponse = new TokenResponse.Data()
                {
					AccessToken = encodedJwt,
                    ExpireTime = (int) _options.Expiration.TotalSeconds   
                }
            };

            // Serialize and return the response
            return response;
        }

        public string ReadUserId(string tokenString)
        {
            try
			{
				//Check if readable token (string is in a JWT format)
                var readableToken = tokenHandler.CanReadToken(tokenString);

				if (!readableToken)
				{
                    return null;
				}

                var token = tokenHandler.ReadJwtToken(tokenString);

				var userId = token.Claims.SingleOrDefault(claim => claim.Type == "userId").Value;
				return userId;
            }catch
            {
                return null;
            }

		}

    }
}
