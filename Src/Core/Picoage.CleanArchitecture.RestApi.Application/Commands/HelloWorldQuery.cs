using MediatR;

namespace Picoage.CleanArchitecture.RestApi.Application.Commands
{
    public class HelloWorldQuery: IRequest<string>
    {
    }
}
