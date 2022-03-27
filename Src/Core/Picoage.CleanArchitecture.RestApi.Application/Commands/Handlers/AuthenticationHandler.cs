using MediatR;
using Picoage.CleanArchitecture.RestApi.Application.Interfaces.Services;
using Picoage.CleanArchitecture.RestApi.Application.Models.ResposeModels;
using System.Threading;
using System.Threading.Tasks;

namespace Picoage.CleanArchitecture.RestApi.Application.Commands.Handlers
{
    public class AuthenticationHandler : IRequestHandler<AuthenticationCommand, AuthenticationResponse>
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationHandler(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }
        public async Task<AuthenticationResponse> Handle(AuthenticationCommand request, CancellationToken cancellationToken)
        {
            return await authenticationService.Authenticate(request.AuthenticationRequest.Username, request.AuthenticationRequest.Password); 
        }
    }
}
