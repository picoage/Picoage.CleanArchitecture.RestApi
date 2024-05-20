using MediatR;
using Picoage.CleanArchitecture.RestApi.Application.Interfaces.Services;
using Picoage.CleanArchitecture.RestApi.Application.Models.ResposeModels;
using System.Threading;
using System.Threading.Tasks;

namespace Picoage.CleanArchitecture.RestApi.Application.Queries.Handlers;
internal class AuthenticationHandler(IAuthenticationService authenticationService) : IRequestHandler<AuthenticationQuery, AuthenticationResponse>
{
    public async Task<AuthenticationResponse> Handle(AuthenticationQuery request, CancellationToken cancellationToken) =>
       await authenticationService.Authenticate(request.AuthenticationRequest.Username, request.AuthenticationRequest.Password);
}
