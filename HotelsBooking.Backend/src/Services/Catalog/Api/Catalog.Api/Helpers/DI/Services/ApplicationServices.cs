using Catalog.Api.Helpers.DI.Contracts;
using Catalog.Application.Common.Contracts;
using Catalog.Application.Common.Mapping;
using Catalog.Application.Common.Services;
using Catalog.DAL.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Identity.Domain.Models.Configuration;
using System;

namespace Catalog.Api.Helpers.DI.Services
{
    public class ApplicationServices : IConfigureServices
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IHotelRepository, HotelService>();
            services.AddScoped<IRoomRepository, RoomService>();
            services.AddPersistence(configuration);

            AuthConfiguration authConfiguration = new AuthConfiguration();
            configuration.Bind("Authentication", authConfiguration);

            services.AddSingleton(authConfiguration);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authConfiguration.AccessTokenSecret)),
                    ValidIssuer = authConfiguration.Issuer,
                    ValidAudience = authConfiguration.Audience,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
            services.AddAutoMapper(typeof(HotelsBookingProfile));
        }
    }
}
