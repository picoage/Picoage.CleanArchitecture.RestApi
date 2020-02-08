using Microsoft.Extensions.DependencyInjection;
using Picoage.CleanArchitecture.RestApi.Application.Interfaces.Repositories;
using Picoage.CleanArchitecture.RestApi.Application.Interfaces.Services;
using Picoage.CleanArchitecture.RestApi.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

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
