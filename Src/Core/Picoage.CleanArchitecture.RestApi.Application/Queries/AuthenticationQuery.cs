using MediatR;
using Picoage.CleanArchitecture.RestApi.Application.Models.ResposeModels;
using Picoage.CleanArchitecture.RestApi.Application.RequestModels;

namespace Picoage.CleanArchitecture.RestApi.Application.Queries;
public record AuthenticationQuery(AuthenticationRequest AuthenticationRequest) : IRequest<AuthenticationResponse>
{

}
