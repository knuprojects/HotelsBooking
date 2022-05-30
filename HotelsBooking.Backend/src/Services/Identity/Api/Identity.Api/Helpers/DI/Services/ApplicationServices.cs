using Identity.Api.Helpers.DI.Contracts;
using Identity.Application.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Api.Helpers.DI.Services
{
    public class ApplicationServices : IConfigureServices
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplication(configuration);
        }
    }
}
