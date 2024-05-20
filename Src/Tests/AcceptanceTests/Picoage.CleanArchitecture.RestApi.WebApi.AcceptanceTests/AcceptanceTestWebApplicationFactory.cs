using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace Picoage.CleanArchitecture.RestApi.WebApi.AcceptanceTests;
internal class AcceptanceTestWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    override protected void ConfigureWebHost(IWebHostBuilder builder)
    {
        IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        builder.UseEnvironment("Development").UseConfiguration(config);
        
    }
}
