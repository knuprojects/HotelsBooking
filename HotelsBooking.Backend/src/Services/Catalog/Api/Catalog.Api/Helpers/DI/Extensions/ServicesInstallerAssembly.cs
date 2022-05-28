using Catalog.Api.Helpers.DI.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Catalog.Api.Helpers.DI.Extensions
{
    public static class ServicesInstallerAssembly
    {
        public static void InstallServicesAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes.Where(x =>
            typeof(IConfigureServices).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance)
            .Cast<IConfigureServices>().ToList();

            installers.ForEach(installer => installer.InstallServices(services, configuration));
        }
    }
}
