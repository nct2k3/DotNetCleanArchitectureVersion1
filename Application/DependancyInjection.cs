using System.Reflection;
//using Application.Common.Behavios;
using Application.Service.Authentication;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
       
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        /*services.AddScoped<IPipelineBehavior<RegisterCommand,AuthenticationResult>,
            ValidationRegisterCommandBehavior>();*/
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}