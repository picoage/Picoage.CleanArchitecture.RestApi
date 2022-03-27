using MediatR;
using Picoage.CleanArchitecture.RestApi.Application.Models.ResposeModels;
using Picoage.CleanArchitecture.RestApi.Application.RequestModels;

namespace Picoage.CleanArchitecture.RestApi.Application.Commands
{
    public class AuthenticationCommand: IRequest<AuthenticationResponse>
    {
        public AuthenticationCommand(AuthenticationRequest authenticationRequest)
        {
            AuthenticationRequest = authenticationRequest;
        }

        public AuthenticationRequest AuthenticationRequest { get; }
    }
}
