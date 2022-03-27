using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Picoage.CleanArchitecture.RestApi.Application.Interfaces.Repositories;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Picoage.CleanArchitecture.RestApi.Persistence.Extensions
{
    public static class ServiceExtension
    {
        public static void RegisterPersistenceInstances(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            string executablePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string dataStoreName = configuration.GetSection("Datastore").GetChildren().FirstOrDefault(c => c.Key == "RootDirectory").Value;
            string dataStorePath = Path.Combine(executablePath, dataStoreName);

            serviceCollection.AddTransient<ICustomerRepository>(e => new CustomerRepository(dataStorePath));
        }
    }
}
