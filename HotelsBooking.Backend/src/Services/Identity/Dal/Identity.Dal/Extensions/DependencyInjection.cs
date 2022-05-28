using Identity.Dal.Common.Contracts;
using Identity.Dal.Common.Services;
using Identity.Dal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Dal.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["DatabaseSettings:ConnectionString"];

            services.AddDbContext<IdentityDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped(typeof(IEfRepository<>), typeof(EfService<>));

            return services;
        }
    }
}
