using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Picoage.CleanArchitecture.RestApi.WebApi
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    [RateLimit(Name = "Limit Request Number", Seconds = 1.0)]
    public class BaseController:ControllerBase
    {
    }
}
