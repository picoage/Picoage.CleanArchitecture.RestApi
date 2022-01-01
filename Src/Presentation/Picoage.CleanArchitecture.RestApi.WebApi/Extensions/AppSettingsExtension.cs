using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Picoage.CleanArchitecture.RestApi.Application.AppSettings;

namespace Picoage.CleanArchitecture.RestApi.WebApi.ServiceCollections
{
    public static class AppSettingsExtension
    {
        public static AuthenticationSettings GetAuthenticationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            IConfiguration appSettingsSection = configuration.GetSection("Authentication");
            services.Configure<AuthenticationSettings>(appSettingsSection);
            return appSettingsSection.Get<AuthenticationSettings>();
        }
    }
}
