using MediatR;
using Microsoft.AspNetCore.Mvc;
using Picoage.CleanArchitecture.RestApi.Application.Commands;
using System.Threading.Tasks;

namespace Picoage.CleanArchitecture.RestApi.WebApi.Controllers
{
    public class HelloWorldController : BaseController
    {
        private readonly IMediator mediator;

        public HelloWorldController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> GetHelloWorld()
        {
            return Ok(await mediator.Send(new HelloWorldQuery())); 
        }
    }
}