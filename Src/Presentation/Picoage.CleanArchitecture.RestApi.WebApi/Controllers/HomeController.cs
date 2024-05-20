using Microsoft.AspNetCore.Mvc;

namespace Picoage.CleanArchitecture.RestApi.WebApi.Controllers;
public class HomeController : ControllerBase
{
    [HttpGet()]
    public IActionResult Get()
    {
        return Ok("Test");
    }
}
