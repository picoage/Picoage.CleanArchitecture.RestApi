using Microsoft.Extensions.DependencyInjection;
using Picoage.CleanArchitecture.RestApi.Application.Interfaces.Repositories;

namespace Picoage.CleanArchitecture.RestApi.Persistence.Extensions
{
    public static class ServiceExtension
    {
        public static void RegisterPersistenceInstances(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICustomerRepository, CustomerRepository>();
        }
    }
}
