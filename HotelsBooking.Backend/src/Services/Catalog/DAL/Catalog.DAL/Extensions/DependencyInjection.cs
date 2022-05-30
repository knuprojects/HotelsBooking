using Catalog.DAL.Common.Contracts;
using Catalog.DAL.Common.Services;
using Catalog.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.DAL.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<CatalogDbContext>(options =>
            {
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Catalog.Api"));
            });

            services.AddScoped(typeof(IEfRepository<>), typeof(EfService<>));

            return services;
        }
    }
}
