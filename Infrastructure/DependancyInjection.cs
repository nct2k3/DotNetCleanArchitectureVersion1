using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Application.Service.Authentication;
using ClassLibrary1.Authentication;
using ClassLibrary1.Services;
using Infrastructure.Persistance;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;
using Microsoft.Extensions.DependencyInjection;
// class register service to program
public static class DependancyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services
       , ConfigurationManager configuration
    )

    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>(); 
        return services;
    }
}