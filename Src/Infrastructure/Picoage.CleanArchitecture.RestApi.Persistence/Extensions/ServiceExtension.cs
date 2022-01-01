using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Picoage.CleanArchitecture.RestApi.Application.Interfaces.Repositories;
using System.Linq;

namespace Picoage.CleanArchitecture.RestApi.Persistence.Extensions
{
    public static class ServiceExtension
    {
        public static void RegisterPersistenceInstances(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            string dataStorePath = configuration.GetSection("Datastore").GetChildren().FirstOrDefault(c => c.Key == "RootDirectory").Value;
            serviceCollection.AddTransient<ICustomerRepository>(e => new CustomerRepository(dataStorePath)); 
        }
    }
}
