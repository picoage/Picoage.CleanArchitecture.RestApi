using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Picoage.CleanArchitecture.RestApi.Application.RequestModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Picoage.CleanArchitecture.RestApi.WebApi.AcceptanceTests
{
    public class AcceptanceTestStartup
    {
        private protected HttpClient Client { get; private set; }

        private protected string Username { get; set; } = "dev@test.com";

        private protected string Password { get; set; } = "4bUlj1GXtE20";

        private protected HttpStatusCode StatusCode { get; private set; }

        private static string token;

        private static DateTime expireDate = new DateTime();

        private static readonly DateTime EpochBase = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified);


        public AcceptanceTestStartup(bool authentication = true)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var builder = new WebHostBuilder().UseEnvironment("Development").UseConfiguration(config).UseStartup<Startup>();

            TestServer testServer = new TestServer(builder);

            Client = testServer.CreateClient();

            if (authentication)
                SetAuthenticationToClientHeader().Wait();
        }

        private async Task SetAuthenticationToClientHeader()
        {
            if (expireDate <= DateTime.UtcNow)
            {
                token = await GetBearerToken(Client);

                if (token == null) return;

                var jwtPayLoad = new JwtSecurityToken(token).Payload;

                if (long.TryParse(jwtPayLoad.Where(e => e.Key == "exp").Select(e => e.Value).SingleOrDefault().ToString(), out long epoch))
                {
                    expireDate = EpochBase.AddSeconds(epoch);
                }
            }
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        protected async Task<string> GetBearerToken(HttpClient client)
        {
            try
            {
                AuthenticationRequest authenticationRequest = new AuthenticationRequest { Username = Username, Password = Password };
                var json = JsonConvert.SerializeObject(authenticationRequest);

                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage result = await client.PostAsync(@$"api/v1/authentication/api-token", data);

                StatusCode = result.StatusCode; 
                result.EnsureSuccessStatusCode();

                List<JToken> values = JObject.Parse(await result.Content.ReadAsStringAsync()).Children().ToList();
                return values.LastOrDefault().First().ToString();
            }
            catch (Exception ex)
            {
                return null;
            }


        }
    }
}
