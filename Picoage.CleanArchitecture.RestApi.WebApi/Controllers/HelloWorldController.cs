using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Picoage.CleanArchitecture.RestApi.WebApi.Controllers
{
    [Route("api/v1/")]
    [Authorize]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet("helloworld")]
        public IActionResult GetHelloWorld()
        {
            return Ok("Hello World"); 
        }
    }
}