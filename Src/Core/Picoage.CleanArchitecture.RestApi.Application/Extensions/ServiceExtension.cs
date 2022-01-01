using Microsoft.Extensions.DependencyInjection;
using Picoage.CleanArchitecture.RestApi.Application.Interfaces.Services;
using Picoage.CleanArchitecture.RestApi.Application.Services;

namespace Picoage.CleanArchitecture.RestApi.Application.Extensions
{
    public static class ServiceExtension
    {
        public static void RegisterApplicationInstances(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAuthenticationService, AuthenticationService>();
        }
    }
}
