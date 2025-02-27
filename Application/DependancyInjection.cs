using System.Reflection;
using Application.Common.Behaviors;
using Application.Service.Authentication;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ErrorOr;
namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
       
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}