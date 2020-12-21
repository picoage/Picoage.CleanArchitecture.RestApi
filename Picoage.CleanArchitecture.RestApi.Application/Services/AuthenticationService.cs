using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Picoage.CleanArchitecture.RestApi.Application.AppSettings;
using Picoage.CleanArchitecture.RestApi.Application.Interfaces.Repositories;
using Picoage.CleanArchitecture.RestApi.Application.Interfaces.Services;
using Picoage.CleanArchitecture.RestApi.Application.Models.ResposeModels;
using Picoage.CleanArchitecture.RestApi.Domain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Picoage.CleanArchitecture.RestApi.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IOptions<AuthenticationSettings> authenticationConfiguration;

        public AuthenticationService(ICustomerRepository customerRepository, IOptions<AuthenticationSettings> authenticationConfiguration)
        {
            this.customerRepository = customerRepository;
            this.authenticationConfiguration = authenticationConfiguration;
        }

        public async Task<AuthenticationResponse> Authenticate(string userName, string password)
        {
            IEnumerable<Customer> users = await customerRepository.GetAll();

            Customer user = users.SingleOrDefault(x => x.UserName == userName && x.Password == GetHashedPassword(password, x.Salt));

            if (user == null) return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(authenticationConfiguration.Value.Key);
            var expires = DateTime.UtcNow.AddDays(authenticationConfiguration.Value.Expire);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
               {
                   new Claim(ClaimTypes.Name, user.UserName),
                   new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString())
               }),
                Issuer = "JWT:Picoage",
                Expires = DateTime.UtcNow.AddDays(authenticationConfiguration.Value.Expire),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            string tokenAsString = tokenHandler.WriteToken(token);

            return new AuthenticationResponse
            {
                UserName = user.UserName,
                ExpireTime = GetEpoch(expires),
                Token = tokenAsString
            };
        }

        private int GetEpoch(DateTime expires)
        {
            TimeSpan timeSpan = expires - new DateTime(1970, 1, 1);
            return (int)timeSpan.TotalSeconds;
        }

        private string GetHashedPassword(string password, string salt)
        {
            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                 password: password,
                 salt: Convert.FromBase64String(salt),
                 prf: KeyDerivationPrf.HMACSHA1,
                 iterationCount: 10000,
                 numBytesRequested: 256 / 8));
        }
    }
}
