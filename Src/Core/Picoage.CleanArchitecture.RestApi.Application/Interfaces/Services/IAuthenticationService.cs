using Picoage.CleanArchitecture.RestApi.Application.Models.ResposeModels;
using System.Threading.Tasks;

namespace Picoage.CleanArchitecture.RestApi.Application.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> Authenticate(string userName, string Password); 
    }
}
