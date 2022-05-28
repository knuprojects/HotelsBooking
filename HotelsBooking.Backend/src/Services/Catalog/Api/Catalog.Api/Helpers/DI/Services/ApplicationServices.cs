using Catalog.Api.Helpers.DI.Contracts;
using Catalog.Application.Common.Contracts;
using Catalog.Application.Common.Mapping;
using Catalog.Application.Common.Services;
using Catalog.DAL.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Api.Helpers.DI.Services
{
    public class ApplicationServices : IConfigureServices
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IHotelRepository, HotelService>();
            services.AddPersistence(configuration);
            services.AddAutoMapper(typeof(HotelsBookingProfile));
        }
    }
}
