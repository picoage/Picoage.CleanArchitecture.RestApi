using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Picoage.CleanArchitecture.RestApi.Application.Interfaces.Services;
using Picoage.CleanArchitecture.RestApi.Application.Queries;
using Picoage.CleanArchitecture.RestApi.Application.RequestModels;

namespace Picoage.CleanArchitecture.RestApi.WebApi.Controllers
{
    [Route("api/v1/authentication")]
    public class AuthenticationController(IMediator mediator) : ControllerBase
    {

        /// <summary>
        /// Post User Info To Get Auth Token
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST:
        ///     {
        ///         "Username":"dev@test.com",
        ///         "Password":"4bUlj1GXtE20"          
        ///     }
        ///
        /// </remarks>
        /// <param name="authenticationRequest"></param>
        /// <returns>AuthenticationResponse With JWT Token</returns>
        /// <response code="200">Authentication Response</response>
        /// <response code="400">Bad Request</response>
        /// <response code="204">No Content found</response>  

        [HttpPost]
        [Route("api-token")]
        public async Task<IActionResult> GetAuthenticationToken([FromBody]AuthenticationRequest authenticationRequest)
        {

            if (string.IsNullOrEmpty(authenticationRequest?.Username) || string.IsNullOrEmpty(authenticationRequest.Password))
                return BadRequest(error: "Invalid user name or password");

            return Ok(await mediator.Send(new AuthenticationQuery(authenticationRequest)));
        }
    }
}   