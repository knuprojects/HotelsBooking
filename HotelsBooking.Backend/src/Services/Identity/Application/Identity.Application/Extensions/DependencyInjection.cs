using Identity.Application.Common.Contracts;
using Identity.Application.Common.Services;
using Identity.Application.TokenGenerators;
using Identity.Application.TokenValidator;
using Identity.Dal.Common.Contracts;
using Identity.Dal.Common.Services;
using Identity.Domain.Models.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Identity.Application.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services,
            IConfiguration configuration)
        {
            AuthConfiguration authConfiguration = new AuthConfiguration();
            configuration.Bind("Authentication", authConfiguration);

            services.AddSingleton(authConfiguration);

            services.AddSingleton<JwtTokenGenerator>();
            services.AddSingleton<AccessTokenGenerator>();
            services.AddSingleton<RefreshTokenGenerator>();
            services.AddSingleton<RefreshTokenValidator>();
            services.AddScoped(typeof(IEfRepository<>), typeof(EfService<>));
            services.AddScoped<IIdentityRepository, IdentityService>();
            services.AddScoped<IPasswordHasher, PasswordHasherService>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenService>();

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

            return services;
        }
    }
}
