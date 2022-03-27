using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Picoage.CleanArchitecture.RestApi.Application.Commands.Handlers
{
    internal class HelloWorldQueryHandler : IRequestHandler<HelloWorldQuery, string>
    {
        public async Task<string> Handle(HelloWorldQuery request, CancellationToken cancellationToken)
        {
          return await Task.Run(() =>
            {
                return "Hello World";
            });  
        }
    }
}
