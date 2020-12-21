using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Picoage.CleanArchitecture.RestApi.WebApi.Controllers
{
    public class HelloWorldController : BaseController
    {
        [HttpGet()]
        public IActionResult GetHelloWorld()
        {
            return Ok("Hello World"); 
        }
    }
}