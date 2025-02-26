using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Application.Service.Authentication;
using ClassLibrary1.Authentication;
using ClassLibrary1.Services;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using WebApplication3.Common.Mapping;
using WebApplication3.Errors;

namespace Presentation;
using Microsoft.Extensions.DependencyInjection;
// class register service to program
public static class DependancyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)

    {
        services.AddControllers();
        services.AddMapping();
        services.AddSingleton<ProblemDetailsFactory, MyProblemDetailFactory>();
        return services;
    }
}