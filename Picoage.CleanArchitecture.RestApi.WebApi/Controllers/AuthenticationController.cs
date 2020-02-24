using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Picoage.CleanArchitecture.RestApi.Application.Interfaces.Services;
using Picoage.CleanArchitecture.RestApi.Application.RequestModels;

namespace Picoage.CleanArchitecture.RestApi.WebApi.Controllers
{
    [Route("api/v1/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("api-token")]
        public async Task<IActionResult> GetAuthenticationToken([FromBody]AuthenticationRequest authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest?.Username) || string.IsNullOrEmpty(authenticationRequest.Password))
                return BadRequest(error: "Invalid user name or password");

            return Ok(await authenticationService.Authenticate(authenticationRequest.Username, authenticationRequest.Password));
        }
    }
}