using Application.Service.Authentication;
namespace Application;
using Microsoft.Extensions.DependencyInjection;
// class register service to program
public static class DependancyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services )
    
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}