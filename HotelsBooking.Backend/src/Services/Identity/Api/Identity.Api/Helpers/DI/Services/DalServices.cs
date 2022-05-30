using Identity.Api.Helpers.DI.Contracts;
using Identity.Dal.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Api.Helpers.DI.Services
{
    public class DalServices : IConfigureServices
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);
        }
    }
}
