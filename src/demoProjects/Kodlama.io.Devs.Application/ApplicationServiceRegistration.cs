using System.Reflection;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using Kodlama.Io.Devs.Application.Features.Auths.Rules;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.Io.Devs.Application.Features.Technologies.Rules;
using Kodlama.Io.Devs.Application.Services.AuthService;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Kodlama.Io.Devs.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddScoped<ProgrammingLanguageBusinessRules>();
        services.AddScoped<TechnologyBusinessRules>();
        services.AddScoped<AuthBusinessRules>();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
        // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
        // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
        // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

        services.AddScoped<IAuthService, AuthManager>();

        return services;
    }
}