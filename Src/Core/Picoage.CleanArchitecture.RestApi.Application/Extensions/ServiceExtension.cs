using Microsoft.Extensions.DependencyInjection;
using Picoage.CleanArchitecture.RestApi.Application.Interfaces.Services;
using Picoage.CleanArchitecture.RestApi.Application.Services;
using System.Reflection;
using MediatR; 

namespace Picoage.CleanArchitecture.RestApi.Application.Extensions
{
    public static class ServiceExtension
    {
        public static void RegisterApplicationInstances(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly()); 
            serviceCollection.AddTransient<IAuthenticationService, AuthenticationService>();
        }
    }
}
